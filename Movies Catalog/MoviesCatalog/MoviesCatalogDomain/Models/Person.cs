using System.Collections.Generic;

namespace MoviesCatalogDomain.Models
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Roles = new List<PersonRole>();
        }

        public string FullName { get; set; }
        public virtual List<PersonRole> Roles { get; set; }
    }
}