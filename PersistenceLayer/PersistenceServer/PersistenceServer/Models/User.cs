﻿using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class User
    {
        [Key] public int UserId { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public string Password { get; set; }

        public User()
        {
        }
    }
}