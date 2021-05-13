using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class Role
    {
        [Key, Required]
        public int RoleId { get; set; }
        [Required] // i think we just have to check this constraint in the business logic
        public String RoleType { get; set; }
        
    }
}