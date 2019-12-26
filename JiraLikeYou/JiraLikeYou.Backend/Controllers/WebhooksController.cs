using System;
using System.IO;
using System.Threading.Tasks;
using JiraLikeYou.Backend.Dto;
using JiraLikeYou.Backend.Hubs;
using JiraLikeYou.Backend.Mappers;
using JiraLikeYou.BLL.Integration;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        private readonly IJiraClient _jiraClient;
        private readonly JiraWebhookResponseMapper _jiraWebhookResponseMapper;
        private readonly OccasionFullCardMapper _fullCardMapper;
        private readonly IUiClient _uiClient;
        private readonly IHubContext<OccasionHub, IOccasionHub> _hub;
        private readonly ILogger<WebhooksController> _logger;

        public WebhooksController(IJiraClient jiraClient, JiraWebhookResponseMapper jiraWebhookResponseMapper, OccasionFullCardMapper occasionFullCardMapper, 
            IUiClient uiClient,
            IHubContext<OccasionHub, IOccasionHub> hub,
            ILogger<WebhooksController> logger)
        {
            _jiraClient = jiraClient;
            _jiraWebhookResponseMapper = jiraWebhookResponseMapper;
            _fullCardMapper = occasionFullCardMapper;
            _uiClient = uiClient;
            _hub = hub;
            _logger = logger;
        }

        [HttpPost("{jira}")]
        public async Task<StatusCodeResult> TicketUpdate([FromBody]JiraWebhookResponseDto updateDto)
        {

            var stream = this.HttpContext.Request.Body;
            stream.Position = 0;
            using (var reader = new StreamReader(stream))
            {
                string body = reader.ReadToEnd();
                _logger.LogInformation(body);
            }


            
            _jiraClient.HandleWebhookResponse(_jiraWebhookResponseMapper.ToBll(updateDto));
            await _hub.Clients.All.Send(_fullCardMapper.ToDto(_uiClient.GetLastCard()));
            return StatusCode(200);
        }
    }
}