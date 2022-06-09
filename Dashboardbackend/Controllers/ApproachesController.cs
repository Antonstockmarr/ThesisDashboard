using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Services;

namespace Dashboardbackend.Controllers
{
    [Route("api/approaches")]
    [ApiController]
    public class ApproachesController : ControllerBase
    {
        private readonly IApproachService _service;
        private readonly IMapper _mapper;

        public ApproachesController(IApproachService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Approaches
        [HttpGet]
        public  ActionResult<IEnumerable<ApproachReadDto>> Getapproaches()
        {
            var approaches =  _service.GetApproaches();
            return Ok(_mapper.Map<IEnumerable<ApproachReadDto>>(approaches));
        }

        // GET: api/Approaches/5
        [HttpGet("{id}")]
        public  ActionResult<ApproachReadDto> GetApproach(int id)
        {
            if (!_service.ApproachExists(id))
            {
                return NotFound();
            }
            else
            {
                var approach = _service.GetApproachById(id);
                return Ok(_mapper.Map<ApproachReadDto>(approach));
            }
        }
    }
}
