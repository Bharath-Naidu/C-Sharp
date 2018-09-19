using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exceptions12_9_18
{
    
    class InnerException 
    {
         static void callMe()
        {
            Basic_Exception[] b = new Basic_Exception[2];
            try
            {
                b[0].test = 0;
                Console.WriteLine("Error not generating on callme");
            }
            catch (Exception p)
            {
                Console.WriteLine("Error generating on callme");
                Console.WriteLine(p);
                //throw new Exception("error", e);

                //Exception er = new Exception();
                //throw er;

                //throw p;

                
            }
            finally
            {
                Console.WriteLine("last one in callme class");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This is main class");
                    callMe();
            }
            //catch(Exception ex)
            //{
            //    Console.WriteLine("exception in code {0}",ex);
            //}
            finally
            {
                Console.WriteLine("exception rised");
            }
            Console.Read();
        }
    }
}