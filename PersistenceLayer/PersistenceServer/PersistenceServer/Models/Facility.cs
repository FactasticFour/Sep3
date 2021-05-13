using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Facility
    {
        [Required, Key, Range(0,9999999, ErrorMessage = "Invalid VIA ID")]
        public int ViaId { get; set; }
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        [Required, MaxLength(256)]
        public string City { get; set; }
        [Required, MaxLength(256)]
        public string Street { get; set; }
        [Required, StringLength(10, ErrorMessage = "Invalid postcode"), Column("postcode")]
        public string PostCode { get; set; }
    }
}