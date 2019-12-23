using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraLikeYou.Backend.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        public WebhooksController()
        {
        }

        [HttpPost("{jira}")]
        public void TicketUpdate([FromBody] JiraWebhookResponseDto updateDto)
        {
            var a = updateDto;
        }
    }
}