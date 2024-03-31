using ApplicationCollector.Domain.Entities;

namespace ApplicationCollector.Infrastructure.Core.Interfaces
{
    public interface IRepository<T, U> where T : BaseEntity<U> where U : notnull
    {
        Task<T> AddAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<T> EditAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
