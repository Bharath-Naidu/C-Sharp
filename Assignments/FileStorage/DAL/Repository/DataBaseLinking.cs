using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DataBaseLinking
    {
        public int UploadRootFolder(RootFolder root)
        {
            
            //return 0;inser into sfgkj(rt.name,rt.path)
            return 0;
        }
        public int UploadSubFolder(SubFolder sub,int RootFolderID)
        {
            //return 0;inser into sfgkj(rt.name,rt.path)
            return 0;
        }
        public void UploadFile(FileInfo file,int FolderID)
        {
            //return 0;inser into sfgkj(rt.name,rt.path)
        }
    }
}
