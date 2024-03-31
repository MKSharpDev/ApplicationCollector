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

            var speaker = await authorRepository.GetAsync(id, true, cancellationToken);
            
            if (speaker == null)
            {
                throw new Exception("Нет автора с таким id");
            }
            else if (speaker.ApplicationDraftInProgressId == null)
            {
                throw new Exception("У автора нет заявки");
            }

            var ApplicationDraft = await confApplicationDraftRepository.GetAsync(speaker.ApplicationDraftInProgressId, true, cancellationToken);

            if (ApplicationDraft == null)
            {
                throw new Exception("Ошибка указателя заявки ");
            }

            ConfApplicationDraftDTO result = new ConfApplicationDraftDTO()
            {
                Id = ApplicationDraft.Id,
                Author = ApplicationDraft.Author,
                Name = ApplicationDraft.Name,
                Description = ApplicationDraft.Description,
                Outline = ApplicationDraft.Outline,
                Activity = ApplicationDraft.Activity
            };

            return result;
        }
    }
}
