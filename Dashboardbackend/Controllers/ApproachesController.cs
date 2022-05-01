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
            var approaches =  _repository.getAllApproach();
            return Ok(_mapper.Map<IEnumerable<ApproachReadDto>>(approaches));
        }

        // GET: api/Approaches/5
        [HttpGet("{id}")]
        public  ActionResult<ApproachReadDto> GetApproach(int id)
        {
            var approach = _repository.getApproachByID(id);

            if (approach != null)
            {
                return Ok(_mapper.Map<ApproachReadDto>(approach));
            }

            return NotFound();
        }

        //// PUT: api/Approaches/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutApproach(int id, Approach approach)
        //{
        //    if (id != approach.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(approach).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ApproachExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Approaches
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Approach>> PostApproach(Approach approach)
        //{
        //    _context.approaches.Add(approach);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetApproach", new { id = approach.Id }, approach);
        //}

        //// DELETE: api/Approaches/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteApproach(int id)
        //{
        //    var approach = await _context.approaches.FindAsync(id);
        //    if (approach == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.approaches.Remove(approach);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ApproachExists(int id)
        //{
        //    return _context.approaches.Any(e => e.Id == id);
        //}
    }
}
