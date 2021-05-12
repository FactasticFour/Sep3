using System;
using PersistenceServer.Data;
using PersistenceServer.Models;
using PersistenceServer.Networking;
using PersistenceServer.Repository;

namespace PersistenceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            DataServer dataServer = new DataServer();
            dataServer.Start();

            Console.WriteLine("1------");
            
            // takes care of shutting down the database
            /*
            using DataContext dataContext = new DataContext();
            dataContext.Users.Add(new User
            {
                UserName = "John",
                Password = "12345"
            });
            dataContext.SaveChanges();
*/
            Console.WriteLine("2------");
        }
    }
}