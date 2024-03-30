using ApplicationCollector.Application.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class EditConfApplicationDraftUseCase : IEditConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;

        public CreateSpeakerAppUseCase(IConfApplicationDraftRepository confApplicationDraftRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(ConfApplicationDraftDTO confApplicationDraftDTO, CancellationToken cancellationToken)
        {
            var confAppDraftFromDb = confApplicationDraftRepository.Get(confApplicationDraftDTO.Id);

            v

        }

    }

}
