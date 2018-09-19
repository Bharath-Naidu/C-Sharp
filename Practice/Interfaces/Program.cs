using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   

    class Access:IStudent
    {
        int rollno;
        String Studentname;
        int noofstudents;
        int whichclassclass;
        public Access(int r,String name,int stunds,int cls)
        {
            rollno=r;
            Studentname=name;
            noofstudents=stunds;
            whichclassclass=cls;
        }
        public void Name()
        {
            Console.WriteLine("Name of the student is {0}",Studentname);
        }
        public void NoOfstudents()
        {
            Console.WriteLine("no.of students in school is {0}", noofstudents);
        }
        public void whichClassClass()
        {
            Console.WriteLine("class of the student is {0}", whichclassclass);
        }
        public void Rollno()
        {
            Console.WriteLine("Roll number of the student is {0}", rollno);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Access ac = new Access(201,"SAI",201214,5);
            ac.Name();
            ac.Rollno();
            ac.whichClassClass();
            ac.NoOfstudents();
        }
    }
}
