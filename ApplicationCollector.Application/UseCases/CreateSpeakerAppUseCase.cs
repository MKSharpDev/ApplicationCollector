using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class CreateSpeakerAppUseCase : ICreateSpeakerAppUseCase
    {
        private readonly ISpeakerRepository authorRepository;

        public CreateSpeakerAppUseCase(ISpeakerRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<SpeakerDTO> ExecuteAsync(SpeakerDTO authorDTO, CancellationToken cancellationToken)
        {
            //to do проверить наличие
            Speaker newAuthor = new Speaker()
            {
                Author = authorDTO.Author,
                Name = authorDTO.Name,
                Description = authorDTO.Description,
                Outline = authorDTO.Outline
            };
            Speaker authorResult = await authorRepository.AddAsync(newAuthor);
            SpeakerDTO authorResultDto = new SpeakerDTO()
            {
                Author = authorResult.Author,
                Outline = authorResult.Outline,
                Name = authorResult.Name,
                Description = authorResult.Description
            };

            return authorResultDto;

        }
    }
}
