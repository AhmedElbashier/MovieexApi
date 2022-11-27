using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie Find(int id);
        Movie CreateMovie(MovieDto MovieDto);
        MovieDto ToMovieDto(Movie Movie);
        Movie GetMovie(string id);

    }

    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie Find(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movie CreateMovie(MovieDto MovieDto)
        {   
            for(int i = 0; i< MovieDto.Spoken_languages.Count ; i++)
            MovieDto.Spoken_languages[i].Id=Guid.NewGuid().ToString();
            var Movie = ToMovie(MovieDto);
            _context.Movies.Add(Movie);
            this._context.SaveChanges();
            return Movie;
        }

        private Movie ToMovie(MovieDto MovieDto)
        {
            return new Movie
            {   

                Id = MovieDto.Id,
                Title= MovieDto.Title,
                Adult = MovieDto.Adult,
                Backdrop_path= MovieDto.Backdrop_path,
                Belongs_to_collection = MovieDto.Belongs_to_collection,
                Budget= MovieDto.Budget,
                Genres = MovieDto.Genres,
                Homepage= MovieDto.Homepage,
                Imdb_id = MovieDto.Imdb_id,
                Original_language= MovieDto.Original_language,
                Original_title = MovieDto.Original_title,
                Overview= MovieDto.Overview,
                Popularity = MovieDto.Popularity,
                Poster_path= MovieDto.Poster_path,
                Production_companies = MovieDto.Production_companies,
                Release_date= MovieDto.Release_date,
                Revenue = MovieDto.Revenue,
                Runtime= MovieDto.Runtime,
                Spoken_languages = MovieDto.Spoken_languages,
                Status= MovieDto.Status,
                Tagline = MovieDto.Tagline,
                Video = MovieDto.Video,
                Vote_average= MovieDto.Vote_count,
                Vote_count = MovieDto.Vote_count,
                Available= MovieDto.Available, 
            };
        }

        public MovieDto ToMovieDto(Movie Movie)
        {
            return new MovieDto
            {
                Id = Movie.Id,
                Title= Movie.Title,
                Adult = Movie.Adult,
                Backdrop_path= Movie.Backdrop_path,
                Belongs_to_collection = Movie.Belongs_to_collection,
                Budget= Movie.Budget,
                Genres = Movie.Genres,
                Homepage= Movie.Homepage,
                Imdb_id = Movie.Imdb_id,
                Original_language= Movie.Original_language,
                Original_title = Movie.Original_title,
                Overview= Movie.Overview,
                Popularity = Movie.Popularity,
                Poster_path= Movie.Poster_path,
                Production_companies = Movie.Production_companies,
                Release_date= Movie.Release_date,
                Revenue = Movie.Revenue,
                Runtime= Movie.Runtime,
                Spoken_languages = Movie.Spoken_languages,
                Status= Movie.Status,
                Tagline = Movie.Tagline,
                Video = Movie.Video,
                Vote_average= Movie.Vote_count,
                Vote_count = Movie.Vote_count,
                Available= Movie.Available,               
            };
        }
        
          public Movie GetMovie(string id)
        {
            return _context.Movies.Find(id);
        }
         public List<Movie> GetALL()
        {
            return _context.Movies.ToList();
        }
    }
}