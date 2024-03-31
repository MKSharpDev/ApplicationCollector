using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class CreateApplicationDraftAppUseCase : ICreateApplicationDraftAppUseCase
    {
        private readonly ISpeakerRepository authorRepository;
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;


        public CreateApplicationDraftAppUseCase(
            ISpeakerRepository authorRepository,
            IConfApplicationDraftRepository confApplicationDraftRepository) 
        {
            this.authorRepository = authorRepository;
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(ConfApplicationDraftDTO appInDTO, CancellationToken cancellationToken)
        {

            if (appInDTO.Author == Guid.Empty)
            {
                throw new Exception("Нельзя создать заявку без указания автора");
            }
            if (!String.IsNullOrEmpty(appInDTO.Activity) && appInDTO.Activity != "Report" && 
                appInDTO.Activity != "Masterclass" && appInDTO.Activity !="Discussion")
            {
                throw new Exception("Активность должна быть типа - Report, Masterclass, Discussion");
            }
            bool notValid = String.IsNullOrEmpty(appInDTO.Activity) && String.IsNullOrEmpty(appInDTO.Name)
                && String.IsNullOrEmpty(appInDTO.Description) && String.IsNullOrEmpty(appInDTO.Outline);

            if (notValid)
            {
                throw new Exception("нельзя создать заявку не указав хотя бы еще одно поле помимо идентификатора пользователя");
            }

            var speakerInDb = await authorRepository.GetAsync(appInDTO.Author);

            if (speakerInDb == null)
            {
                Speaker newAuthor = new Speaker() { Id = appInDTO.Author};
                speakerInDb = await authorRepository.AddAsync(newAuthor, true, cancellationToken);
            }
            else if (speakerInDb.ApplicationDraftInProgressId != Guid.Empty)
            {
                throw new Exception("У автора есть черновик заявки");
            }

            var ApplicationDraft = new ConfApplicationDraft
            {
                Author = appInDTO.Author,
                Name = appInDTO.Name,
                Description = appInDTO.Description,
                Id = appInDTO.Id,
                Outline = appInDTO.Outline,
                Activity = appInDTO.Activity,
                Time = DateTime.Now.ToString()
            };

            var appRezult = await confApplicationDraftRepository.AddAsync(ApplicationDraft, true, cancellationToken);

            var appRezultDto = new ConfApplicationDraftDTO
            {
                Id = appRezult.Id,
                Author = appRezult.Author,
                Name = appRezult.Name,
                Description = appRezult.Description,
                Outline = appRezult.Outline,
                Activity = appRezult.Activity,
            };

            //Добавляем айдишник текущего черновика к автору и сохраняем изменение


            speakerInDb.ApplicationDraftInProgressId = appRezult.Id;
            await authorRepository.DeleteAsync(speakerInDb.Id, true, cancellationToken);
            await authorRepository.AddAsync(speakerInDb, true, cancellationToken);

            //await authorRepository.EditAsync(speakerInDb, true, cancellationToken);



            return appRezultDto;
        }
    }
}
