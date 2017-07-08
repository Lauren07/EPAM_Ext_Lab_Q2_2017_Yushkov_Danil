using System;
using System.Text;

namespace Task02
{
    public class Program
    {
        public static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                Console.WriteLine(MessagesRescource.InputMessage);
                var str = Console.ReadLine();
                if (str == string.Empty)
                {
                    break;
                }

                Console.WriteLine(str.IsPositiveNumber() ? MessagesRescource.PositiveNumberMessage : MessagesRescource.NotPositiveNumberMessage);
            }

            Console.ReadKey();
        }

    }
}
