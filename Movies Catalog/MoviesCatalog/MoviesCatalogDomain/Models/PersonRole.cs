using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesCatalogDomain.Models
{
    public class PersonRole
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
