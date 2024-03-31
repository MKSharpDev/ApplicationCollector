namespace ApplicationCollector.Application.Interfaces
{
    public interface IDeleteConfApplicationDraftUseCase
    {
        public Task ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
