using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
    {
        static void Main(string[] args)
        {
        int t = Convert.ToInt32(Console.ReadLine());
        while(t>0)
        {
            t--;
            int n= Convert.ToInt32(Console.ReadLine());
            int []arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int m = n / 2,Extra,flag=1;
            if (n % 2 == 0)
                Extra = 0;
            else
                Extra = 1;m = m - 1;
            for(int i=0;i<m;i++)
            {
                if (arr[i] == arr[i + 1] && arr[i] == arr[i + n - Extra])
                {
                    Extra = Extra + 2;
                    continue;
                }
                else if (arr[i + 1] - arr[i] == 1 && arr[i] == arr[i + n - Extra])
                {
                    Extra = Extra + 2;
                    continue;
                }
                else
                {
                    flag = 0;Console.WriteLine("here come for loop");
                    break;
                }
            }
            Console.WriteLine("m values is {0}",m);
            if (flag == 1)
            {
                if (n % 2 != 0)
                {
                    if ((arr[m + 1] - arr[m] == 1 && arr[m + 2] - arr[m + 1] == 1) )
                    {
                        if (arr[m] == arr[m + 1] && arr[m + 1] == arr[m + 2])
                            
                            flag = 1;
                    }
                    else
                    {
                        flag = 0; Console.WriteLine("here come if condiation");
                    }
                }
            }
            if(flag==1)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
        Console.ReadKey();
        }
    }
