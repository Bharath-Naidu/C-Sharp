using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISchool
    {
        void NoOfstudents();
        void whichClassClass();
        //int Rollnumber { get; set; }
        //int NoOfStudentsInSchool { get; set; }
    }

    public interface IStudent : ISchool
    {
        void Name();
        //String NameOfStudent { get; set; }
        void Rollno();
    }
}
