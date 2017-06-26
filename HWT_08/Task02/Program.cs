using System;
using System.Text;

namespace Task02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var office = new Office();
            var persons = new[] { new Person("Иван"), new Person("Петр"), new Person("Федор"), new Person("Виктор") };
            var time = new DateTime(2000, 1, 1, 8, 0, 0);
            office.AddPerson(persons[0], time);
            office.AddPerson(persons[1], time.AddHours(5));
            office.AddPerson(persons[2], time.AddHours(10));
            office.DeletePerson(persons[1]);
            office.AddPerson(persons[3], time);

	        Console.ReadKey();//todo pn атата
        }
    }
}
