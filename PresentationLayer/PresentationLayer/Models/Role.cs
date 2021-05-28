using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class Role
    {
        
        public int RoleId { get; set; }

        public String RoleType { get; set; }
    }
}