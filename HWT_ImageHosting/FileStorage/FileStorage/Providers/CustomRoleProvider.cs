using System;
using System.Web.Security;
using BusinessLogicLayer;

namespace FileStorage.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private UserManager userManager;

        public CustomRoleProvider()
        {
            userManager = new UserManager();
        }

        public override string[] GetRolesForUser(string username)
        {
            var userRole = userManager.GetUserRole(username);
            return new[] { userRole.Name };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRole = userManager.GetUserRole(username);
            return userRole.Name == roleName;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}