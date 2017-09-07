using System;
using System.Linq;
using System.Transactions;
using DataAccessLayer.Entities;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace TestDAL
{
    public class TestFileRepository : TestBase
    {
        [TestCase("TestFile1","Description")]
        [TestCase("TestFile2", "")]
        public void TestCreateFile(string fileName, string description)
        {
            using (var scope = new TransactionScope())
            {
                var randomizer = new Random();
                var fileContent = new Byte[100];
                randomizer.NextBytes(fileContent);
                var file = Builder<File>.CreateNew()
                    .With(s => s.CreatedDate = DateTime.Now)
                    .With(s => s.Description = fileName)
                    .With(s => s.Name = description)
                    .With(s => s.UserId = TestUser.Id)
                    .With(s => s.Content = fileContent)
                    .Build();
                var fileId = Repositories.FileRepository.CreateFile(file);
                Assert.AreNotEqual(0, fileId);
            }
        }

        [Test]
        public void TestFindFile()
        {
            using (var scope = new TransactionScope())
            {
                var foundFile = Repositories.FileRepository.FindFile(TestFile.Id);
                Assert.IsNotNull(foundFile);
                Assert.AreEqual(TestFile.Name, foundFile.Name);
            }
        }

        [Test]
        public void TestUpdateFile()
        {
            using (var scope = new TransactionScope())
            {
                Assert.AreNotEqual(0, TestFile.Id);
                var oldName = TestFile.Name;
                TestFile.Name = "ChangedName";
                Repositories.FileRepository.UpdateFile(TestFile);
                var changedFile = Repositories.FileRepository.FindFile(TestFile.Id);
                Assert.NotNull(changedFile);
                Assert.AreEqual(TestFile.Name,changedFile.Name);
                TestFile.Name = oldName;
            }
        }

        [Test]
        public void TestFileRoles()
        {
            using (var scope = new TransactionScope())
            {
                Repositories.FileRepository.AddRoleForFile(TestFile.Id,TestRole.Id);
                var fileRoles = Repositories.FileRepository.GetRolesFile(TestFile.Id);
                Assert.IsNotNull(fileRoles);
                Assert.IsTrue(fileRoles.Count()==1);
                Assert.AreEqual(TestRole.Id,fileRoles.FirstOrDefault().Id);
            }
        }

        [Test]
        public void TestDeleteFile()
        {
            using (var scope = new TransactionScope())
            {
                Repositories.FileRepository.DeleteFile(TestFile.Id);
                var file = Repositories.FileRepository.FindFile(TestFile.Id);
                Assert.IsNull(file);
            }
        }
    }
}
