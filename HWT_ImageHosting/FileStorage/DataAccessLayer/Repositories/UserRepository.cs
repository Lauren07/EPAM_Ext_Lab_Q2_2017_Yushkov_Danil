using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CreateUser(User user)
        {
            int userId;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Users(UserLogin, UserHashPassword, UserRoleId)" +
                                      " OUTPUT INSERTED.UserId" +
                                      " VALUES (@Login, @HashPassword, @RoleId)";
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@HashPassword", user.HashPassword);
                command.Parameters.AddWithValue("@RoleId", user.Role.Id);
                connection.Open();
                userId = (int)command.ExecuteScalar();
            }

            return userId;
        }

        public User FindUser(string login)
        {
            User requestedUser = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT UserId, UserLogin, UserHashPassword, UserRoleId, r.RoleName, r.RoleDescription" +
                                      " FROM Users JOIN Roles r" +
                                      " ON UserRoleId=r.RoleId" +
                                      " WHERE UserLogin=@Login";
                command.Parameters.AddWithValue("@Login", login);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedUser = new User
                        {
                            Id = (int)reader["UserId"],
                            Login = (string)reader["UserLogin"],
                            HashPassword = (Guid)reader["UserHashPassword"],
                            Role = new Role((int)reader["UserRoleId"], (string)reader["RoleName"], reader["RoleDescription"] as string)
                        };
                    }
                }
            }

            return requestedUser;
        }

        public User FindUser(int id)
        {
            User requestedUser = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT UserId, UserLogin, UserHashPassword, UserRoleId, r.RoleName, r.RoleDescription" +
                                      " FROM Users JOIN Roles r" +
                                      " ON UserRoleId=r.RoleId" +
                                      " WHERE UserId=@Id";
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedUser = new User
                        {
                            Id = (int)reader["UserId"],
                            Login = (string)reader["UserLogin"],
                            HashPassword = (Guid)reader["UserHashPassword"],
                            Role = new Role((int)reader["UserRoleId"], (string)reader["RoleName"], reader["RoleDescription"] as string)
                        };
                    }
                }
            }

            return requestedUser;
        }

        public int CreateRole(Role role)
        {
            int roleId;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Roles(RoleName)" +
                                      " OUTPUT INSERTED.RoleId" +
                                      " VALUES (@Name)";
                command.Parameters.AddWithValue("@Name", role.Name);
                connection.Open();
                roleId = (int)command.ExecuteScalar();
            }

            return roleId;
        }

        public void DeleteRole(int roleId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Roles" +
                                      $" WHERE RoleId={roleId}";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(string login)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Users" +
                                      " WHERE UserLogin=@login";
                command.Parameters.AddWithValue("@login", login);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Role> GetAllRoles()
        {
            var roles = new List<Role>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT RoleId, RoleName, RoleDescription" +
                                      " FROM Roles";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role((int)reader["RoleId"], (string)reader["RoleName"], reader["RoleDescription"] as string));
                    }
                }
            }

            return roles;
        }

        public Role GetUserRole(string login)
        {
            Role requestedRole = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT r.RoleId, r.RoleName, r.RoleDescription" +
                                      " FROM Users u JOIN Roles r" +
                                      " ON u.UserRoleId=r.RoleId" +
                                      " WHERE UserLogin=@Login";
                command.Parameters.AddWithValue("@Login", login);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedRole = new Role((int)reader["RoleId"], (string)reader["RoleName"], reader["RoleDescription"] as string);
                    }
                }
            }

            return requestedRole;
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Users" +
                                      " SET UserLogin=@Login, UserHashPassword=@Password" +
                                      " WHERE UserId = @Id";
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.HashPassword);
                command.Parameters.AddWithValue("@Id", user.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
