﻿namespace PersistenceServer.shared
{
    public class Reply
    {
        public const string  SEND_USER = "SEND_USER";
        public const string  BAD_REQUEST = "BAD_REQUEST";
        public const string  SEND_ENTITY = "SEND_ENTITY";
        public const string  SEND_ALL_ACCOUNT_TYPES = "SEND_ALL_ACCOUNT_TYPES";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Reply(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}