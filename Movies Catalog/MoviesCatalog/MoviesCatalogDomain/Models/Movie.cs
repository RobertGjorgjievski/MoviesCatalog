using System;
using System.Collections.Generic;

namespace MoviesCatalogDomain.Models
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            MoviePeople = new List<MoviePerson>();
            MovieGenres = new List<MovieGenre>();
        }

        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual IEnumerable<MovieGenre> MovieGenres { get; set; }
        public virtual IEnumerable<MoviePerson> MoviePeople { get; set; }
    }
}