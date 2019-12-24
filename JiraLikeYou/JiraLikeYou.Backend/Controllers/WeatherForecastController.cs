using System.Threading.Tasks;
using JiraLikeYou.Backend.Dto.HubModels;
using JiraLikeYou.Backend.Hubs;
using JiraLikeYou.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JiraLikeYou.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHubContext<EventHub> _hub;
        private readonly IUserRepository _userRepository;

        public WeatherForecastController(IHubContext<EventHub> hub, IUserRepository userRepository)
        {
            _hub = hub;
            _userRepository = userRepository;
            
        }

        [HttpPost("send")]
        
        public async Task Send()
        {
            await _hub.Clients.All.SendAsync("NewJiraEvent", new JiraEvent() { MainMessage = "I Like you!" });
        }

        [HttpGet("get")]
        public string Get()
        {
            return _userRepository.Get("test")?.ToString();
        }
        
    }
}
