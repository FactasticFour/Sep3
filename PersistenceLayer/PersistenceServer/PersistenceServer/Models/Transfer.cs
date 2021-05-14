using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceServer.Models
{
    public class Transfer
    {
        [ForeignKey("senderId"), Required, Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int SenderViaId { get; set; }
        
        
        [ForeignKey("receivedId"), Required, Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int ReceiverViaId { get; set; }

        [Required, Range(0, 9000000)]
        public int transferAmount { get; set; }

        [Required, Timestamp]
        public DateTime Timestamp { get; set; }
    }
}