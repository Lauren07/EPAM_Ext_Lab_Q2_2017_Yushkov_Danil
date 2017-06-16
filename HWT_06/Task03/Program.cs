using System;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var prog = new ConsoleUI();
            while (prog.IsWork)
            {
                prog.StartMenu();
            }
        }
    }
}
