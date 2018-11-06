using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DAL.Model;

namespace DAL
{
    public class GetRootFolderRepository
    {
        
        public string ConString= ConnectionString.Constr;
        public DataTable BindingFolders()
        {
            SqlConnection Connection = new SqlConnection(ConString);

            Connection.Open();
            string Command = "select Id,Path,Name from RootFolder";
            SqlDataAdapter Adapter = new SqlDataAdapter(Command, Connection);
            DataTable Datatable = new DataTable();
            Adapter.Fill(Datatable);
            Connection.Close();
            return Datatable;
        }
    }
}
