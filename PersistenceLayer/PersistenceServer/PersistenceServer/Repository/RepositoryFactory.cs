using PersistenceServer.Repository.Impl;
using PersistenceServer.shared;

namespace PersistenceServer.Repository
{
    public static class RepositoryFactory
    {
        public static IUserRepository GetUserRepository()
        {
            return new UserRepositoryImpl();
        }

        public static IDbSeedingRepository GetDbSeedingRepository()
        {
            return new DbSeedingRepositoryImpl();
        }

        public static IAccountRepository GetAccountRepository()
        {
            return new AccountRepositoryImpl();
        }

        public static IRoleRepository GetRoleRepository()
        {
            return new RoleRepositoryImpl();
        }

        public static IViaEntityRepository GetViaEntityRepository()
        {
            return new ViaEntityRepositoryImpl();
        }

        public static IMemberRepository GetMemberRepository()
        {
            return new MemberRepositoryImpl();
        }

        public static IFacilityRepository GetFacilityRepository()
        {
            return new FacilityRepositoryImpl();
        }
    }
}