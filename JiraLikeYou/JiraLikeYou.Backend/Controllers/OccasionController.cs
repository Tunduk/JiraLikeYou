using System;
using System.Collections.Generic;
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
        private readonly IUiClient _some;

        public OccasionController(IUiClient some)
        {
            _some = some;
        }

        [HttpGet]
        public IEnumerable<OccasionSmallCardDto> GetHistory()
        {
            return _some.GetHistory();
        }

        [HttpGet]
        public OccasionFullCardDto GetOccasionCard()
        {
            throw new NotImplementedException();
        }


    }
}