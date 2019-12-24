using System;
using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.Backend.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;
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

        public OccasionController(IUiClient uiClient, OccasionSmallCardMapper smallCardMapper, OccasionFullCardMapper fullCardMapper)
        {
            _uiClient = uiClient;
            _smallCardMapper = smallCardMapper;
            _fullCardMapper = fullCardMapper;
        }

        [HttpGet]
        public IEnumerable<OccasionSmallCardDto> GetHistory()
        {
            return _uiClient.GetHistory().Select(x => _smallCardMapper.ToDto(x));
        }

        [HttpGet]
        public OccasionFullCardDto GetOccasionCard()
        {
            throw new NotImplementedException();
        }


    }
}