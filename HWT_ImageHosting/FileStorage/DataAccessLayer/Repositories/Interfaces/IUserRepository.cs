using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string login);
        User FindUser(int id);
        int CreateUser(User user);
        Role GetUserRole(string login);
        void UpdateUser(User user);
        IEnumerable<Role> GetAllRoles();
        int CreateRole(Role role);
        void DeleteRole(int roleId);
        void DeleteUser(string login);
    }
}
