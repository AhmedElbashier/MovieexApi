using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieexApi.Domain.Services;

namespace MovieexApi.Domain.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITvService, TvService>();
            services.AddScoped<ISdMovieService, SdMovieService>();
            services.AddScoped<ISdTvService, SdTvService>();
            services.AddScoped<ISdPlayService, SdPlayService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPlayService, PlayService>();

        }
    }
}