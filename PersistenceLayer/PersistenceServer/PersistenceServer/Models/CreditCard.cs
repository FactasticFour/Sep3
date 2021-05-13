using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class CreditCard
    {
        [Key, Required, StringLength(16, ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }
        
        [MaxLength(256), Required, Column("fname")]
        public String FirstName { get; set; }
        
        [MaxLength(256), Required, Column("lname")]
        public String LastName { get; set; }
        // TODO split expiration date into expirationMonth and expirationYear?

        [Required, Range(111, 999, ErrorMessage = "Invalid credit card security code")]
        public int SecurityCode { get; set; }

        [Required,Range(0, 9000000)]
        public int AmountOfMoney { get; set; }
    }
}