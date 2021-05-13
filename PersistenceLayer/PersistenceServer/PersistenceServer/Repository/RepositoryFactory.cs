namespace PersistenceServer.Repository
{
    public class RepositoryFactory
    {
        private IUserRepository userRepository;

        public IUserRepository GetUserRepository()
        {
            if (userRepository == null)
            {
                userRepository = new UserRepositoryImpl();
            }

            return userRepository;
        }
    }
}