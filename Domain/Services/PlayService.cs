using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Services
{
    public interface IPlayService
    {
        Play GetPlay(string id);
        List<PlayDto> GetALl();
        Play CreatePlay(PlayDto PlayDto);
    }
    public class PlayService : IPlayService
    {
        private readonly IPlayRepository _PlayRepository;

        public PlayService(IPlayRepository PlayRepository)
        {
            _PlayRepository = PlayRepository;    
        }
        
       

        public Play GetPlay(string id)
        {
            return _PlayRepository.GetPlay(id);
        }
         public List<PlayDto> GetALl()
        {
            return _PlayRepository.GetAll().Select(_PlayRepository.ToPlayDto).ToList();
        }

        public Play CreatePlay(PlayDto PlayDto)
        {
            return _PlayRepository.CreatePlay(PlayDto);
        }

       
    }
}