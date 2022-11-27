using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieexApi.Domain.Models
{
    public class Tv
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
        public class CreatedBy
    {
        public string Id { get; set; }
        public string Credit_id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Profile_path { get; set; }
    }

    public class LastEpisodeToAir
    {
        public string Id { get; set; }
        public string Air_date { get; set; }
        public int Rpisode_number { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Production_code { get; set; }
        public int Season_number { get; set; }
        public string Still_path { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
    }

    public class Network
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Logo_path { get; set; }
        public string Origin_country { get; set; }
    }

    public class Season
    {
        public string Id { get; set; }
        public string Air_date { get; set; }
        public int Episode_count { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Poster_path { get; set; }
        public int Season_number { get; set; }
    }

    public class EposideRunTime
    {
        public string Id {get;set;}
        int Runtime {get;set;}
    }
    public class Languages
    {
        public string Id {get;set;}
        string Language {get;set;}
    }
    public class Countries
    {
        public string Id {get;set;}
        string Country {get;set;}
    }

}
