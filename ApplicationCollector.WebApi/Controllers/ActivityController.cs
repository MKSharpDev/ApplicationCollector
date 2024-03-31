using ApplicationCollector.Application;
using ApplicationCollector.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCollector.WebApi.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetApplicationDraft()
        {
            List<Activity> activityList = new List<Activity>()
            {
                new Activity
                {
                    activity = "Report",
                    description = "Доклад, 35-45 минут"
                },
                new Activity
                {
                    activity = "Masterclass",
                    description = "Мастеркласс, 1-2 часа"
                },
                new Activity
                {
                    activity = "Discussion",
                    description = "Дискуссия / круглый стол, 40-50 минут"
                }
            };
            return Ok(activityList);

        }
    }
}
