using PersistenceServer.Repository.Impl;

namespace PersistenceServer.Repository
{
    public class RepositoryFactory
    {
        public static IUserRepository GetUserRepository()
        {
            return new UserRepositoryImpl();
        }

        public static IDbSeedingRepository GetDbSeedingRepository()
        {
            return new DbSeedingRepositoryImpl();
        }
    }
}