using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace static_concept
{
    public static class static_Class1
    {
        //public int non = 1;
         public static int a = 2;
        public static void static_call()
        {
            Console.WriteLine("static class");
        }
        public static void static_call(int a)
        {
            Console.WriteLine("static class");
        }
    }

    class Non
    {
        public static int non_a = 1;
        int non_b = 2;
        static Non()
        {

        }
        public static void call()
        {
            static_Class1.a++;
            static_Class1.static_call();
        }
        public static void call(int a)
        {

        }
    }
    static class static_class2
    {
        static void call()
        {
            Non.non_a = 2;
            Non.call();
        }
    }







    class static_Progaram
    {
        static void Main(string[] args)
        {        
        }
    }
}
