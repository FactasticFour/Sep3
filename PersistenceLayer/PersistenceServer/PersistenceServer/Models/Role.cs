using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class Role
    {
        [Key, Required]
        public int RoleId { get; set; }
        [Required, Range(typeof(String), "Admin", "Admin")]
        public String RoleType { get; set; }
        
    }
}