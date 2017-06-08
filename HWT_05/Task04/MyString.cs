using System;
using System.Collections.Generic;
using System.Linq;

namespace Task04
{
    public class MyString : IEnumerable<char>
    {
        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= this.str.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.str[index];
            }

            set
            {
                if (index < 0 || index >= this.str.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.str[index] = value;
            }
        }

        public static explicit operator char[](MyString str1)
        {
            return str1.ToArray();
        }

        public static bool operator ==(MyString str1, MyString str2)
        {
            if (str1.Count() != str2.Count())
            {
                return false;
            }

            for (var i = 0; i < str1.Count(); i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyString str1, MyString str2)
        {
            if (str1.Count() != str2.Count())
            {
                return true;
            }

            for (var i = 0; i < str1.Count(); i++)
            {
                if (str1[i] != str2[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            str1.Append((char[])str1);
            return str1;
        }

        private List<char> str;

        public MyString()
        {
            this.str = new List<char>();
        }

        public MyString(char[] chars)
        {
            this.str = new List<char>();
            this.Append(chars);
        }

        public bool Contains(MyString substring)
        {
            var subStrLength = substring.Count();
            var strLength = this.str.Count;
            if (subStrLength > strLength)
            {
                return false;
            }

            for (var i = 0; i < (strLength - subStrLength + 1); i++)
            {
                var mismatch = false;
                for (var j = 0; j < subStrLength; j++)
                {
                    if (this[i + j] != substring[j])
                    {
                        mismatch = true;
                        break;
                    }
                }

                if (!mismatch)
                {
                    return true;
                }
            }

            return false;
        }

        public void Append(char[] appStr)
        {
            this.str.AddRange(appStr);
        }

        public void Append(char c)
        {
            this.str.Add(c);
        }

        public int Count()
        {
            return this.str.Count;
        }

        public override string ToString()
        {
            return new string(this.str.ToArray());
        }

        public override int GetHashCode()
        {
            var result = 0;
            for (var i = 0; i < this.Count(); i++)
            {
                result += this.str[i] * (i + 1);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var item = obj as MyString;
            if (item == null)
            {
                return false;
            }

            return this.str.Equals(item.ToList());
        }

        public IEnumerator<char> GetEnumerator()
        {
            var curI = 0;
            while (curI != this.Count())
            {
                yield return this.str[curI];
                curI++;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
