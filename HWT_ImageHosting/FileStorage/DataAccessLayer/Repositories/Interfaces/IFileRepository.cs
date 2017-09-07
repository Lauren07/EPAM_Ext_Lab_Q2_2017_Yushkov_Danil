using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IFileRepository
    {
        File FindFile(int fileId);
        void DeleteFile(int fileId);
        int CreateFile(File file);
        void UpdateFile(File file);
        void RemoveFileRoles(int fileId);
        IEnumerable<File> GetAllPublicFiles();
        IEnumerable<File> GetUserFiles(int userId);
        void AddRoleForFile(int fileId, int roleId);
        IEnumerable<File> GetFilesForRole(int roleId);
        IEnumerable<Role> GetRolesFile(int fileId);
    }
}
