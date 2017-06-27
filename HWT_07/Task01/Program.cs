using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    internal class Program
    {
        private static void CrossOut(Person[] persons)
        {
            if (persons.Length < 2)
            {
                return;
            }

            var isSecond = true;
            var newPersons = persons.Where(x =>
            {
                isSecond = !isSecond;
                return !isSecond;
            }).ToArray();
            ConsoleUI.DisplayPersons(newPersons);
            CrossOut(newPersons);
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var persons = new List<Person>();
            var count = 12;
            for (var i = 0; i < count; i++)
            {
                persons.Add(new Person($"Person{i + 1}"));
            }

            ConsoleUI.DisplayPersons(persons.ToArray());
            CrossOut(persons.ToArray());

            Console.ReadKey(); //todo pn а подождать после выполнения программы?
        }
    }
}
