using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Services
{
    public interface ISdPlayService
    {
        SdPlay GetSdPlay(string id);
        List<SdPlayDto> GetALl();
        SdPlay CreateSdPlay(SdPlayDto SdPlayDto);
    }
    public class SdPlayService : ISdPlayService
    {
        private readonly ISdPlayRepository _SdPlayRepository;

        public SdPlayService(ISdPlayRepository SdPlayRepository)
        {
            _SdPlayRepository = SdPlayRepository;    
        }
        
       

        public SdPlay GetSdPlay(string id)
        {
            return _SdPlayRepository.GetSdPlay(id);
        }
         public List<SdPlayDto> GetALl()
        {
            return _SdPlayRepository.GetAll().Select(_SdPlayRepository.ToSdPlayDto).ToList();
        }

        public SdPlay CreateSdPlay(SdPlayDto SdPlayDto)
        {
            return _SdPlayRepository.CreateSdPlay(SdPlayDto);
        }

       
    }
}