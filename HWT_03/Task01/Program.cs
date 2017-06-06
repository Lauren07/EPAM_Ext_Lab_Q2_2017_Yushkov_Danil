using System;
using System.Text;

namespace Task01
{
    internal class Program
    {
        private static int[] GenerateIntArray(int count)
        {
            var random = new Random();
            var resultMas = new int[count];
            for (var i = 0; i < count; i++)
            {
                resultMas[i] = random.Next(200);
            }

            return resultMas;
        }

        private static void SortArray<T>(T[] array, int iStart, int iEnd)
            where T : IComparable<T>
        {
            if (iStart == iEnd)
            {
                return;
            }

            var curIndex = iStart;
            var targetElement = array[iEnd];
            for (var i = iStart; i <= iEnd - 1; i++)
            {
                if (array[i].CompareTo(targetElement) <= 0)
                {
                    Swap(ref array[i], ref array[curIndex]);
                    curIndex++;
                }
            }

            Swap(ref array[curIndex], ref array[iEnd]);
            if (curIndex > iStart)
            {
                SortArray(array, iStart, curIndex - 1);
            }

            if (curIndex < iEnd)
            {
                SortArray<T>(array, curIndex + 1, iEnd);
            }
        }

        private static void Swap<T>(ref T firstElement, ref T secondElement)
        {
            var tmp = firstElement;
            firstElement = secondElement;
            secondElement = tmp;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var lengthArray = 10;
            var intArray = GenerateIntArray(lengthArray);
            ConsoleUI.WriteArray(intArray, "Исходный массив");
            SortArray(intArray, 0, lengthArray - 1);

            ConsoleUI.WriteArray(intArray, "Отсортированный массив");
            ConsoleUI.WriteMinMax(intArray[0], intArray[lengthArray - 1]);
            Console.ReadKey();
        }
    }
}
