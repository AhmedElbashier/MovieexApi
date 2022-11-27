using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface ITvRepository
    {
        List<Tv> GetAll();
        Tv Find(int id);
        Tv CreateTv(TvDto TvDto);
        TvDto ToTvDto(Tv Tv);
        Tv GetTv(string id);

    }

    public class TvRepository : ITvRepository
    {
        private readonly AppDbContext _context;
        public TvRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Tv> GetAll()
        {
            return _context.Tvs.ToList();
        }

        public Tv Find(int id)
        {
            return _context.Tvs.Find(id);
        }

        public Tv CreateTv(TvDto TvDto)
        {   
            for(int k = 0 ; k < TvDto.Production_countries.Count; k ++)
            TvDto.Production_countries[k].Id= Guid.NewGuid().ToString();   
            for(int i = 0 ; i < TvDto.Networks.Count ; i ++)
            TvDto.Networks[i].Id= Guid.NewGuid().ToString();         
            for(int i = 0 ; i < TvDto.Spoken_languages.Count ; i ++)
            TvDto.Spoken_languages[i].Id= Guid.NewGuid().ToString();                
            var Tv = ToTv(TvDto);
            _context.Tvs.Add(Tv);
            this._context.SaveChanges();
            return Tv;
        }

        private Tv ToTv(TvDto TvDto)
        {
            return new Tv
            {   
                Id = TvDto.Id,
                Adult = TvDto.Adult,
                Backdrop_path= TvDto.Backdrop_path,
                Created_by = TvDto.Created_by,
                Episode_run_time= TvDto.Episode_run_time,
                First_air_date = TvDto.First_air_date,
                Genres= TvDto.Genres   ,
                Homepage = TvDto.Homepage,
                In_production= TvDto.In_production,
                Languages = TvDto.Languages,
                Last_air_date= TvDto.Last_air_date,
                Last_episode_to_air = TvDto.Last_episode_to_air,
                Name= TvDto.Name,
                Next_episode_to_air = TvDto.Next_episode_to_air,
                Networks= TvDto.Networks,
                Number_of_episodes = TvDto.Number_of_episodes,
                Number_of_seasons= TvDto.Number_of_seasons,
                Origin_country = TvDto.Origin_country,
                Original_language= TvDto.Original_language,
                Original_name = TvDto.Original_name,
                Overview= TvDto.Overview,
                Popularity = TvDto.Popularity,
                Poster_path= TvDto.Poster_path,
                Production_companies = TvDto.Production_companies,
                Production_countries= TvDto.Production_countries,
                Seasons = TvDto.Seasons,
                Spoken_languages= TvDto.Spoken_languages,
                Status = TvDto.Status,
                Tagline= TvDto.Tagline,
                Type = TvDto.Type,
                Vote_average= TvDto.Vote_average,
                Vote_count = TvDto.Vote_count,
                Available= TvDto.Available,
            };
        }

        public TvDto ToTvDto(Tv Tv)
        {
            return new TvDto
            {
               Id = Tv.Id,
                Adult = Tv.Adult,
                Backdrop_path= Tv.Backdrop_path,
                Created_by = Tv.Created_by,
                Episode_run_time= Tv.Episode_run_time,
                First_air_date = Tv.First_air_date,
                Genres= Tv.Genres   ,
                Homepage = Tv.Homepage,
                In_production= Tv.In_production,
                Languages = Tv.Languages,
                Last_air_date= Tv.Last_air_date,
                Last_episode_to_air = Tv.Last_episode_to_air,
                Name= Tv.Name,
                Next_episode_to_air = Tv.Next_episode_to_air,
                Networks= Tv.Networks,
                Number_of_episodes = Tv.Number_of_episodes,
                Number_of_seasons= Tv.Number_of_seasons,
                Origin_country = Tv.Origin_country,
                Original_language= Tv.Original_language,
                Original_name = Tv.Original_name,
                Overview= Tv.Overview,
                Popularity = Tv.Popularity,
                Poster_path= Tv.Poster_path,
                Production_companies = Tv.Production_companies,
                Production_countries= Tv.Production_countries,
                Seasons = Tv.Seasons,
                Spoken_languages= Tv.Spoken_languages,
                Status = Tv.Status,
                Tagline= Tv.Tagline,
                Type = Tv.Type,
                Vote_average= Tv.Vote_average,
                Vote_count = Tv.Vote_count,
                Available= Tv.Available,
               
            };
        }
          public Tv GetTv(string id)
        {
            return _context.Tvs.Find(id);
        }
         public List<Tv> GetALL()
        {
            return _context.Tvs.ToList();
        }
    }
}