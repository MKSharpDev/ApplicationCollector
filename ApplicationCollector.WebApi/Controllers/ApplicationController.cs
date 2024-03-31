using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Application;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCollector.WebApi.Controllers
{
    [ApiController]
    [Route("api/applications")]

    public class ApplicationController : Controller
    {
        private readonly ICreateApplicationDraftAppUseCase сreateApplicationDraftAppUseCase;
        private readonly IGetConfApplicationDraftUseCase getConfApplicationDraftUseCase;
        private readonly IEditConfApplicationDraftUseCase editConfAppDraftUseCase;
        private readonly IDeleteConfApplicationDraftUseCase deleteConfApplicationDraftUseCase;
        private readonly ISubmitConfApplicationDraftUseCase submitConfApplicationDraftUseCase;
        private readonly IGetConfApplicationDraftByDateUseCase getConfApplicationDraftByDateUseCase;
        private readonly IGetSubmitConfApplicationByDateUseCase getSubmitConfApplicationByDateUseCase;


        public ApplicationController(
            IEditConfApplicationDraftUseCase editConfAppDraftUseCase,
            IGetConfApplicationDraftUseCase getConfApplicationDraftUseCase,
            IDeleteConfApplicationDraftUseCase deleteConfApplicationDraftUseCase,
            ICreateApplicationDraftAppUseCase сreateApplicationDraftAppUseCase,
            ISubmitConfApplicationDraftUseCase submitConfApplicationDraftUseCase,
            IGetConfApplicationDraftByDateUseCase getConfApplicationDraftByDateUseCase,
            IGetSubmitConfApplicationByDateUseCase getSubmitConfApplicationByDateUseCase
            )
        {
            this.getConfApplicationDraftUseCase = getConfApplicationDraftUseCase;
            this.editConfAppDraftUseCase = editConfAppDraftUseCase;
            this.deleteConfApplicationDraftUseCase = deleteConfApplicationDraftUseCase;
            this.сreateApplicationDraftAppUseCase = сreateApplicationDraftAppUseCase;
            this.submitConfApplicationDraftUseCase = submitConfApplicationDraftUseCase;
            this.getConfApplicationDraftByDateUseCase = getConfApplicationDraftByDateUseCase;
            this.getSubmitConfApplicationByDateUseCase = getSubmitConfApplicationByDateUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(ConfApplicationDraftDTO appInDTO)
        {
            var rezult = await сreateApplicationDraftAppUseCase.ExecuteAsync(appInDTO, HttpContext.RequestAborted);
            return Ok(rezult);
        }

        [HttpPost]
        [Route("{id}/submit")]
        public async Task<IActionResult> SubmitApplicationDraft([FromRoute] Guid id)
        {
            await submitConfApplicationDraftUseCase.ExecuteAsync(id, HttpContext.RequestAborted);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationDraft([FromRoute] Guid id)
        {
            return Ok(await getConfApplicationDraftUseCase.ExecuteAsync(id, HttpContext.RequestAborted));
        }

        [HttpGet]
        [Route("submittedAfter={date}")]
        public async Task<IActionResult> GetSubmitApplicationByDate([FromRoute] string date)
        {       
            return Ok(await getSubmitConfApplicationByDateUseCase.ExecuteAsync(date, HttpContext.RequestAborted));
        }

        [HttpGet]
        [Route("unsubmittedOlder={date}")]
        public async Task<IActionResult> GetApplicationDraftByDate([FromRoute] string date)
        {
            return Ok(await getConfApplicationDraftByDateUseCase.ExecuteAsync(date, HttpContext.RequestAborted));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditApplicationDraft([FromRoute] Guid id, ConfApplicationDraftForEditDTO confApplicationDraftDTO)
        {
            return Ok(await editConfAppDraftUseCase.ExecuteAsync(id, confApplicationDraftDTO, HttpContext.RequestAborted));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApplicationDraft([FromRoute] Guid id)
        {
            await deleteConfApplicationDraftUseCase.ExecuteAsync(id, HttpContext.RequestAborted);
            return Ok("Черновик заявки удален");
        }
    }
}

