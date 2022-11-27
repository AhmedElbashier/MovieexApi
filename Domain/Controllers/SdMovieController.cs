using Microsoft.AspNetCore.Mvc;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieexApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SdMovieController : ControllerBase
    {
        private readonly ISdMovieService _SdmovieService;
        private readonly AppDbContext _context;

        public SdMovieController(ISdMovieService SdmovieService)
        {
            _SdmovieService = SdmovieService;
        }

        [HttpGet]
        public IActionResult GetSdMovies()
        {
            var Sdmovies = _SdmovieService.GetALl();
            return Ok(Sdmovies);
        }
        [HttpGet("{id}")]
        public ActionResult<SdMovie> GetSdMovie(string id)
        {
            var movie = _SdmovieService.GetSdMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
     [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(string id, SdMovie SdMovie)
        {
            if (id != SdMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(SdMovie).State = EntityState.Modified;

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
        public IActionResult CreateSdMovie(SdMovieDto SdMovieDto)
        {
            var SdMovie = _SdmovieService.CreateSdMovie(SdMovieDto);
            return Ok(SdMovie);
        }
              private bool MovieExists(string id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}