using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class GetConfApplicationDraftUseCase : IGetConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;
        private readonly IConfApplicationRepository confApplicationRepository;


        public GetConfApplicationDraftUseCase(
            IConfApplicationDraftRepository confApplicationDraftRepository,
            IConfApplicationRepository confApplicationRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
            this.confApplicationRepository = confApplicationRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            ConfApplicationDraftDTO result = new ConfApplicationDraftDTO();
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);
            if (confAppDraftFromDb == null)
            {
                var confAppFromDb = await confApplicationRepository.GetAsync(id, true, cancellationToken);
                if (confAppDraftFromDb == null)
                {
                    throw new Exception("Нет черновика заявки с таким id");
                }

                result.Id = confAppFromDb.Id;
                result.Author = confAppFromDb.Author;
                result.Name = confAppFromDb.Name;
                result.Description = confAppFromDb.Description;
                result.Outline = confAppFromDb.Outline;       
                
            }
            else
            {
                result.Id = confAppDraftFromDb.Id;
                result.Author = confAppDraftFromDb.Author;
                result.Name = confAppDraftFromDb.Name;
                result.Description = confAppDraftFromDb.Description;
                result.Outline = confAppDraftFromDb.Outline;
            }

            return result;
        }
    }
}
