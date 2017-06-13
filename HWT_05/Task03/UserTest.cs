using System;
using NUnit.Framework;

namespace Task03
{
    public class UserTest
    {
        [Test]
        public void UserNameTest()
        {
            var firstName = "Данил";
            var secondName = "Юшков";
            var otherName = "Александрович";
            var user = new User($"{firstName} {secondName} {otherName}", DateTime.Now);
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(secondName, user.SecondName);
            Assert.AreEqual(otherName, user.OtherName);
        }

        [Test]
        public void ChangeNameTest()
        {
            var firstName = "Данил";
            var secondName = "Юшков";
            var otherName = "Александрович";
            var user = new User($"{firstName} {secondName} {otherName}", DateTime.Now);
            var newSecondName = "Иванов";
            Assert.AreEqual(secondName, user.SecondName);
            user.ChangeName($"{firstName} {newSecondName} {otherName}");
            Assert.AreEqual(newSecondName, user.SecondName);
        }

        [Test]
        public void IncorrectNameTest()
        {
            var wrongName = "Данил Юшков";
            var user = new User("Данил Юшков Александрович", DateTime.Now);
            Assert.Throws<Exception>(() => user.ChangeName(wrongName));
        }

        [Test]
        public void SecondIncorrectNameTest()
        {
            var wrongName = "Данил, Юш?ков Александрович";
            var user = new User("Данил Юшков Александрович", DateTime.Now);
            Assert.Throws<Exception>(() => user.ChangeName(wrongName));
        }

        [Test]
        public void DateBirthTest()
        {
            var expectedDate = new DateTime(1996, 7, 25);
            var user = new User("Данил Юшков Александрович", expectedDate);
            Assert.AreEqual(expectedDate, user.DateBirth);
        }

        [Test]
        public void AgeUserTest() // Тест довольно спорный :) Очевидно, через годик тест проходить не будет, но а как иначе? Программно вычислять возраст (как в классе) вроде не ок - много логики, и даже в тесте можно ошибиться.
        {							//todo pn а ты любой возраст захардкодь ("17" тот же) и DateTime относительно него задавай. Не так уж сильно уложнится тест. Зато всегда будет корректен.
            var dateBirth = new DateTime(2000, 1, 1);
            var user = new User("Данил Юшков Александрович", dateBirth);
            Assert.AreEqual(17, user.Age);
        }

        [Test]
        public void IncorrectDateTest()
        {
            var correctName = "Данил Юшков Александрович";
            var dateBirth = DateTime.Now.AddDays(20);
            Assert.Throws<Exception>(() => new User(correctName, dateBirth));
        }
    }
}
