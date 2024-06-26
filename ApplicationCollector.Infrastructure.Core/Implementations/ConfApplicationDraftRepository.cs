﻿using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;


namespace ApplicationCollector.Infrastructure.Core.Implementations
{
    public class ConfApplicationDraftRepository : Repository<ConfApplicationDraft, Guid>, IConfApplicationDraftRepository
    {
        public ConfApplicationDraftRepository(AppDbContext appDbContext) : base(appDbContext)
        { }
    }
}
