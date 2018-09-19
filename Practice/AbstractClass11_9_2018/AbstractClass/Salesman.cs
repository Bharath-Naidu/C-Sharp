using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass11_9_2018.AbstractClass
{
    class Salesman : Empolye
    {
        int Insentives;
        DateTime DateOfJoining;
        String City;
        public void Mydata(String area,int insen)
        {
            Insentives = insen;
            this.City = area;
            //DateOfJoining = dt;

        }
        public Salesman(int id,String name,String addr,int sal)
        {
            ID =id;
            Salary = sal;
            Name = name;
            Address = addr;

        }
        public override void printAddress()
        {
            base.printAddress();
            Address = "Sri Hari kota";
            Console.WriteLine(Address);

        }
        public void DisplayMyDetails()
        {
            Console.WriteLine("Name:{0}\nId:{1}\nAddress:{2}\nSalary:{3}\nInsentives:{4}\nCity:{5}\nDate of join:{6}",Name,ID, Address,Salary,Insentives,City,DateOfJoining);
        }
        public override void MySalary()
        {
            Console.WriteLine("{0} total amount on this month {1}",Name,Salary+Insentives);
        }
    }
}
