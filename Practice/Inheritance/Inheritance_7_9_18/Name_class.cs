using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_7_9_18
{
    class PersonalDetails
    {
        public String Name;
        private int age;
        public String Address;
        public int DOB
        {
            get { return age; }
            set { age = value; }
        }
        public PersonalDetails()
        {

        }

        public PersonalDetails(String name,String add)
        {
            this.Name = name;
            this.Address = add;
        }
        public virtual void Hello()
        {
            Console.WriteLine("This is base class");
        }
       public int convertToAge(DateTime dt)
        {
            return DateTime.Today.Year - dt.Year; 
        }

    }
}
