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
    public class PlayController : ControllerBase
    {
        private readonly IPlayService _PlayService;
        private readonly AppDbContext _context;

        public PlayController(IPlayService PlayService)
        {
            _PlayService = PlayService;
        }

        [HttpGet]
        public IActionResult GetPlays()
        {
            var Plays = _PlayService.GetALl();
            return Ok(Plays);
        }
        [HttpGet("{id}")]
        public ActionResult<Play> GetPlay(string id)
        {
            var movie = _PlayService.GetPlay(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(string id, Play Play)
        {
            if (id != Play.Id)
            {
                return BadRequest();
            }

            _context.Entry(Play).State = EntityState.Modified;

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
        public IActionResult CreatePlay(PlayDto PlayDto)
        {
            var Play = _PlayService.CreatePlay(PlayDto);
            return Ok(Play);
        }
                private bool MovieExists(string id)
        {
            return _context.Plays.Any(e => e.Id == id);
        }
    }
}