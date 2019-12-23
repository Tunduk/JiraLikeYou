using System;
using System.Collections.Generic;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ISomeThingForClient _some;

        public EventController(ISomeThingForClient some)
        {
            _some = some;
        }

        [HttpGet]
        public IEnumerable<EventSmallCard> GetHistory()
        {
            return _some.GetHistory();
        }

        [HttpGet]
        public EventFullCard GetEventCard()
        {
            throw new NotImplementedException();
        }


    }
}