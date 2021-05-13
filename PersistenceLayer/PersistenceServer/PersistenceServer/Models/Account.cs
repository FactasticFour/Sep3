using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class Account
    {
        [Key, Required]
        public int AccountId { get; set; }
        [Required, MinLength(8)]
        public String ApplicationPassword { get; set; }
        [Required,Range(0, 9000000)]
        public int Balance { get; set; }
    }
}