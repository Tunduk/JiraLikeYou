using System;
using System.Collections.Generic;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        private readonly ISomeThingForClient _some;

        public OccasionController(ISomeThingForClient some)
        {
            _some = some;
        }

        [HttpGet]
        public IEnumerable<OccasionSmallCard> GetHistory()
        {
            return _some.GetHistory();
        }

        [HttpGet]
        public OccasionFullCard GetOccasionCard()
        {
            throw new NotImplementedException();
        }


    }
}