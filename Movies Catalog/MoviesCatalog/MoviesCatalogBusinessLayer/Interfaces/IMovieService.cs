using MoviesCatalogModels.DTO;
using MoviesCatalogModels.ViewModels;
using System.Collections.Generic;

namespace MoviesCatalogBusinessLayer.Interfaces
{
    public interface IMovieService
    {
        public MovieVM GetById (int id);
        public void AddNewMovie(CreateUpdateMovieModel movieModel);
        public void EditMovie(CreateUpdateMovieModel movieModel);
        public void DeleteMovie(MovieVM movieVM);
        public List<MovieVM> GetAllMovies();
    }
}
