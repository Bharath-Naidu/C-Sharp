using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Const
    {
        static int ar = 12;
        int age;
        String name;
        
        public Const(int a,String s)
        {
            age = a;
            name = s;
        }
        
        public void display()
        {
            ar++;
            Console.WriteLine("name is {0} and age will be {1}",name,age);
            Console.WriteLine( "static values is {0}",ar );
        }
    }

    class Test
    {   
        static void Main(string[] args)
        {
            Const t = new Const(15,"bharath");
            t.display();
            Const tt = new Const(16,"sai");
            t.display();
            Console.ReadKey();
        }
    }
}
