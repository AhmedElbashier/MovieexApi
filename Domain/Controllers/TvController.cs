using Microsoft.AspNetCore.Mvc;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Services;
using MovieexApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;
using System;

namespace MovieexApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TvController : ControllerBase
    {
        private readonly ITvService _TvService;
        private readonly AppDbContext _context;


        public TvController(ITvService TvService, AppDbContext context)
        {
            _context = context;
            _TvService = TvService;
        }

        [HttpGet]
        public IActionResult GetTvs()
        {
            var Tvs = _TvService.GetALl();
            return Ok(Tvs);
        }
             [HttpGet("{id}")]
        public ActionResult<Tv> GetTv(string id)
        {
            var tv = _TvService.GetTv(id);

            if (tv == null)
            {
                return NotFound();
            }

            return Ok(tv);
         }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutTv(string id, Tv tv)
        {
            Console.WriteLine(id);
            Console.WriteLine(tv.Name);   
            
            if (id != tv.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(tv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TvExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateTv(TvDto TvDto)
        {
            var Tv = _TvService.CreateTv(TvDto);
            return Ok(Tv);
        }
                private bool TvExists(string id)
        {
            return _context.Tvs.Any(e => e.Id == id);
        }
    }
}