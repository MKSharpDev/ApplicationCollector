using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class DeleteConfApplicationDraftUseCase : IDeleteConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;
        private readonly ISpeakerRepository authorRepository;

        public DeleteConfApplicationDraftUseCase(
            IConfApplicationDraftRepository confApplicationDraftRepository,
            ISpeakerRepository authorRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
            this.authorRepository = authorRepository;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(id, true, cancellationToken);
            if (confAppDraftFromDb == null)
            {
                throw new Exception("Нет черновика заявки с таким id");
            }

            var authorId = confAppDraftFromDb.Author;
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
