using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Student_class_Main
    {
        public int Rollno;
        public String Name;
        public int Grade;
        public int[] Marks = new int[6];
        public float avg;
    }

    class Student_grade_First_one
    {
        static void Main(string[] args)
        {
            String[] Subject = new String[6];
            Console.WriteLine("Please enter the student subjects names");
            for (int j = 0; j < 6; j++)
            {
                Subject[j] = Convert.ToString(Console.ReadLine());
            }

            int K = -1;
            int[] Temp_rollno = new int[100];
            String[] Temp_name = new String[100];
            float[] Temp_avg = new float[100];
            String[] Temp_Name = new String[6];
            int[] Temp_subject_marks = new int[6] { 0, 0, 0, 0, 0, 0 };
            Student_class_Main[] stu = new Student_class_Main[100];
            int[] grade = new int[12];
            for (int i = 0; i < stu.Length; i++)
            {
                float Total = 0;
                stu[i] = new Student_class_Main();
                K++;
                Console.WriteLine("Hello!! User......\nPlease Enter the Rollnumber of the student");
                stu[i].Rollno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter the Name of the student");
                stu[i].Name = Convert.ToString(Console.ReadLine());
            start: Console.WriteLine("Please Enter the garde of the student");
                Char g = Convert.ToChar(Console.ReadLine());
                int gg;
                if (g >= 'a' && 'l' >= g) gg = g - 97;
                else if (g >= 'A' && 'L' >= g) gg = g - 65;
                else gg = g - 49;
                if (gg <= 12)
                {
                    stu[i].Grade = g;
                }
                else
                {
                    Console.WriteLine("You entered {0} class is not exist in the school.So please try again", g);
                    goto start;
                }
                grade[gg]++;
                Console.WriteLine("Please enter the student subjects marks");
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("{0}=", Subject[j]);
                    stu[i].Marks[j] = Convert.ToInt32(Console.ReadLine()); Total += stu[i].Marks[j];
                    if (stu[i].Marks[j] > Temp_subject_marks[j])
                    {
                        Temp_subject_marks[j] = stu[i].Marks[j];
                        Temp_Name[j] = stu[i].Name;
                    }
                }

                stu[i].avg = Total / 600 * 100;

                Temp_rollno[K] = stu[i].Rollno;
                Temp_name[K] = stu[i].Name;
                Temp_avg[K] = stu[i].avg;

                //Console.WriteLine(Temp_rollno[K]);
                //Console.WriteLine(Temp_name[K]);
                //Console.WriteLine(Temp_avg[K]);
                Console.WriteLine("Soo do u want to continue insert the data\n1.Yes i'm Continue\n2.No i want total no.of students\n3.No leave me");
                int User_decision = Convert.ToInt32(Console.ReadLine());
                if (User_decision != 1)
                    break;
            }
            Console.WriteLine("Hello user here below total no.of students");
            for (int i = 0; i < 12; i++)
                Console.WriteLine("The {0} grade students are:{1}", i + 1, grade[i]);
            Console.WriteLine("Subject\tName of student\tMarks ");
            

            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine(Subject[j] + "\t" + Temp_Name[j] + "\t" + Temp_subject_marks[j]);
            }
            K++;
            for (int z = 0; z < K; z++)
            {
                for (int j = 0; j < K - 1 - z; j++)
                {
                    if (Temp_avg[j] > Temp_avg[j + 1])
                    {
                        float t = Temp_avg[j];
                        Temp_avg[j] = Temp_avg[j + 1];
                        Temp_avg[j + 1] = t;

                        int r = Temp_rollno[j];
                        Temp_rollno[j] = Temp_rollno[j + 1];
                        Temp_rollno[j + 1] = r;

                        String st = String.Copy(Temp_name[j]);
                        Temp_name[j] = String.Copy(Temp_name[j + 1]);
                        Temp_name[j + 1] = String.Copy(st);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Rollno\tName of student\tPersentage");
         
            for (int j = K - 1; j >= 0; j--)
            {
                Console.WriteLine(Temp_rollno[j] +"\t" + Temp_Name[j] +"\t" + Temp_avg[j]);
            }

            Console.Read();
        }


    }
}
