using Microsoft.AspNetCore.Mvc;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Services;
using MovieexApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;

namespace MovieexApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMovieService _movieService;

        public MovieController(AppDbContext context, IMovieService movieService)
        {
            _context = context;
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetALl();
            return Ok(movies);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(string id)
        {
            var movie = _movieService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(string id, Movie Movie)
        {
            if (id != Movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(Movie).State = EntityState.Modified;

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
        public IActionResult CreateMovie(MovieDto MovieDto)
        {
            var Movie = _movieService.CreateMovie(MovieDto);
            return Ok(Movie);
        }

                private bool MovieExists(string id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}