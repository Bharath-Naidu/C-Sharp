using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class FileInfo
    {
        int Id { get; set; }
        int SubFolderId { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        string Type { get; set; }
        long Size { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime FileAccessed { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
        bool IsFilePathOK { get; set; }
        bool IsFileUnsupported { get; set; }
        string Permission { get; set; }
    }
}
