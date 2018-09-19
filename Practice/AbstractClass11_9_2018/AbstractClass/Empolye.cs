using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass11_9_2018.AbstractClass
{
    abstract class Empolye
    {
        public int ID;
        public String Name;
        public String Address;
        public double Salary;
        public abstract void MySalary();
        public virtual void printAddress()
        {
            this.Address = Address;
        }
    }
}
