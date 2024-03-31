using ApplicationCollector.Domain.Entities;

namespace ApplicationCollector.Infrastructure.Core.Interfaces
{
    public interface IConfApplicationRepository : IRepository<ConfApplication, Guid>
    {
    }
}
