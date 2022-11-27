using Microsoft.AspNetCore.Mvc;

namespace MovieexApi.Domain.Helpers
{
    public class BaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BaseController(AppDbContext context)
        {
            _context = context;
        }
    }
}