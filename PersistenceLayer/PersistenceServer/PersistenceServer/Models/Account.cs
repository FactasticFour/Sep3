using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required, ForeignKey("viaId")]
        public ViaEntity ViaEntity { get; set; }
        
        [ForeignKey("creditCardNumber")]
        public CreditCard CreditCard { get; set; }
    }
}