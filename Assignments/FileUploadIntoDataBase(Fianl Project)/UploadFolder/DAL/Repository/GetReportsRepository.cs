using System;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;
using DAL.Repository;

namespace DAL
{
    public class GetReportsRepository
    {
        string DataBaseLink = ConnectionString.Constr;
        string value;
       // public int monthvalue;
        public string Getdata(string Typeofinfo,string Monthvalue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = (DataBaseLink);
                    connection.Open();
                    string query = "(select count(" + Typeofinfo + ") from FileInfo f where DATEDIFF(month,f." + Typeofinfo + ",GETDATE())<" + Monthvalue + ")";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        value = dataReader[0].ToString();
                    }
                    connection.Close();
                    return value;
                }
            }
            catch(Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
                throw;
            }
        }
        public DataSet DataGrid(string TypeOfInfo, string DisplayMonths)
        {           
            DataSet dataset;
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = (DataBaseLink);
                    connection.Open();
                    string query = "(select * from FileInfo f where DATEDIFF(month," + TypeOfInfo + ",GETDATE())<" + DisplayMonths + ")";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        using (dataset = new DataSet())
                        {
                            dataAdapter.Fill(dataset, "FileInfo");
                        }
                    }

                }
                return dataset;
            }
            catch(Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
                throw;
            }
        }
       
    }
}

