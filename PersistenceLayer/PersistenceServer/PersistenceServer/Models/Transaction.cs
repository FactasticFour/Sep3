using System;

namespace PersistenceServer.Models
{
    public class Transaction
    {
        public Account ReceiverAccount { get; set; }
        public Account SenderAccount { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public int Payload { get; set; }
        public DateTime Timestamp { get; set; }

        public Transaction(Account receiverAccount, Account senderAccount, string comment, string type, int payload, DateTime timestamp)
        {
            ReceiverAccount = receiverAccount;
            SenderAccount = senderAccount;
            Comment = comment;
            Type = type;
            Payload = payload;
            Timestamp = timestamp;
        }
    }
}