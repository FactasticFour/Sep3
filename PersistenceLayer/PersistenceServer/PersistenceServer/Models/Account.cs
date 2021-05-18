using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Account
    {
        [Key, Required]
        public int AccountId { get; set; }
        
        public IList<Account> Sender { get; set; }
        public IList<Account> Receiver { get; set; }
        
        [Required, StringLength(64)]
        public String ApplicationPassword { get; set; }
        
        [Required,Range(0, 9000000)]
        public int Balance { get; set; }

        [Required, ForeignKey("viaId")]
        public ViaEntity ViaEntity { get; set; }
        
    }
}