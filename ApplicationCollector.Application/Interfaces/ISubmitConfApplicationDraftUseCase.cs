namespace ApplicationCollector.Application.Interfaces
{
    public interface ISubmitConfApplicationDraftUseCase
    {
        public Task ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
