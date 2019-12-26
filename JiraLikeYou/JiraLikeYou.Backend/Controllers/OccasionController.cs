using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraLikeYou.Backend.Hubs;
using JiraLikeYou.Backend.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OccasionFullCardDto = JiraLikeYou.Backend.Dto.OccasionFullCardDto;
using OccasionSmallCardDto = JiraLikeYou.Backend.Dto.OccasionSmallCardDto;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        private readonly IUiClient _uiClient;
        private readonly OccasionSmallCardMapper _smallCardMapper;
        private readonly OccasionFullCardMapper _fullCardMapper;
        private readonly IHubContext<OccasionHub, IOccasionHub> _hub;

        public OccasionController(IUiClient uiClient,
            OccasionSmallCardMapper smallCardMapper,
            OccasionFullCardMapper fullCardMapper,
            IHubContext<OccasionHub, IOccasionHub> hub)
        {
            _uiClient = uiClient;
            _smallCardMapper = smallCardMapper;
            _fullCardMapper = fullCardMapper;
            _hub = hub;
        }

        [HttpGet]
        public IEnumerable<OccasionSmallCardDto> GetHistory()
        {
            return _uiClient.GetHistory().Select(x => _smallCardMapper.ToDto(x));
        }

        [HttpGet("card")]
        public OccasionFullCardDto GetLastCard()
        {
            return _fullCardMapper.ToDto(_uiClient.GetLastCard());   
        }

        [HttpPost("send")]
        public async Task SendNewCard(OccasionFullCard fullCard)
        {
            await _hub.Clients.All.Send(_fullCardMapper.ToDto(fullCard));
        }
    }
}