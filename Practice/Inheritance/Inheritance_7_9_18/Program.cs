using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_7_9_18
{
    

    class Student : PersonalDetails
    {
       
        public int Student_Rollno;
        
        public Student(int Rollno,DateTime dt)
        {
            Student_Rollno = Rollno;
            DOB = convertToAge(dt);    
        }
      
        public Student()
        {
            
        }
        public Student(int roll,DateTime _Date, String _name,String _address) : base(_name,_address)
        {

            Student_Rollno = roll;
            DOB = convertToAge(_Date);
        }
        public override void Hello()
        {
            base.Hello();
            Console.WriteLine(" be Student class");
        }
        public void Display_studentdetails()
        {
            Console.WriteLine ("Name={0}\nStudent rollno={1}\nAddress will be={2}\nage is={3}", Name, Student_Rollno,Address, DOB);
        }
    }
    class Teacher : PersonalDetails
    {
        subject[] sub = new subject[2];
        public int Mobileno;
        public int salary;
        public Teacher() { }
        public Teacher(int mobile, int sal,String str,String str2,DateTime dt) : base(str,str2)
        {
           
            Mobileno = mobile;
            salary = sal;
           DOB = convertToAge(dt);
        }
        public override void Hello()
        {
            base.Hello();
            Console.WriteLine("this is will be Student class");
        }
        public Teacher(String s1,String s2):base(s1,s2)
        {

        }
        public void Display_teacherdetails()
        {
            Console.WriteLine("Name={0}\nAddress={1}\nmobileno={2}\nsalary will be={3}\nage={4}", Name,Address,Mobileno,salary,DOB);
        }
    }
    class subject
    {
        public String subject_Name;
        public int subject_code;
        public int subject_highestmarks;
       
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Student stu = new Student(201,DateTime.Parse("11/05/1996"),"sai","vij");
            //stu.Display_studentdetails();
            //stu.Hello();
            PersonalDetails p = new Student();
            p.Hello();
            //Teacher tech = new Teacher(5521325,4500,"Bharath","hyd",DateTime.Parse("10/10/1996"));
            //tech.Display_teacherdetails();
            Console.Read();
        }
    }
}
