using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Services
{
    public interface ITvService
    {
        Tv GetTv(string id);
        List<TvDto> GetALl();
        Tv CreateTv(TvDto TvDto);
    }
    public class TvService : ITvService
    {
        private readonly ITvRepository _TvRepository;

        public TvService(ITvRepository TvRepository)
        {
            _TvRepository = TvRepository;    
        }
        
       

        public Tv GetTv(string id)
        {
            return _TvRepository.GetTv(id);
        }
         public List<TvDto> GetALl()
        {
            return _TvRepository.GetAll().Select(_TvRepository.ToTvDto).ToList();
        }

        public Tv CreateTv(TvDto TvDto)
        {
            return _TvRepository.CreateTv(TvDto);
        }

       
    }
}