using System;
using System.Text;

namespace Task01
{
    public class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                var array = ConsoleUI.ReadArray();
                if (array == null)
                {
                    break;
                }

                var sum = array.SumElements();
                ConsoleUI.WriteSum(sum);
            }

            Console.ReadKey();
        }
    }
}
