using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class GetConfApplicationDraftUseCase : IGetConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;

        public GetConfApplicationDraftUseCase(IConfApplicationDraftRepository confApplicationDraftRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);
            if (confAppDraftFromDb == null )
            {
                throw new Exception("Нет черновика заявки с таким id");
            }
            ConfApplicationDraftDTO result = new ConfApplicationDraftDTO() 
            { 
                Id = confAppDraftFromDb.Id,
                Author = confAppDraftFromDb.Author,
                Name = confAppDraftFromDb.Name,
                Description = confAppDraftFromDb.Description,
                Outline = confAppDraftFromDb.Outline
            };

            return result;

        }
    }

    

}
