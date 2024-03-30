﻿using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class EditConfApplicationDraftUseCase : IEditConfApplicationDraftUseCase
    {
        private readonly IConfApplicationDraftRepository confApplicationDraftRepository;

        public EditConfApplicationDraftUseCase(IConfApplicationDraftRepository confApplicationDraftRepository)
        {
            this.confApplicationDraftRepository = confApplicationDraftRepository;
        }

        public async Task<ConfApplicationDraftDTO> ExecuteAsync(ConfApplicationDraftDTO confApplicationDraftDTO, CancellationToken cancellationToken)
        {
            var confAppDraftFromDb = await confApplicationDraftRepository.GetAsync(confApplicationDraftDTO.Id, true, cancellationToken);

            if (confAppDraftFromDb == null)
            {
                throw new Exception("Нет черновика заявки с таким id");
            }

            ConfApplicationDraft entityToChange = new ConfApplicationDraft() 
            {
                Description = confApplicationDraftDTO.Description,
                Name = confApplicationDraftDTO.Name,
                Outline = confApplicationDraftDTO.Outline,
                Author = confApplicationDraftDTO.Author,
                
            };

            var result = await confApplicationDraftRepository.EditAsync(confApplicationDraftDTO, cancellationToken);


            return null;

        }
    }
    
}
