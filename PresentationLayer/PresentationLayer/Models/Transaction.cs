using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class Transaction
    {   [Key]
        public Account ReceiverAccount { get; set; }
        [Key]
        public Account SenderAccount { get; set; }
        [Required, Range(0, 298000)] 
        public float Amount { get; set; }
        public string Comment { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public Transaction(Account receiverAccount, Account senderAccount, string comment, string type, int payload, DateTime timestamp)
        {
            ReceiverAccount = receiverAccount;
            SenderAccount = senderAccount;
            Comment = comment;
            Type = type;
            Amount = payload;
            Timestamp = timestamp;
        }
    }
}