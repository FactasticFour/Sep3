using System;

namespace PersistenceServer.Repository
{
    public class DbSeedingRepositoryImpl : IDbSeedingRepository
    {
        public void SeedDatabase()
        {
            Console.WriteLine("Seeding Database");
        }
    }
}