using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_3_9_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the values for arithmetic operation\n Please enter the F,S Double values");
            double f = Convert.ToDouble(Console.ReadLine()), s =Convert.ToDouble(Console.ReadLine()), result;
            Console.WriteLine("Please enter the num1,num2 Double values");
            int num1 = Convert.ToInt32(Console.ReadLine()), num2 = Convert.ToInt32(Console.ReadLine()), rem;
            //arithmetic operators
            result = f + s;
            Console.WriteLine("{0} + {1} = {2}", f, s, result);
            result = f - s;
            Console.WriteLine("{0} - {1} = {2}", f, s, result);
            result = f * s;
            Console.WriteLine("{0} * {1} = {2}", f, s, result);
            result = f / s;
            Console.WriteLine("{0} / {1} = {2}", f, s, result);
            rem = num1 % num2;
            Console.WriteLine("{0} % {1} and reminder is {2}", num1, num2, rem);


            //relational operator
            Console.WriteLine("Please enter two values for relatinoal operation\n Please enter the a,b values");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            if(a>b)
            {
                Console.WriteLine("a is bigger than b"); 
            }else if(a>=b)
            {
                Console.WriteLine("a is bigger or equal than b");
            }
            else if (a < b)
            {
                Console.WriteLine("b is bigger than a");
            }
            else if (a <= b)
            {
                Console.WriteLine("b is bigger or equal than a");
            }
            else if (a == b)
            {
                Console.WriteLine("a & b both are equal");
            }
            else if (a != b)
            {
                Console.WriteLine("a & b both are different values");
            }

        //logical operators 
        start:
            Console.WriteLine("Please enter the username and password");
            
            String username = Console.ReadLine();
            String userpassword = Console.ReadLine();
            if ((username == "BHARATH" || username == "bharath") && (userpassword == "mypassword"))
            {
                Console.WriteLine("Login Successful.");
                goto start2;
            }
            else
            {
                Console.WriteLine("Username or password invalid");
                
            }
            Console.WriteLine("Do you want to continue?\n 1.continue... \n2.No i am leave");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
                goto start;
            else
                goto start2;

            start2:
            //Ternary opeartor
            Console.WriteLine("Please enter value for Ternary operation");
            int number = Convert.ToInt32(Console.ReadLine());
            string result1;

            result1 = (number % 2 == 0) ? "Even Number" : "Odd Number";
            Console.WriteLine("{0} is {1}", number, result1);

            //Post and Pre increment operators
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("after post increment the operator:{0}",m++ + m++ + m++);
            Console.WriteLine("after pre increment the operator:{0}", ++m + ++m + ++m);
            Console.Read();
        }

    }
}
