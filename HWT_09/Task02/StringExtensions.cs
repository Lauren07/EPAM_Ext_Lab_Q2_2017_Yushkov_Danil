using System.Linq;

namespace Task02
{
    public static class StringExtensions
    {
        public static bool IsPositiveNumber(this string str)//todo pn а демо?
		{
            return str.All(c => char.IsNumber(c)) && str.Any(c => c != '0');
        }
    }
}
