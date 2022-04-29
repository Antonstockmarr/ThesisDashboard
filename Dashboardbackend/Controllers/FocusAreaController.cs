using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Models;
using Dashboardbackend.Data;
using AutoMapper;
using Dashboardbackend.Dtos;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/focusAreas")]
    [ApiController]
    public class FocusAreaController : ControllerBase
    {
        private readonly IfocusAreaRepository _repository;
        private readonly IMapper _mapper;

        public FocusAreaController(IfocusAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<FocusAreaController>
        [HttpGet]
        public ActionResult <IEnumerable<FocusAreaReadDto>> GetAllFocusArea()
        {
            var focusAreas = _repository.GetAllFocusAreas();
            return Ok(_mapper.Map<IEnumerable<FocusAreaReadDto>>(focusAreas));
        }

        // GET api/<FocusAreaController>/5
        [HttpGet("{id}")]
        public ActionResult <FocusAreaReadDto> GetFocusAreaById(int id)
        {
            var FocusArea = _repository.GetFocusAreaById(id);
            if (FocusArea != null)
            {
                return Ok(_mapper.Map<FocusAreaReadDto>(FocusArea));

            }

            return NotFound();
        }

    }
}
