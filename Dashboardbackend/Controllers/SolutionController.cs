using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dashboardbackend.Data;
using Dashboardbackend.Models;
using Dashboardbackend.Data.ApproachRepo;
using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Services;

namespace Dashboardbackend.Controllers
{
    [Route("api/solution")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly IApproachRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISolutionService _solutionService;

        public SolutionController(IApproachRepository repository, ISolutionService solutionService, IMapper mapper)
        {
            _solutionService = solutionService;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ApproachTool>> GetSolution([FromQuery]List<int> approachIds)
        {

            List<Approach> approaches = new List<Approach>();
            foreach (int id in approachIds)
            {
                Approach approach = _repository.getApproachByID(id);
                if (approach is null)
                {
                    return NotFound();
                }
                else
                {
                    if (!approaches.Any(a => a.Id == approach.Id))
                    approaches.Add(approach);
                }
            }
            IEnumerable<ApproachTool> solution = _solutionService.ComputeSolution(approaches);
            return Ok(solution);

        }

    }
}
