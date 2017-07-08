using System;
using System.Linq;

namespace Task01
{
    public static class ConsoleUI
    {
        public static int[] ReadArray()
        {
            for (; ;)
            {
                Console.WriteLine(MessagesResource.InputMessage);
                var strArr = (Console.ReadLine() ?? string.Empty).Split(' ').Where(str => str.Length > 0).ToArray();
                if (strArr.Length < 1)
                {
                    return null;
                }

                var resultArr = new int[strArr.Length];
                var isError = false;
                for (var i = 0; i < strArr.Length; i++)
                {
                    if (!int.TryParse(strArr[i], out resultArr[i]))
                    {
                        isError = true;
                        break;
                    }
                }

                if (!isError)
                {
                    return resultArr;
                }

                Console.WriteLine(MessagesResource.ErrorMessage);
            }
        }

        public static void WriteSum(int sum)
        {
            Console.WriteLine(MessagesResource.OutputMessage + sum);
        }
    }
}
