using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Facility : ViaEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
        
        [Required, MinLength(8)]
        public string Password { get; set; }
        
        [Required, MaxLength(256)]
        public string City { get; set; }
        
        [Required, MaxLength(256)]
        public string Street { get; set; }
        
        [Required, StringLength(4, ErrorMessage = "Invalid postcode"), Column("postcode")]
        public string PostCode { get; set; }

        public Campus Campus { get; set; }
        public Account Account { get; set; }
    }
}