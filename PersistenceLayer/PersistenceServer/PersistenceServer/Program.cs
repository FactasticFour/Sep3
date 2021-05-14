using System;
using PersistenceServer.Networking;
using PersistenceServer.Repository;


namespace PersistenceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataServer dataServer = new DataServer();
            dataServer.Start();
        }
    }
}