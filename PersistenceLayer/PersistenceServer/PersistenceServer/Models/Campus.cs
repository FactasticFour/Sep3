using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Campus
    {
        //TODO what pk  here?
        [Required, MaxLength(256)]
        public string City { get; set; }

        [Required, MaxLength(256)]
        public string Street { get; set; }

        [Required, StringLength(10, ErrorMessage = "Invalid postcode"), Column("postcode")]
        public string PostCode { get; set; }
        //todo what is the default postcode lenght?

        [Required, MaxLength(256)]
        public string Name { get; set; }
    }
}