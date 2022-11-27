using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;


namespace MovieexApi.Domain.Services
{
    public interface IOrderService
    {
        Order GetOrder(string id);
        List<OrderDto> GetALl();
        List<OrderDto> GetALlOrdersById(string data);
        List<OrderDetailsDto> GetALlOrdersDetailsById(string data);
        Order CreateOrder(OrderDto OrderDto);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;    
        }
        
       

        public Order GetOrder(string id)
        {
            return _OrderRepository.GetOrder(id);
        }
         public List<OrderDto> GetALl()
        {
            return _OrderRepository.GetAll().Select(_OrderRepository.ToOrderDto).ToList();
        }
         public List<OrderDto> GetALlOrdersById(string data)
        {

            return _OrderRepository.GetAllOrdersById(data).Select(_OrderRepository.ToOrderDto).ToList();
        }
        public List<OrderDetailsDto> GetALlOrdersDetailsById(string data)
        {

            return _OrderRepository.GetAllOrdersDetailsById(data).Select(_OrderRepository.ToOrderDetailsDto).ToList();
        }

        public Order CreateOrder(OrderDto OrderDto)
        {
            return _OrderRepository.CreateOrder(OrderDto);
        }

       
    }
}