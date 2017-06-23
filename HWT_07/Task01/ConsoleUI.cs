using System;

namespace Task01
{
    public static class ConsoleUI
    {
        public static void DisplayPersons(Person[] persons)
        {
            Console.WriteLine("Список людей в кругу:");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
        }
    }
}
