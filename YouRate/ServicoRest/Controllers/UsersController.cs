using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace ServicoRest.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public HttpResponseMessage Get()
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Users";
            SqlCommand command = new SqlCommand(query, connection);
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
            List<Users> user = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                user.Add(new Users()
                {

                    Users_Id = Convert.ToInt32(dr["Users_Id"].ToString()),
                    Users_FirstName = dr["Users_FirstName"].ToString(),
                    Users_LastName = dr["Users_LastName"].ToString(),
                    Users_Email = dr["Users_Email"].ToString(),
                    Users_Password = dr["Users_Password"].ToString()
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // POST: api/Users
        public HttpResponseMessage Post([FromBody]Users users)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Users where Users_Email = @email AND Users_Password = @password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", users.Users_Email);
            command.Parameters.AddWithValue("@password", users.Users_Password);
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
            Users user = new Users();
            foreach (DataRow dr in dt.Rows)
            {
                user = new Users()
                {

                    Users_Id = Convert.ToInt32(dr["Users_Id"].ToString()),
                    Users_FirstName = dr["Users_FirstName"].ToString(),
                    Users_LastName = dr["Users_LastName"].ToString(),
                    Users_Email = dr["Users_Email"].ToString(),
                };
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

    }
}
