using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieexApi.Domain.Models
{
public class Movie
    {
        public string Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public string Belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public string Imdb_id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public List<ProductionCompany> Production_companies { get; set; }
        public List<ProductionCountry> Production_countries { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguage> Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
        public bool Available { get; set; }

    }

public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Logo_path { get; set; }
        public string Name { get; set; }
        public string Origin_country { get; set; }
    }

    public class ProductionCountry
    {
        public string Id { get; set; }
        public string Iso_3166_1 { get; set; }
        public string Name { get; set; }
    }

    public class SpokenLanguage
    {
        public string Id { get; set; }
        public string English_name { get; set; }
        public string Iso_639_1 { get; set; }
        public string Name { get; set; }
    }
}