using System;

namespace Task01
{
    public static class ConsoleUI
    {
        public static Tuple<string, string> ReadStrings()
        {
            for (; ;)
            {
                Console.WriteLine("Введите первую строку:");
                var firstStr = Console.ReadLine();
                Console.WriteLine("Введите вторую строку:");
                var secondStr = Console.ReadLine();
                if (firstStr.Length > 0 && secondStr.Length > 0)
                {
                    return Tuple.Create(firstStr, secondStr);
                }

                Console.WriteLine("Ошибка! Введена пустая строка!");
            }
        }

        public static void WriteResultStr(string str)
        {
            Console.WriteLine($"Результирующая строка: {str}\n");
        }
    }
}
