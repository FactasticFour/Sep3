using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class Role
    {
        [Key, Required]
        public int RoleId { get; set; }

        [Required]
        public String RoleType { get; set; }
    }
}