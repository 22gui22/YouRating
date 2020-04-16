using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ServicoRest.Models.Users;

namespace ServicoRest
{
    public class UserPersistance
    {

        public void addUser()
        {

        }

        public void RemoveUser()
        {

        }

        public void getUser(int userid)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Users where Users_Id = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", userid);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            //User videos;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    videos = new Videos()
            //    {
            //        Videos_Id = Convert.ToInt32(dr["Videos_Id"].ToString()),
            //        Videos_Name = dr["Videos_Name"].ToString(),
            //        Videos_URL = dr["Videos_URL"].ToString(),
            //        Videos_Description = dr["Videos_Description"].ToString(),
            //        Videos_Date = Convert.ToDateTime(dr["Videos_Date"].ToString())
            //    };
            //}
            return videos;
        }

        public Boolean tryLogin()
        {
            return true;
        }


    }
}