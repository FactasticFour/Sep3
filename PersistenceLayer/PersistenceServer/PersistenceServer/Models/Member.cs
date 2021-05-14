﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Member : ViaEntity
    {
        [MaxLength(256), Required, Column("fname")]
        public String FirstName { get; set; }
        [MaxLength(256), Required, Column("lname")]
        public String LastName { get; set; }
        [MinLength(8), Required]
        public String Password { get; set; }
        [Required, StringLength(10, ErrorMessage = "Invalid CPR")]
        public int Cpr { get; set; }

        public Account Account { get; set; }
    }
}