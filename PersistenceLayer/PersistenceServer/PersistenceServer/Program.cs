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
            DataServer dataServer = new DataServer(repositoryFactory);
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