using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieexApi.Domain.Models
{
public class Order
    {
        [Key]
        public string Id { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string PosterPath { get; set; }
        public double Amount {get;set;}
        public List<OrderDetails> OrderDetails { get; set; }

    }
    public class OrderDetails
    {    
        public string Id {get;set;}
        public string OrderId {get;set;}
        public string MovieId {get; set;}
        public string MovieType {get; set;}
        public string Deleted {get; set;}
    }
}


        
