using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class ConsoleOutput : IOutput
    {
        public void WriteMessage(string text)
        {
            Console.WriteLine(text);
        }
    }
}
