using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ErrrorLog
    {
        public static void ErrorlogWrite(Exception ex)

        {

            string DoubleSpace = "\n\n";

            string error = ex.StackTrace;

            string filepath = @"D:\windowsform\WindowsFormsApp1\WindowsFormsApp1\ExceptionDetailsFile.txt"; //Text File Path

            
            //filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name

            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");

                sw.WriteLine("-------------------------------------------------------------------------------------");

                sw.WriteLine(ex.Message);

                sw.WriteLine(DoubleSpace);

                sw.WriteLine(error);

                sw.WriteLine("--------------------------------*End*------------------------------------------");

                sw.WriteLine(DoubleSpace);

                sw.Flush();

                sw.Close();

            }

        }
    }
}
