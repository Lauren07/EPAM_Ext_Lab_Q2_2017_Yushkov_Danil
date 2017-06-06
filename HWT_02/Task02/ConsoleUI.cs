namespace Task02
{
    using System;

    public static class ConsoleUI
    {
        public static int ReadCountStrings()
        {
            var resultInput = 0;
            for (; ;)
            {
                Console.WriteLine(MessagesRecource.InputMessage);
                if (int.TryParse(Console.ReadLine(), out resultInput) && resultInput > 0)
                {
                    return resultInput;
                }

                Console.WriteLine(MessagesRecource.ErrorMessage);
            }
        }

        public static void WriteResultStrings(string[] pictureStrings)
        {
            foreach (var str in pictureStrings)
            {
                Console.WriteLine(str);
            }
        }
    }
}
