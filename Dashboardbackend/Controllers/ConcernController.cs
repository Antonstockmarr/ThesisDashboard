using AutoMapper;
using Dashboardbackend.Data;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/concerns")]
    [ApiController]
    public class ConcernController : ControllerBase
    {
        private readonly IConcernRepository _repository;
        private readonly IMapper _mapper;

        public ConcernController(IConcernRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult <IEnumerable<ConcernReadDto>> GetAllConcerns()
        {
            var concerns = _repository.getAllConcerns();
            return Ok(_mapper.Map<IEnumerable<ConcernReadDto>>(concerns));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <ConcernReadDto> GetConcernByID(int id)
        {
            var concern = _repository.getConcernByID(id);
            if (concern != null)
            {
                return Ok(_mapper.Map<ConcernReadDto>(concern));
            }

            return NotFound();
        }
    }
}
