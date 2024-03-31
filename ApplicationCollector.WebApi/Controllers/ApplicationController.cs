using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Application;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCollector.WebApi.Controllers
{
    [ApiController]
    [Route("api/applications/")]

    public class ApplicationController : Controller
    {
        private readonly ICreateApplicationDraftAppUseCase сreateApplicationDraftAppUseCase;
        private readonly IGetConfApplicationDraftUseCase getConfApplicationDraftUseCase;
        private readonly IEditConfApplicationDraftUseCase editConfAppDraftUseCase;
        private readonly IDeleteConfApplicationDraftUseCase deleteConfApplicationDraftUseCase;

        public ApplicationController(
            IEditConfApplicationDraftUseCase editConfAppDraftUseCase,
            IGetConfApplicationDraftUseCase getConfApplicationDraftUseCase,
            IDeleteConfApplicationDraftUseCase deleteConfApplicationDraftUseCase,
            ICreateApplicationDraftAppUseCase сreateApplicationDraftAppUseCase
            )
        {
            this.getConfApplicationDraftUseCase = getConfApplicationDraftUseCase;
            this.editConfAppDraftUseCase = editConfAppDraftUseCase;
            this.deleteConfApplicationDraftUseCase = deleteConfApplicationDraftUseCase;
            this.сreateApplicationDraftAppUseCase = сreateApplicationDraftAppUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(ConfApplicationDraftDTO appInDTO)
        {
            var rezult = await сreateApplicationDraftAppUseCase.ExecuteAsync(appInDTO, HttpContext.RequestAborted);
            return Ok(rezult);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationDraft([FromRoute] Guid id)
        {
            return Ok(await getConfApplicationDraftUseCase.ExecuteAsync(id, HttpContext.RequestAborted));
        }

        [HttpPut]
        public async Task<IActionResult> EditApplicationDraft(ConfApplicationDraftDTO confApplicationDraftDTO)
        {
            return Ok(await editConfAppDraftUseCase.ExecuteAsync(confApplicationDraftDTO, HttpContext.RequestAborted));
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

