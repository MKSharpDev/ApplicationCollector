namespace ApplicationCollector.Infrastructure.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
