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
        //private readonly IEditConfApplicationUseCase editConfAppUseCase;

        public SpeakerController(
            ICreateSpeakerAppUseCase createAutorAppUseCase
            //IEditConfApplicationUseCase editConfAppUseCase
            )
        {
            this.createAutorAppUseCase = createAutorAppUseCase;
            //this.editConfAppUseCase = editConfAppUseCase;
        }
        [HttpGet]
        public IActionResult TestAction()
        {
            return Ok("Ответ отправлен успешно...");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(SpeakerDTO authorDTO)
        {
            var rezult = await createAutorAppUseCase.ExecuteAsync(authorDTO, HttpContext.RequestAborted);
            return Ok(rezult);
        }

        //[HttpPut]
        //public async Task<IActionResult> EditApplication(SpeakerDTO authorDTO)
        //{
        //    return Ok(await editConfAppUseCase.ExecuteAsync(authorDTO, HttpContext.RequestAborted));
        //}
    }

}
