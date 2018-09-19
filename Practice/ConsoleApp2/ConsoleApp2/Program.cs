using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public int Count_adj(int[,] arr,int ii,int jj,int nn1,int nn2)
    {
        int count = 0;
        if (jj - 1 >= 0 && arr[(ii), (jj - 1)] == 1)count++;
        if (jj + 1 < nn2 && arr[(ii), (jj + 1)] == 1)count++;
        if (ii + 1  < nn1 && arr[(ii + 1), (jj)] == 1)count++;
        if (ii - 1 >= 0 && arr[(ii - 1), (jj)] == 1)count++;
        if ((ii - 1 >= 0 && jj - 1 >= 0) && arr[(ii - 1), (jj - 1)] == 1)count++;
        if ((ii - 1 >= 0 && jj + 1 >= 0) && ( jj + 1 < nn2)  && arr[(ii - 1), (jj + 1)] == 1)count++;
        if ((ii + 1 < nn1 && jj - 1 >= 0) && arr[(ii + 1), (jj - 1)] == 1)count++;
        if ((jj + 1 < nn2 && ii + 1 < nn1)&&(arr[(ii + 1), (jj + 1)] == 1))count++; 
        return count;
    }
    static void Main(string[] args)
    {
        int n1 = Convert.ToInt32(Console.ReadLine()),n2 = Convert.ToInt32(Console.ReadLine());
        int[,] arr = new int[n1, n2];
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
             
                arr[i, j] = Convert.ToInt32(Console.ReadLine());

        }
        int num = 0, max = 0, X = 0, Y = 0 ;
        int flag = 1;
        Program obj = new Program();
        for(int i=0;i<n1; i++)
        {
            for(int j=1;j<n2;j++)
            {
                if (arr[i, j] == 1)
                {
                    num = obj.Count_adj(arr, i, j, n1, n2);
                    if (num > max)
                    {
                        max = num;
                        X = i;
                        Y = j;
                    }
                    
                }
            }
        }
        //if (flag == 1)
            Console.WriteLine("{0}:{1}:{2}", X + 1, Y + 1, max);
        /*else if (flag == 0)
            Console.WriteLine("Polygamy not allowed");
        else if(flag==2)
            Console.WriteLine("No suitable girl found");*/
        Console.ReadKey();
        }
    }