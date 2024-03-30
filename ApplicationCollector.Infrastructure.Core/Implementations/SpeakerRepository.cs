using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;


namespace ApplicationCollector.Infrastructure.Core.Implementations
{
    public class SpeakerRepository : Repository<Speaker, Guid>, ISpeakerRepository
    {
        public SpeakerRepository(AppDbContext appDbContext) : base(appDbContext)
        { }
    }
}
