using ApplicationCollector.Application;
using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCollector.WebApi.Controllers
{

    [ApiController]
    [Route("api/speakers")]

    public class SpeakerController : Controller
    {
        private readonly ICreateSpeakerAppUseCase createAutorAppUseCase;
        private readonly IGetConfApplicationDraftBySpeakerIdUseCase getConfApplicationDraftBySpeakerIdUseCase;

        public SpeakerController(
            ICreateSpeakerAppUseCase createAutorAppUseCase, 
            IGetConfApplicationDraftBySpeakerIdUseCase getConfApplicationDraftBySpeakerIdUseCase
            )
        {
            this.createAutorAppUseCase = createAutorAppUseCase;
            this.getConfApplicationDraftBySpeakerIdUseCase = getConfApplicationDraftBySpeakerIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(SpeakerDTO authorDTO)
        {
            var rezult = await createAutorAppUseCase.ExecuteAsync(authorDTO, HttpContext.RequestAborted);
            return Ok(rezult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationDraftBySpeakerId([FromRoute] Guid id)
        {
            return Ok(await getConfApplicationDraftBySpeakerIdUseCase.ExecuteAsync(id, HttpContext.RequestAborted));
        }
    }
}
