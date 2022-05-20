using MoviesCatalogBusinessLayer.Helpers;
using MoviesCatalogBusinessLayer.Interfaces;
using MoviesCatalogDataAccess.Repositorories;
using MoviesCatalogDomain.Models;
using MoviesCatalogModels.DTO;
using MoviesCatalogModels.ViewModels;
using System;
using System.Collections.Generic;

namespace MoviesCatalogBusinessLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepo;

        public MovieService(IRepository<Movie> movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public void AddNewMovie(CreateUpdateMovieModel movieModel)
        {
            if (string.IsNullOrEmpty(movieModel.Titile))
            {
                throw new Exception("Title for the movie is required");
            }
            Movie movieDb = Mapper.MapToMovie(movieModel);
            _movieRepo.Insert(movieDb);
        }

        public void DeleteMovie(MovieVM movieVM)
        {
            Movie movie = _movieRepo.GetById(movieVM.Id);
           
            _movieRepo.Delete(movie);
        }

        public void EditMovie(CreateUpdateMovieModel movieModel)
        {
            Movie movie = _movieRepo.GetById(movieModel.Id);
            if (movie != null)
            {
                Movie movieMap = Mapper.MapToMovie(movieModel);
                _movieRepo.Update(movieMap);
            }
        }

        public List<MovieVM> GetAllMovies()
        {
            List<Movie> movies = _movieRepo.GetAll();
            List<MovieVM> movieVMs = new List<MovieVM>();

            foreach (Movie movie in movies)
            {
                movieVMs.Add(Mapper.MapToMovieVM(movie));

            }

            return movieVMs;
        }

        public MovieVM GetById(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            MovieVM movieVM = movie.MapToMovieVM();
            return movieVM;


        }
    }
}
