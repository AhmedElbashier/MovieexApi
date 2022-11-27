using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Services
{
    public interface ISdTvService
    {
        SdTv GetSdTv(string id);
        List<SdTvDto> GetALl();
        SdTv CreateSdTv(SdTvDto SdTvDto);
    }
    public class SdTvService : ISdTvService
    {
        private readonly ISdTvRepository _SdTvRepository;

        public SdTvService(ISdTvRepository SdTvRepository)
        {
            _SdTvRepository = SdTvRepository;    
        }
        
       

        public SdTv GetSdTv(string id)
        {
            return _SdTvRepository.GetSdTv(id);
        }
         public List<SdTvDto> GetALl()
        {
            return _SdTvRepository.GetAll().Select(_SdTvRepository.ToSdTvDto).ToList();
        }

        public SdTv CreateSdTv(SdTvDto SdTvDto)
        {
            return _SdTvRepository.CreateSdTv(SdTvDto);
        }

       
    }
}