using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersistenceServer.Data;
using PersistenceServer.Models;
using PersistenceServer.shared;

namespace PersistenceServer.Repository.Impl
{
    public class RoleRepositoryImpl : IRoleRepository
    {
        public async Task<List<string>> GetAllAccountTypesAsync()
        {
            using DataContext dataContext = new DataContext();
            List<Role> allRoles = dataContext.Roles.ToList();
            List<string> allAccountTypes = new List<string>();

            foreach (Role role in allRoles)
            {
                allAccountTypes.Add(role.RoleType);
            }
            return allAccountTypes;
        }
    }
}