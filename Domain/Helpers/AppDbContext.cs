using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MovieexApi.Domain.Models;

namespace MovieexApi.Domain.Helpers
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<SdMovie> SdMovies { get; set; }
        public DbSet<Tv> Tvs { get; set; }
        public DbSet<SdTv> SdTvs { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<SdPlay> SdPlays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        // public DbSet<Top250Movie> Top250Movies { get; set; }
        // public DbSet<Top250Series> Top250Series { get; set; }
        // public DbSet<InTheater> InTheaters { get; set; }
        // public DbSet<ComingSoon> ComingSoons { get; set; }
        // public DbSet<BoxOfficeAllTime> BoxOfficeAllTimes { get; set; }
        // public DbSet<BoxOfficeWeekend> BoxOfficeWeekends { get; set; }
        
                
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
         
            base.OnModelCreating(builder);
        }
    }
}