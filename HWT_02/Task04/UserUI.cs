namespace Task04
{
    using System;

    public static class UserUI
    {
        public static int ReadCountStrings()
        {
            var resultInput = 0;
            for (; ;)
            {
                Console.WriteLine(MessagesResource.InputMessage);
                if (int.TryParse(Console.ReadLine(), out resultInput) && resultInput > 0)
                {
                    return resultInput;
                }

                Console.WriteLine(MessagesResource.ErrorMessage);
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
