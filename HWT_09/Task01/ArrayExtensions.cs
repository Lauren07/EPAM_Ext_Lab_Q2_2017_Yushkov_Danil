using System.Collections.Generic;

namespace Task01
{
    public static class ArrayExtensions
    {
        public static int SumElements(this IEnumerable<int> array)//todo pn а демо?
        {
            var sum = 0;
            foreach (var element in array)
            {
                sum += element;
            }

            return sum;
        }
    }
}
