using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraLikeYou.Backend.Hubs;
using JiraLikeYou.Backend.Models.HubModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace JiraLikeYou.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHubContext<EventHub> _hub;
        public WeatherForecastController(IHubContext<EventHub> hub)
        {
            _hub = hub;
        }

        [HttpPost("send")]
        
        public async Task Send()
        {
            await _hub.Clients.All.SendAsync("NewJiraEvent", new JiraEvent() { MainMessage = "I Like you!" });
        }
        
    }
}
