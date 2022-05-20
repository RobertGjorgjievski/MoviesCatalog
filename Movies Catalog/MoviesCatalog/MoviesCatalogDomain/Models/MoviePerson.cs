using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesCatalogDomain.Models
{
    public class MoviePerson
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}
