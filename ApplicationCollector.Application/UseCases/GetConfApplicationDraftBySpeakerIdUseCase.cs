using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class GetConfApplicationDraftBySpeakerIdUseCase : IGetConfApplicationDraftBySpeakerIdUseCase
    {
        private readonly ISpeakerRepository authorRepository;
        private readonly IConfActivityRepository confActivityRepository;


        public GetConfApplicationDraftBySpeakerIdUseCase(
            ISpeakerRepository authorRepository,
            IConfActivityRepository confActivityRepository)
        {
            this.authorRepository = authorRepository;
            this.confActivityRepository = confActivityRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {

            var speakerDto = await authorRepository.GetAsync(id, true, cancellationToken);

            if (speakerDto == null)
            {
                throw new Exception("Нет автора с таким id");
            }

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
                Outline = speakerDto.ApplicationDraft.Outline
            };

            return result;
        }
    }
}
