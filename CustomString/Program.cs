using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomString
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString1 = new MyString(new char[] { 'a', 'b', 'c' });
            for(int i=0; i < myString1.Lenght; i++)
            {
                Console.Write(myString1[i]);
            }
            Console.WriteLine();
            myString1 = MyString.ToMyString("woooo".ToCharArray()) + new MyString(" hooo!") + new MyString(" hooo...");
            for (int i = 0; i < myString1.Lenght; i++)
            {
                Console.Write(myString1[i]);
            }
            MyString myString2 = new MyString();
            if (myString1 == null)
            {
                Console.WriteLine("MyStrings are equal");
            }
            Console.WriteLine();
            Console.WriteLine("===========================");
            MyString myString3 = new MyString();
            myString3 = myString1.Replace('o', 'a');
            Console.WriteLine();
            for (int i = 0; i < myString3.Lenght; i++)
            {
                Console.Write(myString3[i]);
            }
            Console.WriteLine();
            myString3 = myString3.SubString(4,9);
            for (int i = 0; i < myString3.Lenght; i++)
            {
                Console.Write(myString3[i]);
            }
            Console.WriteLine();
            Console.Write("Before replacement: ");
            for (int i = 0; i < myString1.Lenght; i++)
            {
                Console.Write(myString1[i]);
            }
            Console.WriteLine();
            Console.Write("After replacement: ");
            myString3 = myString1.Replace("ooo", "uuu");
            for (int i = 0; i < myString3.Lenght; i++)
            {
                Console.Write(myString3[i]);
            }
            Console.ReadKey();
        }
    }
}
