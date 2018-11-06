using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;

namespace UploadFolder
{
    public class PermissionRepository
    {
        public void InsertInto(string DatabaseTableName, string SqlQuery)

        {
            SqlConnection Connection = new SqlConnection(ConnectionString.Constr);
            SqlCommand Command = new SqlCommand(SqlQuery, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public DataTable GetMappingRole(string MappedRole)
        {
           
            SqlDataAdapter Adapter;
            using (SqlConnection connection = new SqlConnection())
            {
                DataTable RolesInfoTable = new DataTable();
                connection.ConnectionString = ConnectionString.Constr;
                connection.Open();
                string SqlQuery = "select RoleType from RoleTypes  where Id in (select RoleTypesId from FolderToSPPermissions where FolderPermissionsId = (select Id from FolderPermissions where PermissionLevel = '"+MappedRole+"')); ";  
                Adapter = new SqlDataAdapter(SqlQuery, connection);
                Adapter.Fill(RolesInfoTable);             
                connection.Close();
                return RolesInfoTable;
            }
        }
        public void InsertFilePermissions(int FileId, string Username, string FilePermission)//copy
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.;Initial Catalog=FolderUpload;Integrated Security=True";
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("Proc_InsertFilePermissions", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@pFileID", SqlDbType.Int).Value = FileId;
                sqlCommand.Parameters.Add("@pUserName", SqlDbType.NVarChar).Value = Username;
                sqlCommand.Parameters.Add("@pFilePermission", SqlDbType.NVarChar).Value = FilePermission;

                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void InsertFolderPermissions(int FolderId, string Username, string FolderPermission)//copy
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.;Initial Catalog=FolderUpload;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_InsertFolderPermissions", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@pFolderID", SqlDbType.Int).Value = FolderId;
                sqlCommand.Parameters.Add("@pUserName", SqlDbType.NVarChar).Value = Username;
                sqlCommand.Parameters.Add("@pFolderPermission", SqlDbType.NVarChar).Value = FolderPermission;

                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
