using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass11_9_2018.AbstractClass
{
    class Manager:Empolye
    {
        int Stock;
        int ExtraAmount;
        public override void MySalary()
        {
            Console.WriteLine("{0} total salary of this month {1}", Name,ExtraAmount + Salary);
        }
        public Manager(int id, String name, String addr, int sal)
        {   
            ID = id;
            Salary = sal;
            Name = name;
            Address = addr;

        }
        public void AddExtra(int extra)
        {
            ExtraAmount = extra; 
        }
        public void DisplayMyDetails()
        {
            Console.WriteLine("Name:{0}\nId:{1}\nAddress:{2}\nSalary:{3}\nStock left:{4}\nExtra amount:{5}", Name, ID, Address, Salary, Stock, ExtraAmount);
        }
        
    }
}
