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
            IUserRepository repository = new UserRepositoryImpl();
            DataServer dataServer = new DataServer(repository);
            dataServer.Start();

            Console.WriteLine("------");
            
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
            Console.WriteLine("------");
        }
    }
}