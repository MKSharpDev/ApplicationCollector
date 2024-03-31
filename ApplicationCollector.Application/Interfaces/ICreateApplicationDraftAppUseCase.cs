namespace ApplicationCollector.Application.Interfaces
{
    public interface ICreateApplicationDraftAppUseCase
    {
        Task<ConfApplicationDraftDTO> ExecuteAsync(ConfApplicationDraftDTO appInDTO, CancellationToken cancellationToken);
    }
}
