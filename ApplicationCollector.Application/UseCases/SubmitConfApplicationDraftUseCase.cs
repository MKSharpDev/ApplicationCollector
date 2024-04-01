using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class SubmitConfApplicationDraftUseCase : ISubmitConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;
        private readonly IConfApplicationRepository confApplicationRepository;
        private readonly ISpeakerRepository authorRepository;

        public SubmitConfApplicationDraftUseCase(
            IConfApplicationDraftRepository confApplicationDraftRepository,
            IConfApplicationRepository confApplicationRepository,
            ISpeakerRepository authorRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
            this.confApplicationRepository = confApplicationRepository;
            this.authorRepository = authorRepository;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);
            if (confAppDraftFromDb == null)
            {
                throw new Exception("Нет черновика заявки с таким id");
            }
            bool notValid = String.IsNullOrEmpty(confAppDraftFromDb.Activity) || String.IsNullOrEmpty(confAppDraftFromDb.Name)
                || String.IsNullOrEmpty(confAppDraftFromDb.Description) || String.IsNullOrEmpty(confAppDraftFromDb.Outline);

            if (notValid)
            {
                throw new Exception("нельзя отправить заявку в которой есть не заполненные поля");
            }
            var authorId = confAppDraftFromDb.Author;

            var appToSubmit = new ConfApplication
            {
                Id = id,
                Author = confAppDraftFromDb.Author,
                Name = confAppDraftFromDb.Name,
                Description = confAppDraftFromDb.Description,
                Outline = confAppDraftFromDb.Outline,
                Activity = confAppDraftFromDb.Activity,
                Time = confAppDraftFromDb.Time
            };

            await confApplicationRepository.AddAsync(appToSubmit, true, cancellationToken);
            await confApplicationDraftRepository.DeleteAsync(id, true, cancellationToken);

            var authorToEdit = new Speaker()
            {
                Id = authorId,
                ApplicationDraftInProgressId = Guid.Empty
            };

            await authorRepository.EditAsync(authorToEdit, true, cancellationToken);
        }
    }
}
