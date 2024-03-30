﻿using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;


namespace ApplicationCollector.Infrastructure.Core.Implementations
{
    public class ConfApplicationRepository : Repository<ConfApplication, Guid>, IConfApplicationDraftRepository
    {
        public ConfApplicationRepository(AppDbContext appDbContext) : base(appDbContext)
        { }
    }
}
