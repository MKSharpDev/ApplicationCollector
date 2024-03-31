using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class GetConfApplicationDraftBySpeakerIdUseCase : IGetConfApplicationDraftBySpeakerIdUseCase
    {
        private readonly ISpeakerRepository authorRepository;
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;



        public GetConfApplicationDraftBySpeakerIdUseCase(
            ISpeakerRepository authorRepository,
            IConfApplicationDraftRepository confApplicationDraftRepository)
        {
            this.authorRepository = authorRepository;
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {

            var speakerDto = await authorRepository.GetAsync(id, true, cancellationToken);
            
            if (speakerDto == null)
            {
                throw new Exception("Нет автора с таким id");
            }

            speakerDto.ApplicationDraft = await confApplicationDraftRepository.GetAsync(speakerDto.ApplicationDraftId, true, cancellationToken);

            if (speakerDto.ApplicationDraft == null)
            {
                throw new Exception("У автора нет заявки");
            }

            ConfApplicationDraftDTO result = new ConfApplicationDraftDTO()
            {
                Id = speakerDto.ApplicationDraft.Id,
                Author = speakerDto.ApplicationDraft.Author,
                Name = speakerDto.ApplicationDraft.Name,
                Description = speakerDto.ApplicationDraft.Description,
                Outline = speakerDto.ApplicationDraft.Outline,
                Activity = speakerDto.Activity
            };

            return result;
        }
    }
}
