using System;
using System.Collections.Generic;

namespace Task03
{
    public class FinderTester
    {
        private int[] array;
        private Finder finder;
        public Func<IEnumerable<int>>[] Methods;

        private bool Condition(int element)
        {
            return element > 0;
        }

        public FinderTester(int[] array)
        {
            this.array = array;
            finder = new Finder();
            Methods = new Func<IEnumerable<int>>[5];
            Methods[0] = TestFirstMethod;
            Methods[1] = TestSecondMethod;
            Methods[2] = TestThirdMethod;
            Methods[3] = TestFourthMethod;
            Methods[4] = TestFifthMethod;
        }

        private IEnumerable<int> TestFirstMethod()
        {
            return finder.FindPositiveNumbers(array);
        }

        private IEnumerable<int> TestSecondMethod()
        {
            return finder.FindPositiveNumbers(array, Condition);
        }

        private IEnumerable<int> TestThirdMethod()
        {
            ConditionSearch condition = delegate(int element)
            {
                return element > 0;
            };
            return finder.FindPositiveNumbers(array, condition);
        }

        private IEnumerable<int> TestFourthMethod()
        {
            return finder.FindPositiveNumbers(array, element => element > 0);
        }

        private IEnumerable<int> TestFifthMethod()
        {
            return finder.FindPositiveNumbersLinq(array);
        }
    }
}
