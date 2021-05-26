﻿namespace PersistenceServer.shared
{
    public class Reply
    {
        public const string  SEND_USER = "SEND_USER";
        public const string  BAD_REQUEST = "BAD_REQUEST";
        public const string  SEEDING_SUCCESS = "SEEDING_SUCCESS";
        public const string  SEND_ACCOUNT_BALANCE = "SEND_ACCOUNT_BALANCE";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Reply(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}