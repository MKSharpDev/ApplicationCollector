namespace ApplicationCollector.Application.Interfaces
{
    public interface IGetConfApplicationDraftByDateUseCase
    {
        public Task<List<ConfApplicationDraftDTO>> ExecuteAsync(string time, CancellationToken cancellationToken);
    }
}
