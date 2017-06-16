using System;
using System.Linq;

namespace Task01
{
    public class User
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public string OtherName { get; private set; }

        private DateTime dateBirth;

        public DateTime DateBirth
        {
            get
            {
                return this.dateBirth;
            }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Not-existent date.");
                }

                this.dateBirth = value;
            }
        }

        public int Age
        {
            get
            {
                var timeNow = DateTime.Now;
                var years = timeNow.Year - this.DateBirth.Year;
                if (timeNow.Month < this.DateBirth.Month ||
                    (timeNow.Month == this.DateBirth.Month && timeNow.Day <= this.DateBirth.Day))
                {
                    years--;
                }

                return years;
            }
        }

        public User(string fullName, DateTime dateBirth)
        {
            this.ChangeName(fullName);
            this.DateBirth = dateBirth;
        }

        public void ChangeName(string fullName)
        {
            if (fullName.Any(c => !char.IsLetter(c) && !char.IsSeparator(c) && c != '-'))
            {
                throw new Exception("Found forbidden chars.");
            }

            var names = fullName.Split(' ');
            if (names.Length != 3 || names.Any(name => name.Length == 0))
            {
                throw new Exception("Invalid name format.");
            }

            this.FirstName = names[0];
            this.SecondName = names[1];
            this.OtherName = names[2];
        }
    }
}
