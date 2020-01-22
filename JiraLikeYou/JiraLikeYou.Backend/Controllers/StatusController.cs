using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }


        //[HttpGet]
        //public IEnumerable<StatusDto> GetAll()
        //{
        //    return _statusService.GetAll().Select(x=>x);
        //}
    }
}