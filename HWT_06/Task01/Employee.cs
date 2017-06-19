using System;

namespace Task01
{
    public class Employee : User
    {
        private int lengthWork;

        public int LengthWorkInYears//todo pn нет проверки на то, что он меньше возраста
        {
            get
            {
                return this.lengthWork;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Incorrect Length of work.");
                }

                this.lengthWork = value;
            }
        }

        private string appointment;

        public string Appointment
        {
            get
            {
                return this.appointment;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Incorrect field format Appointment.");
                }

                this.appointment = value;
            }
        }

        public Employee(string fullName, DateTime dateBirth)
            : base(fullName, dateBirth)
        { }
    }
}
