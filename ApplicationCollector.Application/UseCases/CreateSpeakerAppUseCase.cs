﻿using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Domain.Entities;
using ApplicationCollector.Infrastructure.Core.Interfaces;

namespace ApplicationCollector.Application.UseCases
{
    public class CreateSpeakerAppUseCase : ICreateSpeakerAppUseCase
    {
        private readonly ISpeakerRepository authorRepository;

        public CreateSpeakerAppUseCase(ISpeakerRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<SpeakerDTO> ExecuteAsync(SpeakerDTO authorDTO, CancellationToken cancellationToken)
        {
            //to do проверить наличие
            Speaker newAuthor = new Speaker()
            {
                Id = authorDTO.Author,
                Name = authorDTO.Name,
                Description = authorDTO.Description,
                Outline = authorDTO.Outline,
                ApplicationDraft = new ConfApplicationDraft
                {
                    Author = authorDTO.ApplicationDTO.Author,
                    Name = authorDTO.ApplicationDTO.Name,
                    Description = authorDTO.ApplicationDTO.Description,
                    Id = authorDTO.ApplicationDTO.Id,
                    Outline = authorDTO.ApplicationDTO.Outline,
                    Time = DateTime.Now
                }              
            };
            Speaker authorResult = await authorRepository.AddAsync(newAuthor, true, cancellationToken);
            SpeakerDTO authorResultDto = new SpeakerDTO()
            {
                Author = authorResult.Id,
                Outline = authorResult.Outline,
                Name = authorResult.Name,
                Description = authorResult.Description,
                ApplicationDTO = new ConfApplicationDraftDTO
                {
                    Author = authorResult.ApplicationDraft.Author,
                    Name = authorResult.ApplicationDraft.Name,
                    Description = authorResult.ApplicationDraft.Description,
                    Id = authorResult.ApplicationDraft.Id,
                    Outline = authorResult.ApplicationDraft.Outline
                }
            };

            return authorResultDto;

        }
    }
}
