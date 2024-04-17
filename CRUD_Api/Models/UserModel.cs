using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CRUD_Api.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }

        static string connectionString = @"ADD_YOUR_CONNECTION_STRING_HERE";

        static SqlConnection connection = new SqlConnection(connectionString);

        public static DataTable getAllRecords()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                SqlDataAdapter da = new SqlDataAdapter("select * from tbl_userdeatils", connection);

                da.Fill(dt);
            }
            catch (Exception x)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int InsertRecord(string name, string email)
        {
            int res = 0;

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insert into tbl_userdeatils(name, email) values(@name,@email)", connection);

                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@email", email);

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return res;
        }

        public static int UpdateRecord(string name, string email, int id)
        {
            int res = 0;

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("update tbl_userdeatils set name = @name, email=@email where id = @id", connection);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return res;
        }

        public static int DeleteRecord(int id)
        {
            int res = 0;

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("delete from tbl_userdeatils where id = @id", connection);

                cmd.Parameters.AddWithValue("@id", id);

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return res;
        }
    }
}
