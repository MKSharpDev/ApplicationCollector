using ApplicationCollector.Application;
using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCollector.WebApi.Controllers
{

    [ApiController]
    [Route("api/users")]

    public class SpeakerController : Controller
    {
       
        private readonly IGetConfApplicationDraftBySpeakerIdUseCase getConfApplicationDraftBySpeakerIdUseCase;

        public SpeakerController(IGetConfApplicationDraftBySpeakerIdUseCase getConfApplicationDraftBySpeakerIdUseCase)
        {
            this.getConfApplicationDraftBySpeakerIdUseCase = getConfApplicationDraftBySpeakerIdUseCase;
        }

 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationDraftBySpeakerId([FromRoute] Guid id)
        {
            return Ok(await getConfApplicationDraftBySpeakerIdUseCase.ExecuteAsync(id, HttpContext.RequestAborted));
        }
    }
}
