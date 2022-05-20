using MoviesCatalogDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCatalogModels.ViewModels
{
    public class MovieVM
    {

        public MovieVM()
        {
            People = new List<PersonVM>();
            Genres = new List<Genre>();
        }

        public int Id { get; set; }
        public string Titile { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<PersonVM> People { get; set; }
        public List<Genre> Genres { get; set; }


    }
}
