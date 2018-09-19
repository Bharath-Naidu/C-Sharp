using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeException12_9_18.Employe_Exceptions
{

    public class Salesman : Empolye
    {
        int Bouns;
        //DateTime DateOfJoining;
        String City;
        int insen;
        public int DoEmpHaveBouns()
        {
            Console.WriteLine("Employee have Bouns \n1.Yes\n2.No\n");
            int n = Convert.ToInt32(Console.ReadLine());
            if(n==1)
            {
                Console.WriteLine("Please enter the bouns");
                insen = Convert.ToInt32(Console.ReadLine());
                return 1;
            }
            return 0;
        }
        public void AddBouns()
        {
            if(Salary==0)
            {
                throw new MyException("First provide salary");
            }else if(((Salary*10)/100)>insen)
            {
                Bouns = insen;
                Salary = Salary + Bouns;
                throw new MyException("Successfully Inserted");
            }
            else
            {
                throw new MyException("Bouns is not more than 10%");
            }

        }
        public void Mydata()
        {
            Console.WriteLine("Please Enter the id of Employee");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the name of Employee");
            Name = Console.ReadLine();
            Console.WriteLine("Please Enter the address of Employee");
            Address = Console.ReadLine();
            Console.WriteLine("Please Enter the salary of Employee");
            Salary = Convert.ToInt32(Console.ReadLine());
        }
        public override void printAddress()
        {
           
            Console.WriteLine(Address);

        }
        public void DisplayMyDetails()
        {
            Console.WriteLine("Name:{0}\nId:{1}\nAddress:{2}\nSalary:{3}\nBouns:{4}\nTotal Salary:{5}", Name, ID, Address, Salary, Bouns,Salary);
        }
        public override void MySalary()
        {
            Console.WriteLine("{0} total amount on this month {1}", Name, Salary);
        }
    }
}
