using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class Member
    {
        [Key, Required]
        public int ViaId { get; set; }
        [MaxLength(256), Required]
        public String FirstName { get; set; }
        [MaxLength(256), Required]
        public String LastName { get; set; }
        [MinLength(8), Required]
        public String Password { get; set; }
        [Required, MaxLength(10), MinLength(10)]
        public int Cpr { get; set; }
        
    }
}