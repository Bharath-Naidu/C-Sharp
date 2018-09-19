using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Student
    {
        public int Rollno;
        public String Name;
        public int Grade;
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] stu = new Student[100];
            int []grade = new int[12];
            for(int i=0;i<stu.Length;i++)
            {
            
                stu[i] = new Student();

                Console.WriteLine("Hello!! User......\nPlease Enter the Rollnumber of the student");
                stu[i].Rollno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter the Name of the student");
                stu[i].Name = Convert.ToString(Console.ReadLine());
                start:Console.WriteLine("Please Enter the garde of the student");
                Char g= Convert.ToChar(Console.ReadLine());
                
                int gg;
                if(g>='a' &&'l'>=g)gg = g - 97;
                else if(g >= 'A' && 'L' >= g)gg = g - 65;
                else gg = g-49;
                if (gg<=12)
                {
                    stu[i].Grade=g;
                }else
                {
                    Console.WriteLine("You entered {0} class is not exist in the school.So please try again",g);
                    goto start;
                }
                grade[gg]++;
                Console.WriteLine("Soo do u want to continue insert the data\n1.Yes i'm Continue\n2.No i want total no.of students\n3.No leave me");
                int User_decision= Convert.ToInt32(Console.ReadLine());
                if (User_decision != 1)
                    break;
                
            }
            Console.WriteLine("Hello user here below total no.of students");
            for (int i=0;i<12;i++)
            {
                Console.WriteLine("The {0} grade students are:{1}", i + 1, grade[i]);
            }
            Console.WriteLine("Okay");
            Console.Read();
        }
    }
}
