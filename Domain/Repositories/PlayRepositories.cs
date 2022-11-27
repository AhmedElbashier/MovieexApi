using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface IPlayRepository
    {
        List<Play> GetAll();
        Play Find(int id);
        Play CreatePlay(PlayDto PlayDto);
        PlayDto ToPlayDto(Play Play);
        Play GetPlay(string id);

    }

    public class PlayRepository : IPlayRepository
    {
        private readonly AppDbContext _context;
        public PlayRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Play> GetAll()
        {
            return _context.Plays.ToList();
        }

        public Play Find(int id)
        {
            return _context.Plays.Find(id);
        }

        public Play CreatePlay(PlayDto PlayDto)
        {   
            
            var Play = ToPlay(PlayDto);
            Play.Id= Guid.NewGuid().ToString();   
            _context.Plays.Add(Play);
            this._context.SaveChanges();
            return Play;
        }

        private Play ToPlay(PlayDto PlayDto)
        {
            return new Play
            {   
                 Id = PlayDto.Id,
                Backdrop_path= PlayDto.Backdrop_path,
                Genre= PlayDto.Genre,
                Overview= PlayDto.Overview,
                Poster= PlayDto.Poster,
                Language= PlayDto.Language,
                Status = PlayDto.Status,
                Vote_average= PlayDto.Vote_average,
                Available= PlayDto.Available,
                Budget= PlayDto.Budget,
                Revenue= PlayDto.Revenue,
                Runtime=PlayDto.Runtime,
                Release_date= PlayDto.Release_date,
                Cast= PlayDto.Cast,
                Video = PlayDto.Video,
                Title= PlayDto.Title

            };
        }

        public PlayDto ToPlayDto(Play Play)
        {
            return new PlayDto
            {
                 
                 Id = Play.Id,
                Backdrop_path= Play.Backdrop_path,
                Genre= Play.Genre,
                Overview= Play.Overview,
                Poster= Play.Poster,
                Language= Play.Language,
                Status = Play.Status,
                Vote_average= Play.Vote_average,
                Available= Play.Available,
                Budget= Play.Budget,
                Revenue= Play.Revenue,
                Runtime=Play.Runtime,
                Release_date= Play.Release_date,
                Cast= Play.Cast,
                Video = Play.Video,
                Title= Play.Title
               
            };
        }
          public Play GetPlay(string id)
        {
            return _context.Plays.Find(id);
        }
         public List<Play> GetALL()
        {
            return _context.Plays.ToList();
        }
    }
}