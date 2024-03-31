namespace ApplicationCollector.Application.Interfaces
{
    public interface IEditConfApplicationDraftUseCase
    {
        public Task<ConfApplicationDraftDTO> ExecuteAsync(
            Guid id, 
            ConfApplicationDraftForEditDTO confAppDraftForEditDTO,
            CancellationToken cancellationToken);
    }
}
