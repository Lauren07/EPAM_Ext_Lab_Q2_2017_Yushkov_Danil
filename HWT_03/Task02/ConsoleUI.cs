using System;

namespace Task02
{
    public static class ConsoleUI
    {
        public static void WriteArray(int[][][] array, string nameArray)
        {
            Console.WriteLine(nameArray + ":");
            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine($"{i}-ое измерение:");
                for (var j = 0; j < array[i].Length; j++)
                {
                    for (var t = 0; t < array[i][j].Length; t++)
                    {
                        Console.Write("{0,4}", array[i][j][t]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("\n");
            }
        }
    }
}
