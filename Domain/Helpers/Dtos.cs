using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Helpers
{
public class MovieDto
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


    public class SdMovieDto
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

        public class TvDto
    {
                public string Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public List<CreatedBy> Created_by { get; set; }
        public List<EposideRunTime> Episode_run_time { get; set; }
        public string First_air_date { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public bool In_production { get; set; }
        public List<Languages> Languages { get; set; }
        public string Last_air_date { get; set; }
        public LastEpisodeToAir Last_episode_to_air { get; set; }
        public string Name { get; set; }
        public string Next_episode_to_air { get; set; }
        public List<Network> Networks { get; set; }
        public int Number_of_episodes { get; set; }
        public int Number_of_seasons { get; set; }
        public List<Countries> Origin_country { get; set; }
        public string Original_language { get; set; }
        public string Original_name { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public List<ProductionCompany> Production_companies { get; set; }
        public List<ProductionCountry> Production_countries { get; set; }
        public List<Season> Seasons { get; set; }
        public List<SpokenLanguage> Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Type { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
        public bool Available { get; set; }

    }

        public class SdTvDto
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
    public class PlayDto
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
        public class SdPlayDto
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
    public class OrderDto
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Status{get; set;}
        public string PosterPath { get; set; }
        public double Amount {get;set;}

        public List<OrderDetails> OrderDetails { get; set; } 
    }

    public class OrderDetailsDto
    {
        public string Id {get;set;}
        public string OrderId {get;set;}
        public string MovieId {get; set;}
        public string MovieType {get; set;}
        public string Deleted {get; set;}

    }


}