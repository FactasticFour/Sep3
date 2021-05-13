using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceServer.Models
{
    public class Transfer
    {
        //todo add transfer id?
        [Required, Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int SenderViaId { get; set; }
        
        [Required, Range(0, 9999999, ErrorMessage = "Invalid VIA ID")]
        public int ReceiverViaId { get; set; }

        [Required, Range(0, 9000000)]
        public int MoneyToTransfer { get; set; }
        //todo rename this to amount or transferAmount?

        [Required, Timestamp]
        public DateTime Timestamp { get; set; }
        //todo what about this one?
        //https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
    }
}