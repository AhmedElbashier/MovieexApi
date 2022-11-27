using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface IOrderRepository
    {
        ICollection<Order> GetAll();
        ICollection<Order> GetAllOrdersById(string data);
        ICollection<OrderDetails> GetAllOrdersDetailsById(string data);
        Order Find(int id);
        Order CreateOrder(OrderDto OrderDto);
        OrderDto ToOrderDto(Order Order);
        OrderDetailsDto ToOrderDetailsDto(OrderDetails orderDetails);
        Order GetOrder(string id);

    }

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
        public ICollection<Order> GetAllOrdersById(string data)
        {
            
            var userOrders = _context.Orders
                               .Where(t => data.Contains(t.Id)& t.Status!="deleted");
            return userOrders.ToList();

        }
        public ICollection<OrderDetails> GetAllOrdersDetailsById(string data)
        {
            
            var userOrders = _context.OrderDetails
                               .Where(t => data.Contains(t.OrderId)& t.Deleted !="deleted");
            return userOrders.ToList();

        }

        public Order Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public Order CreateOrder(OrderDto OrderDto)
        {  
           Console.WriteLine( OrderDto.Id); 
            var Order = ToOrder(OrderDto);
            _context.Orders.Add(Order);
            _context.SaveChanges();      
            return Order;
        }

        private Order ToOrder(OrderDto OrderDto)
        {
            return new Order
            {   

                  Id = OrderDto.Id,
                Date = OrderDto.Date,
                Status = OrderDto.Status,
                Amount = OrderDto.Amount,
                PosterPath = OrderDto.PosterPath,
                OrderDetails = OrderDto.OrderDetails,
               
            };
        }

        public OrderDto ToOrderDto(Order Order)
        {
            return new OrderDto
            {
                Id = Order.Id,
                Date = Order.Date,
                PosterPath = Order.PosterPath,
                Status = Order.Status,
                Amount = Order.Amount,
                OrderDetails = Order.OrderDetails,              
            };
        }
         private OrderDetails ToOrderDetails(OrderDetailsDto OrderDetailsDto)
        {
            return new OrderDetails
            {   
                Id = OrderDetailsDto.Id,
                OrderId = OrderDetailsDto.OrderId,
                MovieId = OrderDetailsDto.MovieId,
                MovieType = OrderDetailsDto.MovieType,
                Deleted = OrderDetailsDto.Deleted,
                  
               
            };
        }

        public OrderDetailsDto ToOrderDetailsDto(OrderDetails OrderDetails)
        {
            return new OrderDetailsDto
            {
               
                Id = OrderDetails.Id,
                OrderId = OrderDetails.OrderId,
                MovieId = OrderDetails.MovieId,           
                MovieType = OrderDetails.MovieType,  
                Deleted = OrderDetails.Deleted,
            
                 };
            
             }
        
          public Order GetOrder(string id)
        {
            return _context.Orders.Find(id);
        }
        
    }
}