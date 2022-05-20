using MoviesCatalogDomain.Models;
using System.Collections.Generic;

namespace MoviesCatalogModels.ViewModels
{
    public class PersonVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
