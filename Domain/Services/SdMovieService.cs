using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Services
{
    public interface ISdMovieService
    {
        SdMovie GetSdMovie(string id);
        List<SdMovieDto> GetALl();
        SdMovie CreateSdMovie(SdMovieDto SdMovieDto);
    }
    public class SdMovieService : ISdMovieService
    {
        private readonly ISdMovieRepository _SdMovieRepository;

        public SdMovieService(ISdMovieRepository SdMovieRepository)
        {
            _SdMovieRepository = SdMovieRepository;    
        }
        
       
        public SdMovie GetSdMovie(string id)
        {
            return _SdMovieRepository.GetSdMovie(id);
        }

        public SdMovie CreateSdMovie(SdMovieDto SdMovieDto)
        {
            return _SdMovieRepository.CreateSdMovie(SdMovieDto);
        }
        public List<SdMovieDto> GetALl()
        {
            return _SdMovieRepository.GetAll().Select(_SdMovieRepository.ToSdMovieDto).ToList();
        }
      
       
    }
}