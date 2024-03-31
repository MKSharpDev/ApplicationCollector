namespace ApplicationCollector.Application.Interfaces
{
    public interface IEditConfApplicationDraftUseCase
    {
        public Task<ConfApplicationDraftDTO> ExecuteAsync(ConfApplicationDraftDTO confApplicationDraftDTO, CancellationToken cancellationToken);
    }
}
