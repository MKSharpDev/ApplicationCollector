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

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(ConfApplicationDraftDTO confApplicationDraftDTO, CancellationToken cancellationToken)
        {
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(confApplicationDraftDTO.Id, true, cancellationToken);

            if (confAppDraftFromDb == null)
            {
                throw new Exception("Нет черновика заявки с таким id");
            }
            var speaker = await authorRepository.GetAsync(confAppDraftFromDb.Author, true, cancellationToken);
            ConfApplicationDraft entityToChange = new ConfApplicationDraft() 
            {
                Description = confApplicationDraftDTO.Description,
                Name = confApplicationDraftDTO.Name,
                Outline = confApplicationDraftDTO.Outline,
                Author = confApplicationDraftDTO.Author,      
                Activity = confApplicationDraftDTO.Activity,
                Id = confApplicationDraftDTO.Id,
                Time = confAppDraftFromDb.Time,
                Speaker = confAppDraftFromDb.Speaker
            };

            var editResult = await confApplicationDraftRepository.EditAsync(entityToChange, true, cancellationToken);

            var resultDto = new ConfApplicationDraftDTO()
            {
                Description = editResult.Description,
                Name = editResult.Name,
                Outline = editResult.Outline,
                Author = editResult.Author,
                Activity = editResult.Activity
            };

            return resultDto;
        }
    }
    
}
