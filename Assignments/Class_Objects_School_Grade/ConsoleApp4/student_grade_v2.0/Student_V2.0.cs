using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.student_grade_v2._0
{
    class Student_details
    {
        public int Rollno;
        public String Name;
        public int Grade;
        public int[] Marks = new int[6];
        public float Persentage;
       
    }
    class subjects
    {
        public Student_details student;
        public int Highestmarks;
        public String subject;
    }
    class Student_V2
    {
        static subjects[] sub = new subjects[6];
        static Student_details[] stu = new Student_details[100];
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the subject first");
            for (int seq = 0; seq < sub.Length; seq++)
            {
                sub[seq] = new subjects();
                sub[seq].subject = Convert.ToString(Console.ReadLine());

            }

            int i;
            for (i = 0; i < stu.Length; i++)
            {
                float Total = 0;
                stu[i] = new Student_details();
                Console.WriteLine("Hello!! User......\nPlease Enter the Rollnumber of the student");
                stu[i].Rollno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter the Name of the student");
                stu[i].Name = Convert.ToString(Console.ReadLine());
                start: Console.WriteLine("Please Enter the garde of the student");
                int tempgrade = Convert.ToInt32(Console.ReadLine());
                if (tempgrade <= 12)
                {
                    stu[i].Grade = tempgrade;
                }
                else
                {
                    Console.WriteLine("You entered {0} class is not exist in the school.So please try again", tempgrade);
                    goto start;
                }
                Console.WriteLine("Please enter the student subjects marks");
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("{0}=", sub[j].subject);
                    stu[i].Marks[j] = Convert.ToInt32(Console.ReadLine());
                    Total += stu[i].Marks[j];
                }
                stu[i].Persentage = ((Total / sub.Length) * 100) * 100;
                if(i==0)
                {
                    for (int seq = 0; seq < 6; seq++)
                    {
                        sub[seq].Highestmarks = stu[i].Marks[seq];
                        sub[seq].student = stu[i];
                    }
                }
                else
                {
                    student_highest(stu[i]);
                }

                if (i != 0)
                    swaphigheststudent(i);        

                Console.WriteLine("Soo do u want to continue insert the data\n1.Yes i'm Continue\n2.No i want total no.of students\n3.No leave me");
                int User_decision = Convert.ToInt32(Console.ReadLine());
                if (User_decision != 1)
                    break;

            }
            Console.WriteLine("Subject\tName of student\tMarks ");

            for (int j = 0; j <6; j++)
            {
                Console.WriteLine(sub[j].subject+ "\t" +sub[j].student.Name+"\t"+sub[j].Highestmarks);
            }
            Console.WriteLine("Rollno\tName of student\tPersentage");
            for (int j = 0; j <= i; j++)
            {
                Console.WriteLine(stu[j].Rollno + "\t" + stu[j].Name + "\t" + stu[j].Persentage);
            }
            Console.ReadKey();
        }
        static void student_highest(Student_details s)
        {
            for(int seq=0;seq<sub.Length;seq++)
            {
                if (sub[seq].Highestmarks < s.Marks[seq])
                {
                    sub[seq].Highestmarks = s.Marks[seq];
                    sub[seq].student = s;
                }
            }
        }
        static void swaphigheststudent(int n)
        {
            Student_details s1 = new Student_details();
            for(int seq = n;seq > 0;seq--)
            {
                if (stu[seq].Persentage > stu[seq - 1].Persentage)
                {
                    s1 = stu[seq - 1];
                    stu[seq - 1] = stu[seq];
                    stu[seq] = s1;
                }
                else break;
            }
        }
    }
}
