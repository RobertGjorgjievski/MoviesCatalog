using Microsoft.AspNetCore.Mvc;
using MoviesCatalogBusinessLayer.Interfaces;
using MoviesCatalogModels.DTO;
using MoviesCatalogModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesCatalog.Application.Controllers
{

    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            List<MovieVM> movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult NewMovie()
        {
            return View("AddNewMovie");
        }
        public IActionResult AddNewMovie(CreateUpdateMovieModel movieModel)
        {
            try
            {
                _movieService.AddNewMovie(movieModel);
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult EditMovie(CreateUpdateMovieModel movieModel)
        {
            try
            {
                _movieService.EditMovie(movieModel);
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult DeleteMovie(MovieVM movieVM)
        {
            MovieVM movie = _movieService.GetById(movieVM.Id);
            if (movie != null)
            {
                _movieService.DeleteMovie(movieVM);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            MovieVM movieVM = _movieService.GetById(id);
            return View(movieVM);
        }
    }
}
