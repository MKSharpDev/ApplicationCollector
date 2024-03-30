using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class DeleteConfApplicationDraftUseCase : IDeleteConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;

        public DeleteConfApplicationDraftUseCase(IConfApplicationDraftRepository confApplicationDraftRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);

            if (confAppDraftFromDb == null)
            {
                throw new Exception("Нет черновика заявки с таким id");
            }

            await confApplicationDraftRepository.DeleteAsync(id, true, cancellationToken);
        }
    }
    
}
