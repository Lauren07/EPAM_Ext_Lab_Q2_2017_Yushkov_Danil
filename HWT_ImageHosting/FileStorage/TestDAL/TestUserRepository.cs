using System;
using System.Transactions;
using DataAccessLayer.Entities;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace TestDAL
{
    public class TestUserRepository : TestBase
    {

        [TestCase("TestUser1","1234")]
        [TestCase("TestUser2","ads23sadsa")]
        public void TestCreateUser(string userName, string password)
        {
            using (var scope= new TransactionScope())
            {
                var user = Builder<User>.CreateNew()
                    .With(s => s.Login = userName)
                    .With(s => s.HashPassword = new Guid(s.GenerateHashPass(password)))
                    .With(s => s.Role = TestRole)
                    .Build();
                var userId = Repositories.UserRepository.CreateUser(user);
                Assert.AreNotEqual(0, userId);
            }
        }

        [Test]
        public void TestCreateFindUser()
        {
            using (var scope = new TransactionScope())
            {
                var user = Builder<User>.CreateNew()
                    .With(s => s.Login = "TestUser1")
                    .With(s => s.HashPassword = new Guid(s.GenerateHashPass("1234")))
                    .With(s => s.Role = TestRole)
                    .Build();
                var userId = Repositories.UserRepository.CreateUser(user);
                Assert.AreNotEqual(0,userId);
                var findedUser = Repositories.UserRepository.FindUser(userId);
                Assert.IsNotNull(findedUser);
            }
        }

        [Test]
        public void TestCreateRole()
        {
            using (var scope = new TransactionScope())
            {

                var role = new Role(0,"Role1");
                var roleId = Repositories.UserRepository.CreateRole(role);
                Assert.AreNotEqual(0,roleId);
            }
        }

        [Test]
        public void TestFindUserRole()
        {
            using (var scope = new TransactionScope())
            {
                var user = Builder<User>.CreateNew()
                    .With(s => s.Login = "TestUserForRole")
                    .With(s => s.HashPassword = new Guid(s.GenerateHashPass("1234")))
                    .With(s => s.Role = TestRole)
                    .Build();
                var userId = Repositories.UserRepository.CreateUser(user);
                Assert.AreNotEqual(0,userId);
                var role = Repositories.UserRepository.GetUserRole(user.Login);
                Assert.IsNotNull(role);
                Assert.AreEqual(user.Role.Id,role.Id);
            }
        }
    }
}
