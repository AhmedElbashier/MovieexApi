using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace MovieexApi.Domain.Models
{
public class Play
    {
        public string Id { get; set; }
        public string Backdrop_path { get; set; }
        public int Budget { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Overview { get; set; }
        public string Poster { get; set; }
        public DateTime Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Cast { get; set; }
        public string Video { get; set; }
        public double Vote_average { get; set; }
        public bool Available { get; set; }

    }


}