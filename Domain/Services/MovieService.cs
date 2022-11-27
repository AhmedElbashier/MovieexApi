using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Services
{
    public interface IMovieService
    {
        Movie GetMovie(string id);
        List<MovieDto> GetALl();
        Movie CreateMovie(MovieDto MovieDto);
    }
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _MovieRepository;

        public MovieService(IMovieRepository MovieRepository)
        {
            _MovieRepository = MovieRepository;    
        }
        
       
        public Movie GetMovie(string id)
        {
            return _MovieRepository.GetMovie(id);
        }

        public Movie CreateMovie(MovieDto MovieDto)
        {
            return _MovieRepository.CreateMovie(MovieDto);
        }
        public List<MovieDto> GetALl()
        {
            return _MovieRepository.GetAll().Select(_MovieRepository.ToMovieDto).ToList();
        }
      
       
    }
}