using System;
using System.Collections.Generic;

namespace MoviesCatalogModels.DTO
{
    public class CreateUpdateMovieModel
    {

        public CreateUpdateMovieModel()
        {
            People = new List<int>();
            Genres = new List<int>();
        }

        public int Id { get; set; }
        public string Titile { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<int> People { get; set; }
        public List<int> Genres { get; set; }
    }
}
