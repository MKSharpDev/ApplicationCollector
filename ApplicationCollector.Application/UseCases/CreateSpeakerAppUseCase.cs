using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class CreateSpeakerAppUseCase : ICreateSpeakerAppUseCase
    {
        private readonly ISpeakerRepository authorRepository;
        private readonly IConfActivityRepository confActivityRepository;


        public CreateSpeakerAppUseCase(
            ISpeakerRepository authorRepository, 
            IConfActivityRepository confActivityRepository)
        {
            this.authorRepository = authorRepository;
            this.confActivityRepository = confActivityRepository;
        }

        public async Task<SpeakerDTO> ExecuteAsync(SpeakerDTO authorDTO, CancellationToken cancellationToken)
        {

            var speakerInDb = await authorRepository.GetAsync(authorDTO.Author);

            if (speakerInDb != null)
            {
                throw new Exception("Aвтор с таким id уже зарегистрирован"); 
            }

            var activityInDb = (await confActivityRepository.GetAllAsync()).Where(a => authorDTO.Activity == a.Activity).FirstOrDefault();
            string activityName = "";
            if ( activityInDb != null)
            {
                activityName = activityInDb.Activity;
            }
              
            Speaker newAuthor = new Speaker()
            {
                Id = authorDTO.Author,
                Name = authorDTO.Name,
                Description = authorDTO.Description,
                Outline = authorDTO.Outline,
                Activity = activityInDb,
                ApplicationDraft = new ConfApplicationDraft
                {
                    Author = authorDTO.ApplicationDTO.Author,
                    Name = authorDTO.ApplicationDTO.Name,
                    Description = authorDTO.ApplicationDTO.Description,
                    Id = authorDTO.ApplicationDTO.Id,
                    Outline = authorDTO.ApplicationDTO.Outline,
                    Activity = activityName,
                    Time = DateTime.Now

                }              
            };

            Speaker authorResult = await authorRepository.AddAsync(newAuthor, true, cancellationToken);
            string activityRezultName = "";
            if (authorResult.Activity != null)
            {
                activityRezultName = authorResult.Activity.Activity;
            }

            SpeakerDTO authorResultDto = new SpeakerDTO()
            {
                Author = authorResult.Id,
                Outline = authorResult.Outline,
                Name = authorResult.Name,
                Description = authorResult.Description,
                Activity = activityRezultName,
                ApplicationDTO = new ConfApplicationDraftDTO
                {
                    Author = authorResult.ApplicationDraft.Author,
                    Name = authorResult.ApplicationDraft.Name,
                    Description = authorResult.ApplicationDraft.Description,
                    Id = authorResult.ApplicationDraft.Id,
                    Activity = activityRezultName,
                    Outline = authorResult.ApplicationDraft.Outline
                }
            };

            return authorResultDto;
        }
    }
}
