using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass11_9_2018.AbstractClass
{

    class Program
    {
        static void Main(string[] args)
        {
            Salesman s = new Salesman(443, "hari", "Hydrabad", 10000);
            Manager m = new Manager(45, "Ram", "Vijayawada", 20000);
            Staff st = new Staff(47, "Venu", "Vizag", 250000);
            
            s.Mydata("Hydrabad", 1500);
            s.printAddress();
            s.DisplayMyDetails();
            
            Console.WriteLine("\n");
            m.AddExtra(2000);
            m.DisplayMyDetails();
            m.MySalary();
            Console.WriteLine("\n");
            st.AddtoBouns(1200);
            st.DisplayMyDetails();
            st.MySalary();
            Console.Read();
        }
    }
}
