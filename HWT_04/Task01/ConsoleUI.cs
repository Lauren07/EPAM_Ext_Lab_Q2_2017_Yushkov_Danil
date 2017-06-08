using System;

namespace Task01
{
    public static class ConsoleUI
    {
        public static string ReadString()
        {
            for (; ;)
            {
                Console.WriteLine($"Ключевое слово \"{MessagesResource.ExitMessage}\" для выхода из программы");
                Console.WriteLine(MessagesResource.InputMessage);
                var str = Console.ReadLine();
                if (str.Length > 0)
                {
                    return str;
                }

                Console.WriteLine(MessagesResource.EmptyStringMessage);
            }
        }

        public static void WriteAverage(double value)
        {
            Console.WriteLine($"Средняя длина слов: {value}\n");
        }
    }
}
