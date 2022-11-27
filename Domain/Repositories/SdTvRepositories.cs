using System;
using System.Collections.Generic;
using System.Linq;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Repositories
{
    public interface ISdTvRepository
    {
        List<SdTv> GetAll();
        SdTv Find(int id);
        SdTv CreateSdTv(SdTvDto SdTvDto);
        SdTvDto ToSdTvDto(SdTv SdTv);
        SdTv GetSdTv(string id);

    }

    public class SdTvRepository : ISdTvRepository
    {
        private readonly AppDbContext _context;
        public SdTvRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SdTv> GetAll()
        {
            return _context.SdTvs.ToList();
        }

        public SdTv Find(int id)
        {
            return _context.SdTvs.Find(id);
        }

        public SdTv CreateSdTv(SdTvDto SdTvDto)
        {   
            
            var SdTv = ToSdTv(SdTvDto);
            SdTv.Id= Guid.NewGuid().ToString();   
            _context.SdTvs.Add(SdTv);
            this._context.SaveChanges();
            return SdTv;
        }

        private SdTv ToSdTv(SdTvDto SdTvDto)
        {
            return new SdTv
            {   
                 Id = SdTvDto.Id,
                Backdrop_path= SdTvDto.Backdrop_path,
                Genre= SdTvDto.Genre,
                Overview= SdTvDto.Overview,
                Poster= SdTvDto.Poster,
                Language= SdTvDto.Language,
                Status = SdTvDto.Status,
                Vote_average= SdTvDto.Vote_average,
                Available= SdTvDto.Available,
                Budget= SdTvDto.Budget,
                Revenue= SdTvDto.Revenue,
                Runtime=SdTvDto.Runtime,
                Release_date= SdTvDto.Release_date,
                Cast= SdTvDto.Cast,
                Video = SdTvDto.Video,
                Title= SdTvDto.Title

            };
        }

        public SdTvDto ToSdTvDto(SdTv SdTv)
        {
            return new SdTvDto
            {
                 
                 Id = SdTv.Id,
                Backdrop_path= SdTv.Backdrop_path,
                Genre= SdTv.Genre,
                Overview= SdTv.Overview,
                Poster= SdTv.Poster,
                Language= SdTv.Language,
                Status = SdTv.Status,
                Vote_average= SdTv.Vote_average,
                Available= SdTv.Available,
                Budget= SdTv.Budget,
                Revenue= SdTv.Revenue,
                Runtime=SdTv.Runtime,
                Release_date= SdTv.Release_date,
                Cast= SdTv.Cast,
                Video = SdTv.Video,
                Title= SdTv.Title
               
            };
        }
          public SdTv GetSdTv(string id)
        {
            return _context.SdTvs.Find(id);
        }
         public List<SdTv> GetALL()
        {
            return _context.SdTvs.ToList();
        }
    }
}