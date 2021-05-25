﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.Models
{
    public class Account
    {
        [Key, Required]
        public int AccountId { get; set; }

        [Required, ForeignKey("viaId")]
        public ViaEntity ViaEntity { get; set; }

        public Role AccountType { get; set; }

        [Required, StringLength(64)]
        public String ApplicationPassword { get; set; }

        [Required,Range(0, 9000000)]
        public float Balance { get; set; }

    }
}