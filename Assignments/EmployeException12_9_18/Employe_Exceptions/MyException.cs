using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeException12_9_18.Employe_Exceptions
{
    class MyException:Exception
    {
        public override String Message => base.Message;
        public MyException(String message) :base(message)
        {
        //    this.message = message;
        }
    }
}
