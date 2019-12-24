using JiraLikeYou.Backend.Dto;
using JiraLikeYou.Backend.Mappers;
using JiraLikeYou.BLL.Integration;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        private readonly IJiraClient _jiraClient;
        private readonly JiraWebhookResponseMapper _jiraWebhookResponseMapper;

        public WebhooksController(IJiraClient jiraClient, JiraWebhookResponseMapper jiraWebhookResponseMapper)
        {
            _jiraClient = jiraClient;
            _jiraWebhookResponseMapper = jiraWebhookResponseMapper;
        }

        [HttpPost("{jira}")]
        public void TicketUpdate([FromBody] JiraWebhookResponseDto updateDto)
        {
            _jiraClient.HandleWebhookResponse(_jiraWebhookResponseMapper.ToBll(updateDto));
        }
    }
}