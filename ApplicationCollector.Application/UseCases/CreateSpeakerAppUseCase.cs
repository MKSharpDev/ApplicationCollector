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
                Outline = authorDTO.Outline,
                Application = new ConfApplication
                {
                    Author = authorDTO.ApplicationDTO.Author,
                    Name = authorDTO.ApplicationDTO.Name,
                    Description = authorDTO.ApplicationDTO.Description,
                    Id = authorDTO.ApplicationDTO.Id,
                    Outline = authorDTO.ApplicationDTO.Outline
                }
                
            };
            Speaker authorResult = await authorRepository.AddAsync(newAuthor);
            SpeakerDTO authorResultDto = new SpeakerDTO()
            {
                Author = authorResult.Author,
                Outline = authorResult.Outline,
                Name = authorResult.Name,
                Description = authorResult.Description,
                ApplicationDTO = new ConfApplicationDTO
                {
                    Author = authorResult.Application.Author,
                    Name = authorResult.Application.Name,
                    Description = authorResult.Application.Description,
                    Id = authorResult.Application.Id,
                    Outline = authorResult.Application.Outline
                }
            };

            return authorResultDto;

        }
    }
}
