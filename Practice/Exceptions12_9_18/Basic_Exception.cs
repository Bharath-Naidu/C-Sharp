using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions12_9_18
{

    

   class Basic_Exception
    {
        public int test = 90;
        static void Main(string[] args)
        {
            int a = 20;
            int b = 0;
            int c;
            int[] arr = new int[2];
            try
            {
                Console.WriteLine("its come in try block");
                c = a / b;
                Console.WriteLine("the output of the inputs {0}",c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                try
                {
                    c =  arr[2]/ b;
                    Console.WriteLine("Inner try");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("the output of the inputs {0}", ex);
                }
            }
            finally
            {
                Console.WriteLine("Finally block is executed");
            }
            Console.ReadKey();
        }
       
    }
}
    