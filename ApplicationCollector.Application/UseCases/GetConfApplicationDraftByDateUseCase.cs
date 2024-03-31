﻿using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class GetConfApplicationDraftByDateUseCase : IGetConfApplicationDraftByDateUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;

        public GetConfApplicationDraftByDateUseCase(IConfApplicationDraftRepository confApplicationDraftRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task<List<ConfApplicationDraftDTO>> ExecuteAsync(string time, CancellationToken cancellationToken)
        {
            DateTime selectedtime = DateTime.Parse(time);
            List<ConfApplicationDraftDTO> appRezultList = new List<ConfApplicationDraftDTO>();

            var appListFromDb = await confApplicationDraftRepository.GetAllAsync();

            var filteredAppListFromDb = appListFromDb.Where(a => DateTime.Parse(a.Time) > selectedtime).ToList();

            foreach (var item in filteredAppListFromDb)
            {
                var itemToAdd = new ConfApplicationDraftDTO
                {
                    Id = item.Id,
                    Author = item.Author,
                    Activity = item.Activity,
                    Name = item.Name,
                    Description = item.Description,
                    Outline = item.Outline
                };

                appRezultList.Add(itemToAdd);
            }

            return appRezultList;
        }
    }
}
