using Microsoft.AspNetCore.Mvc;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Services;
using MovieexApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieexApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SdPlayController : ControllerBase
    {
        private readonly ISdPlayService _SdPlayService;
        private readonly AppDbContext _context;

        public SdPlayController(ISdPlayService SdPlayService)
        {
            _SdPlayService = SdPlayService;
        }

        [HttpGet]
        public IActionResult GetSdPlays()
        {
            var SdPlays = _SdPlayService.GetALl();
            return Ok(SdPlays);
        }
        [HttpGet("{id}")]
        public ActionResult<SdPlay> GetSdPlay(string id)
        {
            var movie = _SdPlayService.GetSdPlay(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(string id, SdPlay SdPlay)
        {
            if (id != SdPlay.Id)
            {
                return BadRequest();
            }

            _context.Entry(SdPlay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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
        public IActionResult CreateSdPlay(SdPlayDto SdPlayDto)
        {
            var SdPlay = _SdPlayService.CreateSdPlay(SdPlayDto);
            return Ok(SdPlay);
        }
                private bool MovieExists(string id)
        {
            return _context.SdPlays.Any(e => e.Id == id);
        }
    }
}