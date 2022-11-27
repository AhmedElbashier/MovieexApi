using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface ISdMovieRepository
    {
        List<SdMovie> GetAll();
        SdMovie Find(int id);
        SdMovie CreateSdMovie(SdMovieDto SdMovieDto);
        SdMovieDto ToSdMovieDto(SdMovie SdMovie);
        SdMovie GetSdMovie(string id);

    }

    public class SdMovieRepository : ISdMovieRepository
    {
        private readonly AppDbContext _context;
        public SdMovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SdMovie> GetAll()
        {
            return _context.SdMovies.ToList();
        }

        public SdMovie Find(int id)
        {
            return _context.SdMovies.Find(id);
        }

        public SdMovie CreateSdMovie(SdMovieDto SdMovieDto)
        {   
          
            var SdMovie = ToSdMovie(SdMovieDto);
            SdMovie.Id= Guid.NewGuid().ToString();   
            _context.SdMovies.Add(SdMovie);
            this._context.SaveChanges();
            return SdMovie;
        }

        private SdMovie ToSdMovie(SdMovieDto SdMovieDto)
        {
            return new SdMovie
            {   
                Id = SdMovieDto.Id,
                Backdrop_path= SdMovieDto.Backdrop_path,
                Genre= SdMovieDto.Genre,
                Overview= SdMovieDto.Overview,
                Poster= SdMovieDto.Poster,
                Language= SdMovieDto.Language,
                Status = SdMovieDto.Status,
                Vote_average= SdMovieDto.Vote_average,
                Available= SdMovieDto.Available,
                Budget= SdMovieDto.Budget,
                Revenue= SdMovieDto.Revenue,
                Runtime=SdMovieDto.Runtime,
                Release_date= SdMovieDto.Release_date,
                Cast= SdMovieDto.Cast,
                Video = SdMovieDto.Video,
                Title= SdMovieDto.Title
                  };
        }

        public SdMovieDto ToSdMovieDto(SdMovie SdMovie)
        {
            return new SdMovieDto
            {
               
                 Id = SdMovie.Id,
                Backdrop_path= SdMovie.Backdrop_path,
                Genre= SdMovie.Genre,
                Overview= SdMovie.Overview,
                Poster= SdMovie.Poster,
                Language= SdMovie.Language,
                Status = SdMovie.Status,
                Vote_average= SdMovie.Vote_average,
                Available= SdMovie.Available,
                Budget= SdMovie.Budget,
                Revenue= SdMovie.Revenue,
                Runtime=SdMovie.Runtime,
                Release_date= SdMovie.Release_date,
                Cast= SdMovie.Cast,
                Video = SdMovie.Video,
                Title= SdMovie.Title
               
            };
        }
        
          public SdMovie GetSdMovie(string id)
        {
            return _context.SdMovies.Find(id);
        }
         public List<SdMovie> GetALL()
        {
            return _context.SdMovies.ToList();
        }
    }
}