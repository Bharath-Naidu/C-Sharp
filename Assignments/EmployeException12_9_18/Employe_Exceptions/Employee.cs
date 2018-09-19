using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeException12_9_18.Employe_Exceptions
{
    public abstract class Empolye
    {
        public int ID;
        public String Name;
        public String Address;
        public double Salary;

        public abstract void MySalary();
        public virtual void printAddress()
        {
            
        }
    }
}
