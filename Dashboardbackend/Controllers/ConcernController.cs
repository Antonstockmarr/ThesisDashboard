using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/concerns")]
    [ApiController]
    public class ConcernController : ControllerBase
    {
        private readonly IConcernService _service;
        private readonly IMapper _mapper;

        public ConcernController(IConcernService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult <IEnumerable<ConcernReadDto>> GetAllConcerns()
        {
            var concerns = _service.GetConcerns();
            return Ok(_mapper.Map<IEnumerable<ConcernReadDto>>(concerns));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <ConcernReadDto> GetConcernByID(int id)
        {
            var concern = _service.GetConcernById(id);
            if (concern != null)
            {
                return Ok(_mapper.Map<ConcernReadDto>(concern));
            }

            return NotFound();
        }
    }
}
