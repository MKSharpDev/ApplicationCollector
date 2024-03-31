namespace ApplicationCollector.Application.Interfaces
{
    public interface IGetConfApplicationDraftUseCase
    {
        public Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }    
}
