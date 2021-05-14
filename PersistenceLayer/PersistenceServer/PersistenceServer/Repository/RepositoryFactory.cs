namespace PersistenceServer.Repository
{
    public class RepositoryFactory
    {
        public static IUserRepository GetUserRepository()
        {
            return new UserRepositoryImpl();
        }
    }
}