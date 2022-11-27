using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MovieexApi.Domain.Helpers;
using MovieexApi.Domain.Repositories;

namespace MovieexApi.Domain.Installers
{
    public class DbInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                        new MariaDbServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
            
            services.AddScoped<ITvRepository, TvRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISdMovieRepository, SdMovieRepository>();
            services.AddScoped<ISdTvRepository, SdTvRepository>();
            services.AddScoped<ISdPlayRepository, SdPlayRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPlayRepository, PlayRepository>();

        }
    }
}