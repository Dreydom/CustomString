using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomString
{
    class MyString
    {
        private char[] str;
        public MyString()
        {
            str = new char[256];
        }
        public MyString(int init_size)
        {
            str = new char[init_size];
        }
        public MyString(String StdStr)
        {
            str = new char[StdStr.Length];
            str = StdStr.ToCharArray();
        }
        public MyString(char[] arr)
        {
            str = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                str[i] = arr[i];
            }
        }
        public MyString(MyString previousMyString)
        {
            if (this == previousMyString)
            {
                throw new ArgumentException("Нельзя копировать строку саму в себя!");
            }
            str = new char[previousMyString.str.Length];
            for (int i = 0; i < previousMyString.str.Length; i++)
            {
                str[i] = previousMyString.str[i];
            }
        }

        public int Lenght
        {
            get
            {
                return str.Length;
            }
            set
            {
                char[] temp = new char[value];
                if (value > str.Length)
                {
                    value = str.Length;
                }
                for (int i = 0; i < value; i++)
                {
                    temp[i] = str[i];
                    str = temp;
                }
            }
        }
        public char this[int index]
        {
            get
            {
                return str[index];
            }
            set
            {
                str[index] = value;
            }
        }
        public static MyString operator +(MyString s1, MyString s2)
        {
            int L = s1.str.Length + s2.str.Length;
            var sumstr = new MyString(L);
            for (int i = 0; i < s1.str.Length; i++)
            {
                sumstr[i] = s1[i];
            }
            for (int i = 0; i < s2.str.Length; i++)
            {
                sumstr[s1.str.Length + i] = s2[i];
            }
            return sumstr;
        }
        public static bool operator ==(MyString s1, MyString s2)
        {
            if ((object)s1==null || (object)s2 == null)
            {
                return false;
            }
            if (s1.str.Length != s2.str.Length)
            {
                return false;
            }
            for (int i = 0; i < s1.str.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyString s1, MyString s2)
        {
            return !(s1 == s2);
        }

        public static explicit operator String(MyString MyStr)
        {
            return new String(ToArray(MyStr));
        }
        public static MyString ToMyString(char[] arr)
        {
            MyString res = new MyString(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                res.str[i] = arr[i];
            }
            return res;
        }
        public static implicit operator MyString(String Str)
        {
            return new MyString(ToMyString(Str.ToCharArray()));
        }
        public int Find(MyString findstr)
        {
            if (Lenght < findstr.Lenght)
            {
                return -1;
            }
            for (int i = 0; i < Lenght - findstr.Lenght; i++)
            {
                for (int j = 0; j < findstr.Lenght; j++)
                {
                    if (str[i + j] != findstr[j]) { goto P1; }
                }
                return i;
                P1:;
            }
            return -1;
        }
        public int Find(char symbol)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (str[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }

        public MyString SubString(int i)
        {
            int l = str.Length - i;
            MyString result = new MyString(l);
            for (int inew = 0; inew < l; inew++)
            {
                result[inew] = str[i + inew];
            }
            return result;
        }
        public MyString SubString(int i, int j)
        {
            int l = j - i;
            MyString result = new MyString(l);
            for (int inew = 0; inew < l; inew++)
            {
                result[inew] = str[i + inew];
            }
            return result;
        }
        public MyString Copy()
        {
            MyString result = new MyString(str);
            return result;
        }
        public MyString Replace(char oldChar, char newChar)
        {
            MyString result = Copy();
            for(int i = 0; i < result.Lenght;i++)
            {
                if (result[i] == oldChar) result[i] = newChar;
            }
            return result;
        }
        public MyString Replace(string oldStr, string newStr)
        {
            MyString result = Copy();
            for (int i = 0; i < result.Lenght - oldStr.Length; i++)
            {
                bool match = false;
                if (result[i] == oldStr[0])
                {
                    match = true;
                    int j;
                    for (j = 1; j < oldStr.Length; j++)
                    {
                        if (result[i + j] != oldStr[j])
                        {
                            match = false;
                            break;
                        }

                    }
                    if (match == true)
                    {
                        MyString temp = result.Copy();
                        result = temp.SubString(0, i) + new MyString(newStr) + temp.SubString(i + oldStr.Length, temp.Lenght);
                    }
                    else i += j;
                }
            }
            return result;

        }
        public static char[] ToArray(MyString MyStr)
        {
            char[] res = new char[MyStr.Lenght];
            for (int i = 0; i < MyStr.Lenght; i++)
            {
                res[i] = MyStr.str[i];
            }
            return res;
        }

        public override int GetHashCode()
        {
            var hashCode = -165003458;
            hashCode = hashCode * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(str);
            hashCode = hashCode * -1521134295 + Lenght.GetHashCode();
            hashCode = hashCode * -1521134295 + this.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var @string = obj as MyString;
            return @string != null &&
                   EqualityComparer<char[]>.Default.Equals(str, @string.str) &&
                   Lenght == @string.Lenght;
        }
    }
}
