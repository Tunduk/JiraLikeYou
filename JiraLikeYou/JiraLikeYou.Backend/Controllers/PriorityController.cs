using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriorityController:Controller
    {
        private readonly IPriorityService _priorityService;
        public PriorityController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        //[HttpGet]
        //public IEnumerable<PriorityDto> GetAll()
        //{
            
        //}
    }
}