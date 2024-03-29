using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Infrastructure.Core.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
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
    }
}
