using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer
{
    public class FileService
    {
        private RepositoriesFactory repositories;

        public FileService()
        {
            repositories = new RepositoriesFactory();
        }

        public FileDTO FindFile(int fileId)
        {
            var file = Mapper.Map<File, FileDTO>(repositories.FileRepository.FindFile(fileId));
            file.User = repositories.UserRepository.FindUser(file.User.Id);
            file.RolesId = repositories.FileRepository.GetRolesFile(fileId).Select(role => role.Id);
            return file;
        }

        public bool UserHasAccessToFile(int fileId, string userLogin)
        {
            var file = repositories.FileRepository.FindFile(fileId);
            if (file.IsPublic)
            {
                return true;
            }

            if (userLogin == null)
            {
                return false;
            }

            var user = repositories.UserRepository.FindUser(userLogin);
            var fileRoles = repositories.FileRepository.GetRolesFile(fileId);
            return file.UserId == user.Id || fileRoles.Any(role => role.Id == user.Role.Id);
        }

        public void LoadFile(FileDTO file)
        {
            var preparedFile = Mapper.Map<FileDTO, File>(file);
            preparedFile.CreatedDate = DateTime.Now;
            file.Id = repositories.FileRepository.CreateFile(preparedFile);
            SetAccessFile(file);
        }

        public void RemoveFile(int fileId)
        {
            repositories.FileRepository.DeleteFile(fileId);
        }

        public void UpdateFile(FileDTO file)
        {
            var preparedFile = Mapper.Map<FileDTO, File>(file);
            repositories.FileRepository.UpdateFile(preparedFile);
            repositories.FileRepository.RemoveFileRoles(preparedFile.Id);
            SetAccessFile(file);
        }

        public void SetAccessFile(FileDTO file)
        {
            if (!file.IsPublic)
            {
                foreach (var roleId in file.RolesId)
                {
                    repositories.FileRepository.AddRoleForFile(file.Id, roleId);
                }
            }
        }

        public IEnumerable<FileInfoDTO> GetAllAvailableFiles(User user)
        {
            IEnumerable<File> availableFiles;
            if (user == null)
            {
                availableFiles = repositories.FileRepository.GetAllPublicFiles();
            }
            else
            {
                availableFiles = repositories.FileRepository.GetFilesForRole(user.Role.Id)
                    .Concat(repositories.FileRepository.GetAllPublicFiles())
                    .Concat(repositories.FileRepository.GetUserFiles(user.Id))
                    .Distinct(EqualityComparer<File>.Default);
            }

            return Mapper.Map<IEnumerable<File>, IEnumerable<FileInfoDTO>>(availableFiles);
        }

        public IEnumerable<FileInfoDTO> GetUserFiles(User user)
        {
            var availableFiles = repositories.FileRepository.GetUserFiles(user.Id);
            return Mapper.Map<IEnumerable<File>, IEnumerable<FileInfoDTO>>(availableFiles);
        }
    }
}
