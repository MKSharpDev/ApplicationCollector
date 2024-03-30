using ApplicationCollector.Application;
using ApplicationCollector.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCollector.WebApi.Controllers
{

    [ApiController]
    [Route("api/speakers")]

    public class SpeakerController : Controller
    {
        private readonly ICreateSpeakerAppUseCase createAutorAppUseCase;

        public SpeakerController(
            ICreateSpeakerAppUseCase createAutorAppUseCas
            )
        {
            this.createAutorAppUseCase = createAutorAppUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(SpeakerDTO authorDTO)
        {
            var rezult = await createAutorAppUseCase.ExecuteAsync(authorDTO, HttpContext.RequestAborted);
            return Ok(rezult);
        }
    }

}
