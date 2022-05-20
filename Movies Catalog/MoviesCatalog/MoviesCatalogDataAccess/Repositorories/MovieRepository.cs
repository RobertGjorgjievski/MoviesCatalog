using MoviesCatalogDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesCatalogDataAccess.Repositorories
{
    public class MovieRepository : IRepository<Movie>
    {

        private readonly MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Movie entity)
        {
           _context.Movies.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
        public void Delete(Movie entity)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == entity.Id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            _context.SaveChanges();
        }
        public void Update(Movie entity)
        {
            var movie = GetById(entity.Id);
            if(movie != null)
            {
                movie.Title = entity.Title;
                movie.ReleaseDate = entity.ReleaseDate;
               
            }
            _context.SaveChanges(); 
        } 

       
    }
}
