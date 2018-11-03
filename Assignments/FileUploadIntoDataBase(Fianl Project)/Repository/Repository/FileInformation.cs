using System;
using DAL.Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class FileInformation
    {
        string DatabaseConnectionString = "Data Source=ACUPC-121;Initial Catalog=FolderUpload;Integrated Security=True";
        public int UploadRootFolder(RootFolder root)
        {
            int LastModifiredid;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DatabaseConnectionString;
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_UploadRootFolder", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value =root.Name;
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 1000).Value = root.Path;
                sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 1000).Value = root.CreatedBy;
                sqlCommand.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 1000).Value = root.ModifiedBy;
                sqlCommand.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value =root.CreatedOn;
                sqlCommand.Parameters.Add("@ModifiedOn", SqlDbType.DateTime).Value =root.ModifiedOn;
                sqlCommand.Parameters.Add("@returnid", SqlDbType.Int, 1000);
                sqlCommand.Parameters["@returnid"].Direction = ParameterDirection.Output;
                sqlCommand.ExecuteNonQuery();
                LastModifiredid = Convert.ToInt32(sqlCommand.Parameters["@returnid"].Value);
                //int id = Convert.ToInt32(returnvalue);
            }
            return LastModifiredid;
        }
        public int UploadSubFolder(SubFolder sub,int Rootid)
        {
            int LastModifiredid;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DatabaseConnectionString;
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_UploadSubFolder", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@RootFolderId", SqlDbType.Int).Value = Rootid;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value =sub.Name;
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 1000).Value = sub.Path;
                sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 1000).Value = sub.CreatedBy;
                sqlCommand.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 1000).Value =sub.ModifiedBy;
                sqlCommand.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value =sub.CreatedOn;
                sqlCommand.Parameters.Add("@ModifiedOn", SqlDbType.DateTime).Value =sub.ModifiedOn;
                sqlCommand.Parameters.Add("@returnid", SqlDbType.Int, 1000);
                sqlCommand.Parameters["@returnid"].Direction = ParameterDirection.Output;
                sqlCommand.ExecuteNonQuery();
                LastModifiredid = Convert.ToInt32(sqlCommand.Parameters["@returnid"].Value);
            }
            return LastModifiredid;
        }

        public void UploadFile(FileInfo file,int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DatabaseConnectionString;
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_UploadFile", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@SubFolderId", SqlDbType.Int).Value =id;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value =file.Name;
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 1000).Value = file.Path;
                sqlCommand.Parameters.Add("@Size", SqlDbType.NVarChar, 1000).Value = file.Size;
                sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar, 100).Value = file.Type;
                sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 1000).Value = file.CreatedBy;
                sqlCommand.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 1000).Value = file.ModifiedBy;
                sqlCommand.Parameters.Add("@FileAccessed", SqlDbType.DateTime).Value = file.FileAccessed;
                sqlCommand.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = file.CreatedOn;
                sqlCommand.Parameters.Add("@ModifiedOn", SqlDbType.DateTime).Value = file.ModifiedOn;
                sqlCommand.Parameters.Add("@IsFilePathOK", SqlDbType.Bit).Value = file.IsFilePathOK;
                sqlCommand.Parameters.Add("@IsFilesupported", SqlDbType.Bit).Value = file.IsFilesupported;
                sqlCommand.ExecuteNonQuery();
            }
        }  
    }     
}
