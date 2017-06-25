using System;
using System.Collections.Generic;

namespace Task01
{
    public class StringComparer : IComparer<string>
    {
        private readonly Func<string, string, int> funcCompare;

        public StringComparer(Func<string, string, int> funcCompare)
        {
            if (funcCompare == null)
            {
                throw new Exception("Compare function can't be empty.");
            }

            this.funcCompare = funcCompare;
        }

        public int Compare(string x, string y)
        {
            return this.funcCompare.Invoke(x, y);
        }
    }
}
