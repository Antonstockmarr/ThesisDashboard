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
    [Route("api/concern")]
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
        public ActionResult <IEnumerable<Concern>> GetAllConcerns()
        {
            var concern = _repository.getAllConcerns();
            return Ok(concern);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <ConcernReadDto> GetConcernByID(int id)
        {
            var conern = _repository.getConcernByID(id);
            if (conern != null)
            {
                return Ok(_mapper.Map<ConcernReadDto>(conern));
            }

            return NotFound();
        }
    }
}
