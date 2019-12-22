using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JiraLikeYou.Backend.Dto;
using JiraLikeYou.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JiraLikeYou.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService, IMapper mapper)
        {
            _historyService = historyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<HistoryDto> Get()
        {
            return _mapper.Map<IEnumerable<HistoryDto>>(_historyService.GetHistory());
        }
    }
}