﻿using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ViaEntity
    {
        [Key, Required, Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int ViaId { get; set; }
        [Required, StringLength(64)]
        public string Password { get; set; }

        public Account Account { get; set; }
    }
}