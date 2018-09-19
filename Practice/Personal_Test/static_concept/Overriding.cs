using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace static_concept
{
    class base_cla
    {
        int a = 10;
        public virtual void Call_me()
        {
            Console.WriteLine("this is base class:{0}", a);
        }
    
    }
    class child:base_cla
    {
        int b = 20;
        public override void Call_me()
        {
            
            Console.WriteLine("this is child class:{0}",b);
        }
    }
    class child2 : child
    {
        int b = 30;
        public new void Call_me()
        {

            Console.WriteLine("this is child class:{0}", b);
        }
    }

    class Overriding
    {
        static void Main(string[] args)
        {
            child ch = new child2();
            ch.Call_me();
            Console.Read();
        }
    }
}
