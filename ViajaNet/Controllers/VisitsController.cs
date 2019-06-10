using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViajaNet.Application.Contracts;
using ViajaNet.Domain.DTOs;
using ViajaNet.Domain.Models;

namespace ViajaNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitQueueService _service;
        private readonly IMapper _mapper;
        public VisitsController(IVisitQueueService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]VisitDTO visit)
        {
            var visitDomain = _mapper.Map<Visit>(visit);
            this._service.AppendToQueue(visitDomain);
            return StatusCode(201);
        }
    }
}