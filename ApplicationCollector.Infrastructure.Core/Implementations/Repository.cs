using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCollector.Infrastructure.Core.Implementations
{
    public class Repository<T, U> : IRepository<T, U> where T : BaseEntity<U> where U : notnull
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            return result.Entity;
        }
        public async Task<T> GetAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
            return result;
        }

        public async Task<List<T>> GetAllAsync(bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Set<T>().FindAsync(id, cancellationToken);
            if (result != null)
            {
                _dbContext.Set<T>().Remove(result);
                await _dbContext.SaveChangesAsync(saveChanges, cancellationToken);
            }
        }
        public async Task EditAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var getEntity = await _dbContext.Set<T>().FindAsync(entity.Id , cancellationToken);
            if (getEntity != null)
            {
                _dbContext.Set<T>().Attach(entity);
            }
        }
    }
}
