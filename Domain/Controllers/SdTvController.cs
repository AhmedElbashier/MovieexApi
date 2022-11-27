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
    public class SdTvController : ControllerBase
    {
        private readonly ISdTvService _SdTvService;
        private readonly AppDbContext _context;

        public SdTvController(ISdTvService SdTvService)
        {
            _SdTvService = SdTvService;
        }

        [HttpGet]
        public IActionResult GetSdTvs()
        {
            var SdTvs = _SdTvService.GetALl();
            return Ok(SdTvs);
        }
        [HttpGet("{id}")]
        public ActionResult<SdTv> GetSdTv(string id)
        {
            var tv = _SdTvService.GetSdTv(id);

            if (tv == null)
            {
                return NotFound();
            }

            return Ok(tv);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTv(string id, SdTv SdTv)
        {
            if (id != SdTv.Id)
            {
                return BadRequest();
            }

            _context.Entry(SdTv).State = EntityState.Modified;

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
        public IActionResult CreateSdTv(SdTvDto SdTvDto)
        {
            var SdTv = _SdTvService.CreateSdTv(SdTvDto);
            return Ok(SdTv);
        }
                private bool TvExists(string id)
        {
            return _context.SdTvs.Any(e => e.Id == id);
        }
    }
}