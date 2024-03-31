using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class CreateSpeakerAppUseCase : ICreateSpeakerAppUseCase
    {
        private readonly ISpeakerRepository authorRepository;


        public CreateSpeakerAppUseCase(
            ISpeakerRepository authorRepository) 
        {
            this.authorRepository = authorRepository;
        }

        public async Task<SpeakerDTO> ExecuteAsync(SpeakerDTO authorDTO, CancellationToken cancellationToken)
        {

            var speakerInDb = await authorRepository.GetAsync(authorDTO.Author);

            if (speakerInDb != null)
            {
                throw new Exception("Aвтор с таким id уже зарегистрирован"); 
            }

              
            Speaker newAuthor = new Speaker()
            {
                Id = authorDTO.Author,
                Name = authorDTO.Name,
                Description = authorDTO.Description,
                Outline = authorDTO.Outline,
                Activity = authorDTO.Activity,
                ApplicationDraft = new ConfApplicationDraft
                {
                    Author = authorDTO.ApplicationDTO.Author,
                    Name = authorDTO.ApplicationDTO.Name,
                    Description = authorDTO.ApplicationDTO.Description,
                    Id = authorDTO.ApplicationDTO.Id,
                    Outline = authorDTO.ApplicationDTO.Outline,
                    Activity = authorDTO.Activity,
                    Time = DateTime.Now.ToString()

                }              
            };

            Speaker authorResult = await authorRepository.AddAsync(newAuthor, true, cancellationToken);

            SpeakerDTO authorResultDto = new SpeakerDTO()
            {
                Author = authorResult.Id,
                Outline = authorResult.Outline,
                Name = authorResult.Name,
                Description = authorResult.Description,
                Activity = authorResult.Activity,
                ApplicationDTO = new ConfApplicationDraftDTO
                {
                    Author = authorResult.ApplicationDraft.Author,
                    Name = authorResult.ApplicationDraft.Name,
                    Description = authorResult.ApplicationDraft.Description,
                    Id = authorResult.ApplicationDraft.Id,
                    Activity = authorResult.Activity,
                    Outline = authorResult.ApplicationDraft.Outline
                }
            };

            return authorResultDto;
        }
    }
}
