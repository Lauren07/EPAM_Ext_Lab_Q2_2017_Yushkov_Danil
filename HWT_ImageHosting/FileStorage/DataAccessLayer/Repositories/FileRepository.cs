using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class FileRepository : IFileRepository
    {
        private string connectionString;

        public FileRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CreateFile(File file)
        {
            int resultId;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Files(FileName, FileContent, CreatedDate, Description, IsPublic, UserId)" +
                                      " OUTPUT INSERTED.FileId" +
                                      " VALUES (@Name, @Content, @CreatedDate, @Description, @IsPublic, @UserId)";
                command.Parameters.AddWithValue("@Name", file.Name);
                command.Parameters.AddWithValue("@Content", file.Content);
                command.Parameters.AddWithValue("@CreatedDate", file.CreatedDate);
                command.Parameters.AddWithValue("@Description", file.Description ?? string.Empty);
                command.Parameters.AddWithValue("@IsPublic", file.IsPublic);
                command.Parameters.AddWithValue("@UserId", file.UserId);

                connection.Open();
                resultId = (int)command.ExecuteScalar();
            }

            return resultId;
        }

        public IEnumerable<Role> GetRolesFile(int fileId)
        {
            var roles = new List<Role>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT fr.RoleId, r.RoleName" +
                                      " FROM FilesRoles fr JOIN Roles r" +
                                      " ON fr.RoleId = r.RoleId" +
                                      $" WHERE FileId={fileId}";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role((int)reader["RoleId"], (string)reader["RoleName"]));
                    }
                }
            }

            return roles;
        }

        public void UpdateFile(File file)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Files" +
                                      " SET FileName=@Name, Description=@Description, IsPublic=@IsPublic" +
                                      " WHERE FileId = @Id";
                command.Parameters.AddWithValue("@Name", file.Name);
                command.Parameters.AddWithValue("@Description", file.Description ?? string.Empty);
                command.Parameters.AddWithValue("@IsPublic", file.IsPublic);
                command.Parameters.AddWithValue("@Id", file.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveFileRoles(int fileId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM FilesRoles" +
                                      $" WHERE FileId={fileId}";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddRoleForFile(int fileId, int roleId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO FilesRoles(FileId, RoleId)" +
                    " VALUES (@FileID, @RoleID)";
                command.Parameters.AddWithValue("@FileID", fileId);
                command.Parameters.AddWithValue("@RoleID", roleId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFile(int fileId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Files" +
                                      $" WHERE FileId={fileId}";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public File FindFile(int fileId)
        {
            File requestedFile = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT FileId, FileName, FileContent, CreatedDate, Description, IsPublic, UserId" +
                                      " FROM Files" +
                                      " WHERE FileId=@Id";
                command.Parameters.AddWithValue("@Id", fileId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedFile = new File
                        {
                            Id = (int)reader["FileId"],
                            Name = (string)reader["FileName"],
                            Content = (byte[])reader["FileContent"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Description = (string)reader["Description"],
                            IsPublic = (bool)reader["IsPublic"],
                            UserId = (int)reader["UserId"]
                        };
                    }
                }
            }

            return requestedFile;
        }

        public IEnumerable<File> GetUserFiles(int userId)
        {
            var files = new List<File>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT FileId, FileName, FileContent, CreatedDate, Description, IsPublic, UserId" +
                                      " FROM Files" +
                                      $" WHERE UserId={userId}";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        files.Add(new File
                        {
                            Id = (int)reader["FileId"],
                            Name = (string)reader["FileName"],
                            Content = (byte[])reader["FileContent"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Description = (string)reader["Description"],
                            IsPublic = (bool)reader["IsPublic"],
                            UserId = (int)reader["UserId"]
                        });
                    }
                }
            }

            return files;
        }

        public IEnumerable<File> GetFilesForRole(int roleId)
        {
            var files = new List<File>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT f.FileId, FileName, FileContent, CreatedDate, Description, IsPublic, UserId" +
                                      " FROM Files f JOIN FilesRoles fr" +
                                      " ON f.FileId = fr.FileId" +
                                      " WHERE fr.RoleId= @roleId";
                command.Parameters.AddWithValue("@roleId", roleId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        files.Add(new File
                        {
                            Id = (int)reader["FileId"],
                            Name = (string)reader["FileName"],
                            Content = (byte[])reader["FileContent"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Description = (string)reader["Description"],
                            IsPublic = (bool)reader["IsPublic"],
                            UserId = (int)reader["UserId"]
                        });
                    }
                }
            }

            return files;
        }

        public IEnumerable<File> GetAllPublicFiles()
        {
            var files = new List<File>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT FileId, FileName, FileContent, CreatedDate, Description, IsPublic, UserId" +
                                      " FROM Files" +
                                      " WHERE IsPublic = 1";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        files.Add(new File
                        {
                            Id = (int)reader["FileId"],
                            Name = (string)reader["FileName"],
                            Content = (byte[])reader["FileContent"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            Description = (string)reader["Description"],
                            IsPublic = (bool)reader["IsPublic"],
                            UserId = (int)reader["UserId"]
                        });
                    }
                }
            }

            return files;
        }
    }
}
