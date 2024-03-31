namespace ApplicationCollector.Application.Interfaces
{
    public interface IGetSubmitConfApplicationByDateUseCase
    {
        public Task<List<ConfApplicationDraftDTO>> ExecuteAsync(string time, CancellationToken cancellationToken);
    }
}
