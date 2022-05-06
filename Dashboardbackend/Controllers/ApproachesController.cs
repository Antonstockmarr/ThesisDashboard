using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboardbackend.Data.ApproachRepo;
using AutoMapper;
using Dashboardbackend.Dtos;

namespace Dashboardbackend.Controllers
{
    [Route("api/approaches")]
    [ApiController]
    public class ApproachesController : ControllerBase
    {
        private readonly IApproachRepository _repository;
        private readonly IMapper _mapper;

        public ApproachesController(IApproachRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Approaches
        [HttpGet]
        public  ActionResult<IEnumerable<ApproachReadDto>> Getapproaches()
        {
            var approaches =  _repository.GetAllApproach();
            return Ok(_mapper.Map<IEnumerable<ApproachReadDto>>(approaches));
        }

        // GET: api/Approaches/5
        [HttpGet("{id}")]
        public  ActionResult<ApproachReadDto> GetApproach(int id)
        {
            var approach = _repository.GetApproachByID(id);

            if (approach != null)
            {
                return Ok(_mapper.Map<ApproachReadDto>(approach));
            }

            return NotFound();
        }
    }
}
