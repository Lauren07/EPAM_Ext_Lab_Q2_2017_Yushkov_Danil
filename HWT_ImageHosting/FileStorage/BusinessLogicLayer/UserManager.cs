using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer
{
    public class UserManager
    {
        private RepositoriesFactory repositories;

        public UserManager()
        {
            repositories = new RepositoriesFactory();
        }

        public void RegisterUser(UserDTO user)
        {
            var preparedUser = Mapper.Map<UserDTO, User>(user);
            preparedUser.Role = new Role(user.RoleId);
            preparedUser.SetHashPassword(user.Password);
            repositories.UserRepository.CreateUser(preparedUser);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return repositories.UserRepository.GetAllRoles();
        }

        public bool UserIsLogin(UserDTO user)
        {
            var requestUser = repositories.UserRepository.FindUser(user.Login);
            if (requestUser == null)
            {
                return false;
            }

            return requestUser.PassIsMatch(user.Password);
        }

        public bool UserIsExisting(string login)
        {
            return repositories.UserRepository.FindUser(login) != null;
        }

        public User FindUser(string login)
        {
            return repositories.UserRepository.FindUser(login);
        }

        public Role GetUserRole(string login)
        {
            return repositories.UserRepository.GetUserRole(login);
        }

        public void UpdateUser(UserDTO user)
        {
            var preparedUser = Mapper.Map<UserDTO, User>(user);
            preparedUser.SetHashPassword(user.Password);
            repositories.UserRepository.UpdateUser(preparedUser);
        }
    }
}
