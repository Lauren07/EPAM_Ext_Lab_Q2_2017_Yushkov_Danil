using System;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace TestDAL
{
    [TestFixture]
    public class TestBase
    {
        protected Role TestRole;
        protected User TestUser;
        protected File TestFile;
        protected RepositoriesFactory Repositories;

        [TestFixtureSetUp]
        public void SetUp()
        {
            Repositories = new RepositoriesFactory();
            TestRole = new Role(0,"RoleForTests");
            TestRole.Id = Repositories.UserRepository.CreateRole(TestRole);

            TestUser = Builder<User>.CreateNew()
                .With(s => s.Role = TestRole)
                .With(s => s.Login = "UserForTests")
                .With(s => s.HashPassword = new Guid(s.GenerateHashPass("1234")))
                .Build();
            TestUser.Id = Repositories.UserRepository.CreateUser(TestUser);

            var randomizer = new Random();
            var fileContent = new Byte[100];
            randomizer.NextBytes(fileContent);
            TestFile = Builder<File>.CreateNew()
                .With(s => s.CreatedDate = DateTime.Now)
                .With(s => s.Description = "Description")
                .With(s => s.Name = "FileForTests")
                .With(s => s.UserId = TestUser.Id)
                .With(s => s.Content = fileContent)
                .Build();
            TestFile.Id = Repositories.FileRepository.CreateFile(TestFile);
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            Repositories.FileRepository.DeleteFile(TestFile.Id);
            Repositories.UserRepository.DeleteUser(TestUser.Login);
            Repositories.UserRepository.DeleteRole(TestRole.Id);
        }
    }
}
