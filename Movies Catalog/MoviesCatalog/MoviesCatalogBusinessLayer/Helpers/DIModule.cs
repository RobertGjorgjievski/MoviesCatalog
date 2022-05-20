using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesCatalogBusinessLayer.Interfaces;
using MoviesCatalogBusinessLayer.Services;
using MoviesCatalogDataAccess;
using MoviesCatalogDataAccess.Repositorories;
using MoviesCatalogDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCatalogBusinessLayer.Helpers
{
    public static class DIModule
    {

        public static IServiceCollection Register (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MovieContext>(
                x => x.UseLazyLoadingProxies().UseSqlServer(connectionString));

            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Person>, PersonRepository>();

            services.AddTransient<IMovieService, MovieService>();

            return services;
        }
    }
}
