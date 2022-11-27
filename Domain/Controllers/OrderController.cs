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
using System.Collections.Generic;

namespace MovieexApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly AppDbContext _context;


        public OrderController(IOrderService OrderService, AppDbContext context)
        {
            _context = context;
            _OrderService = OrderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var Orders = _OrderService.GetALl();
            return Ok(Orders);
        }   
        [HttpGet("byId/{data}")]
        public IActionResult GetOrdersById(string data)
        {
            var Orders = _OrderService.GetALlOrdersById(data);
            return Ok(Orders);
        }

        [HttpGet("OrderDetails/{data}")]
        public IActionResult GetOrdersDetailsById(string data)
        {
            var Orders = _OrderService.GetALlOrdersDetailsById(data);
            return Ok(Orders);
        }
        
             [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var Order = _OrderService.GetOrder(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
         }

         [HttpPut("OrderDetails/{MovieId}")]
        public async Task<IActionResult> PutOrderDeatils(string MovieId, OrderDetails orderDetails)
        {
            Console.WriteLine(MovieId);
            Console.WriteLine(orderDetails.MovieId);   
            
            if (MovieId != orderDetails.MovieId)
            {
                return BadRequest();
            }
            
            _context.Entry(orderDetails).State = EntityState.Modified;

            try
            {   
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(MovieId))
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, Order Order)
        {
            Console.WriteLine(id);
            Console.WriteLine(Order.Id);   
            
            if (id != Order.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        public IActionResult CreateOrder(OrderDto OrderDto)
        {
            var Order = _OrderService.CreateOrder(OrderDto);
            return Ok(Order);
        }
                private bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
                 private bool OrderDetailsExists(string id)
        {
            return _context.OrderDetails.Any(e => e.MovieId == id);
        }
    }
}