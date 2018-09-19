using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass11_9_2018.AbstractClass
{
    class Staff:Empolye
    {
        String dept;
        int Bouns;
        public void AddtoBouns(int bouns)
        {
            this.Bouns = bouns;
        }
        public override void MySalary()
        {
            Console.WriteLine("{0} is salary is {1}",Name,Salary+Bouns);
        }
        public void DisplayMyDetails()
        {
            Console.WriteLine("Name:{0}\nId:{1}\nAddress:{2}\nSalary:{3}\nDepartement:{4}\nExtra amount:{5}", Name, ID, Address, Salary, dept, Bouns);
        }
        public Staff(int id, String name, String addr, int sal)
        {
            ID = id;
            Salary = sal;
            Name = name;
            Address = addr;
        }
    }
}
