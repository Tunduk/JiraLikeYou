using JiraLikeYou.Backend.Dto;
using JiraLikeYou.Backend.Hubs;
using JiraLikeYou.Backend.Mappers;
using JiraLikeYou.BLL.Integration;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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

        public WebhooksController(IJiraClient jiraClient, JiraWebhookResponseMapper jiraWebhookResponseMapper, OccasionFullCardMapper occasionFullCardMapper, 
            IUiClient uiClient,
            IHubContext<OccasionHub, IOccasionHub> hub)
        {
            _jiraClient = jiraClient;
            _jiraWebhookResponseMapper = jiraWebhookResponseMapper;
            _fullCardMapper = occasionFullCardMapper;
            _uiClient = uiClient;
            _hub = hub;

        }

        [HttpPost("{jira}")]
        public StatusCodeResult TicketUpdate([FromBody] JiraWebhookResponseDto updateDto)
        {
            
            _jiraClient.HandleWebhookResponse(_jiraWebhookResponseMapper.ToBll(updateDto));
            _hub.Clients.All.Send(_fullCardMapper.ToDto(_uiClient.GetLastCard()));
            return StatusCode(200);
        }
    }
}