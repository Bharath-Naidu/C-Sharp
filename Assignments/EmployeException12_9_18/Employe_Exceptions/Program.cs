using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeException12_9_18.Employe_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Salesman sm = new Salesman();
            
            sm.Mydata();
            
            try
            {
                int i=sm.DoEmpHaveBouns();
                if(i==1)
                    sm.AddBouns();
                sm.DisplayMyDetails();
            }catch(MyException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
