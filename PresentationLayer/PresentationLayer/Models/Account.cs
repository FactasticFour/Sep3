using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.Models
{
    public class Account
    {
       
        public int AccountId { get; set; }
        
        public ViaEntity ViaEntity { get; set; }

        public Role AccountType { get; set; }

        public String ApplicationPassword { get; set; }
        
        public float Balance { get; set; }
        
    }
}