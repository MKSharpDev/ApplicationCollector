using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class EditConfApplicationDraftUseCase : IEditConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;
        private readonly ISpeakerRepository authorRepository;


        public EditConfApplicationDraftUseCase(
            IConfApplicationDraftRepository confApplicationDraftRepository, 
            ISpeakerRepository authorRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
            this.authorRepository = authorRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id ,
            ConfApplicationDraftForEditDTO confAppDraftForEditDTO, 
            CancellationToken cancellationToken)
        {
            if (!String.IsNullOrEmpty(confAppDraftForEditDTO.Activity) && confAppDraftForEditDTO.Activity != "Report" && 
                confAppDraftForEditDTO.Activity != "Masterclass" && confAppDraftForEditDTO.Activity != "Discussion")
            {
                throw new Exception("Активность должна быть типа - Report, Masterclass, Discussion");
            }

            bool notValid = String.IsNullOrEmpty(confAppDraftForEditDTO.Activity) && String.IsNullOrEmpty(confAppDraftForEditDTO.Name)
                && String.IsNullOrEmpty(confAppDraftForEditDTO.Description) && String.IsNullOrEmpty(confAppDraftForEditDTO.Outline);

            if (notValid)
            {
                throw new Exception("нельзя измениь заявку не указав хотя бы одно поле");
            }
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);

            if (confAppDraftFromDb == null)
            {
                throw new Exception("Нет черновика заявки с таким id");
            }

            ConfApplicationDraft entityToChange = new ConfApplicationDraft() 
            {
                Description = confAppDraftForEditDTO.Description,
                Name = confAppDraftForEditDTO.Name,
                Outline = confAppDraftForEditDTO.Outline,
                Activity = confAppDraftForEditDTO.Activity,
                Id = confAppDraftFromDb.Id,
                Author = confAppDraftFromDb.Author,
                Time = confAppDraftFromDb.Time

            };


            await confApplicationDraftRepository.EditAsync(entityToChange, true, cancellationToken);

            var editResult = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);

            var resultDto = new ConfApplicationDraftDTO()
            {
                Description = editResult.Description,
                Name = editResult.Name,
                Outline = editResult.Outline,
                Author = editResult.Author,
                Activity = editResult.Activity,
                Id = editResult.Id
            };

            return resultDto;
        }
    }
    
}
