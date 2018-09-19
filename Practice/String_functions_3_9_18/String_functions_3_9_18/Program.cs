using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_functions_3_9_18
{
    class Program
    {
        static void Main(string[] args)
        {

            
            String str = "Bharath";
            str = str.ToUpper();
            Console.WriteLine("The Upper case:{0}",str);
            str = str.ToLower();
            Console.WriteLine("The lower case:{0}", str);
            str = "   this is me bharath    ";
            Console.WriteLine("Before trim:{0}", str);
            str = str.Trim();
            Console.WriteLine("After trim:{0}", str);
            bool iscontains = str.Contains("bharath");
            Console.WriteLine("bharath string is contained in the string or not:{0}",iscontains);
            iscontains = str.Contains("Manoj");
            Console.WriteLine("manoj string is contained in the string or not:{0}", iscontains);
            char[] charactersarray = str.ToCharArray();
            foreach(char c in charactersarray)
            {
                Console.WriteLine(c);
            }
            String str1 = str.Substring(0, 6);
            Console.WriteLine("sub string 0 to 6: {0}",str1);
            iscontains = str.StartsWith("me");
            Console.WriteLine("startswidth me is present on the string or not:{0}",iscontains);
            str = "this is me";
            String[] str2 = str.Split(' ');
            foreach(String s in str2)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(str.Clone());
            Console.WriteLine("the hachcode is:{0}",str.GetHashCode());
            Console.WriteLine("indicated which type of Enumarator:{0}",str.GetEnumerator());
            Console.WriteLine("Indicates which type of datatype:{0}",iscontains.GetType());
            Console.WriteLine(str.GetTypeCode());
            Console.WriteLine("return the specified address:{0}",str.IndexOf('m'));
            Console.WriteLine("Insert the string in specified locatin",str.Insert(3,"bharath"));
            Console.WriteLine("replacing the t with a:{0}",str.Replace('t','a'));
            Console.WriteLine("after deleting characters:{0}",str.Remove(5));

            Console.Read();
        }
    }
}
