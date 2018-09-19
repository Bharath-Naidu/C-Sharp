using System;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collectons_namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a1 = new ArrayList();
            


           // Console.WriteLine(a1.);
            Console.WriteLine(a1.Capacity);
            Console.WriteLine(a1.Contains(2));
            Console.WriteLine(a1[1]);
            a1.RemoveAt(1);
            Console.WriteLine(a1[1]);
            Console.ReadKey();
        }
    }
}
