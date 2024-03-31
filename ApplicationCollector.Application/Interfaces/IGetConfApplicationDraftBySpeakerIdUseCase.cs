namespace ApplicationCollector.Application.Interfaces
{
    public interface IGetConfApplicationDraftBySpeakerIdUseCase
    {
        public Task<ConfApplicationDraftDTO> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
    
}
