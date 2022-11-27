using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface ISdPlayRepository
    {
        List<SdPlay> GetAll();
        SdPlay Find(int id);
        SdPlay CreateSdPlay(SdPlayDto SdPlayDto);
        SdPlayDto ToSdPlayDto(SdPlay SdPlay);
        SdPlay GetSdPlay(string id);

    }

    public class SdPlayRepository : ISdPlayRepository
    {
        private readonly AppDbContext _context;
        public SdPlayRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SdPlay> GetAll()
        {
            return _context.SdPlays.ToList();
        }

        public SdPlay Find(int id)
        {
            return _context.SdPlays.Find(id);
        }

        public SdPlay CreateSdPlay(SdPlayDto SdPlayDto)
        {   
            
            var SdPlay = ToSdPlay(SdPlayDto);
            SdPlay.Id= Guid.NewGuid().ToString();   
            _context.SdPlays.Add(SdPlay);
            this._context.SaveChanges();
            return SdPlay;
        }

        private SdPlay ToSdPlay(SdPlayDto SdPlayDto)
        {
            return new SdPlay
            {   
                 Id = SdPlayDto.Id,
                Backdrop_path= SdPlayDto.Backdrop_path,
                Genre= SdPlayDto.Genre,
                Overview= SdPlayDto.Overview,
                Poster= SdPlayDto.Poster,
                Language= SdPlayDto.Language,
                Status = SdPlayDto.Status,
                Vote_average= SdPlayDto.Vote_average,
                Available= SdPlayDto.Available,
                Budget= SdPlayDto.Budget,
                Revenue= SdPlayDto.Revenue,
                Runtime=SdPlayDto.Runtime,
                Release_date= SdPlayDto.Release_date,
                Cast= SdPlayDto.Cast,
                Video = SdPlayDto.Video,
                Title= SdPlayDto.Title

            };
        }

        public SdPlayDto ToSdPlayDto(SdPlay SdPlay)
        {
            return new SdPlayDto
            {
                 
                 Id = SdPlay.Id,
                Backdrop_path= SdPlay.Backdrop_path,
                Genre= SdPlay.Genre,
                Overview= SdPlay.Overview,
                Poster= SdPlay.Poster,
                Language= SdPlay.Language,
                Status = SdPlay.Status,
                Vote_average= SdPlay.Vote_average,
                Available= SdPlay.Available,
                Budget= SdPlay.Budget,
                Revenue= SdPlay.Revenue,
                Runtime=SdPlay.Runtime,
                Release_date= SdPlay.Release_date,
                Cast= SdPlay.Cast,
                Video = SdPlay.Video,
                Title= SdPlay.Title
               
            };
        }
          public SdPlay GetSdPlay(string id)
        {
            return _context.SdPlays.Find(id);
        }
         public List<SdPlay> GetALL()
        {
            return _context.SdPlays.ToList();
        }
    }
}