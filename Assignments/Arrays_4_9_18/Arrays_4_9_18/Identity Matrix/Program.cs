using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_4_9_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the how many elements do you want??");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[n,n];
            

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (i == j)
                        arr[i, j] = 1;
                    else
                        arr[i, j] = 0;

                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j]+" ");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
