using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    class RootFolder
    {
        int  Id { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
