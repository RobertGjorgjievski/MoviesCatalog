using MoviesCatalogDomain.Models;
using MoviesCatalogModels.DTO;
using MoviesCatalogModels.ViewModels;
using System.Linq;

namespace MoviesCatalogBusinessLayer.Helpers
{
    public static class Mapper
    {
        public static MovieVM MapToMovieVM(this Movie movie)
        {
            return new MovieVM
            {
                Id = movie.Id,
                Titile = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                People = movie.MoviePeople.Select(x => x.Person.MapToPersonVM()).ToList(),
                Genres = movie.MovieGenres.Select(x => x.Genre).ToList()
            };
        }

        public static Movie MapToMovie(this CreateUpdateMovieModel createMovieModel)
        {
            Movie result = new Movie
            {
                Id = createMovieModel.Id,
                Title = createMovieModel.Titile,
                ReleaseDate = createMovieModel.ReleaseDate,
            };

            result.MovieGenres =
                createMovieModel.Genres.Select(x => new MovieGenre()
                {
                    GenreId = x,
                    MovieId = result.Id
                }).ToList();

            result.MoviePeople =
                createMovieModel.People.Select(x => new MoviePerson()
                {
                    PersonId = x,
                    MovieId = result.Id
                }).ToList();

            return result;
        }

        public static PersonVM MapToPersonVM(this Person person)
        {
            return new PersonVM
            {
                Id = person.Id,
                FullName = person.FullName,
                Roles = person.Roles.Select(x => x.Role)
            };
        }
    }
}
