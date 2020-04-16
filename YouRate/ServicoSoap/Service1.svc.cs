using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicoSoap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /// <summary>
        /// Returns all the comments
        /// </summary>
        public List<Comments> GetComments()
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Comments";
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
            List<Comments> comments = new List<Comments>();
            foreach (DataRow dr in dt.Rows)
            {
                comments.Add(new Comments()
                {
                    Comments_Id = Convert.ToInt32(dr["Comments_Id"].ToString()),
                    Comments_Date = Convert.ToDateTime(dr["Comments_Date"].ToString()),
                    Comments_Comments = dr["Comments_Comments"].ToString(),
                    Comments__Video_Id = Convert.ToInt32(dr["Comments__Video_Id"].ToString())
                });
            }
            return comments;
        }

        /// <summary>
        /// Receives a video id
        /// and returns all the comments from that video
        /// </summary>
        public List<Comments> GetVideoComments(int videoId)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Comments where Comments__Video_Id = @videoId order by Comments_Id desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@videoId", videoId);
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
            List<Comments> comments = new List<Comments>();
            foreach (DataRow dr in dt.Rows)
            {
                comments.Add(new Comments()
                {
                    Comments_Id = Convert.ToInt32(dr["Comments_Id"].ToString()),
                    Comments_Date = Convert.ToDateTime(dr["Comments_Date"].ToString()),
                    Comments_Comments = dr["Comments_Comments"].ToString(),
                    Comments__Video_Id = Convert.ToInt32(dr["Comments__Video_Id"].ToString())
                });
            }
            return comments;
        }

        /// <summary>
        /// Returns all the ratings
        /// </summary>
        public List<Ratings> GetRatings()
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Ratings";
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
            List<Ratings> ratings = new List<Ratings>();
            foreach (DataRow dr in dt.Rows)
            {
                ratings.Add(new Ratings()
                {
                    Ratings_Id = Convert.ToInt32(dr["Ratings_Id"].ToString()),
                    Ratings_Score = Convert.ToInt32(dr["Ratings_Score"].ToString()),
                    Ratings_Video_Id = Convert.ToInt32(dr["Ratings_Video_Id"].ToString())
                });
            }
            return ratings;
        }

        /// <summary>
        /// Receives a video id
        /// and returns all the ratings from that video
        /// </summary>
        public double GetVideoRatings(int videoId)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "Select AVG(Cast(Ratings_Score as float)) from Ratings where Ratings_Video_Id = @videoId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@videoId", videoId);
            connection.Open();
            double rating = 0.0;
            Object teste = command.ExecuteScalar();
            if (teste != null)
                rating = double.Parse(string.Concat("0",teste.ToString()));
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

            return rating;
        }

        /// <summary>
        /// Returns all the videos by order
        /// </summary>
        public List<Videos> GetVideos()
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Videos order by Videos_Id desc";
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
            List<Videos> videos = new List<Videos>();
            foreach (DataRow dr in dt.Rows)
            {
                videos.Add(new Videos()
                {
                    Videos_Id = Convert.ToInt32(dr["Videos_Id"].ToString()),
                    Videos_Name = dr["Videos_Name"].ToString(),
                    Videos_URL = dr["Videos_URL"].ToString(),
                    Videos_Description = dr["Videos_Description"].ToString(),
                    Videos_Date = Convert.ToDateTime(dr["Videos_Date"].ToString())
                });
            }
            return videos;
        }

        /// <summary>
        /// Receives a video url
        /// and returns all the information about the video
        /// </summary>
        public Videos GetSingleVideo(string videoURL)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "select * from Videos where Videos_URL = @URL";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@URL", videoURL);
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
            Videos videos = new Videos();
            foreach (DataRow dr in dt.Rows)
            {
                videos = new Videos()
                {
                    Videos_Id = Convert.ToInt32(dr["Videos_Id"].ToString()),
                    Videos_Name = dr["Videos_Name"].ToString(),
                    Videos_URL = dr["Videos_URL"].ToString(),
                    Videos_Description = dr["Videos_Description"].ToString(),
                    Videos_Date = Convert.ToDateTime(dr["Videos_Date"].ToString())
                };
            }
            return videos;

        }

        /// <summary>
        /// Receives a video id and a comment
        /// and inserts them in the database
        /// </summary>
        public void NewComment(string comment,int videoID)
        {
            
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "INSERT INTO [Comments] ([Comments_Date], [Comments_Comments], [Comments__Video_Id]) values(GETDATE(),@comment,@videoID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@comment", comment);
            command.Parameters.AddWithValue("@videoID", videoID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
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
        }

        /// <summary>
        /// Receives a video id and a rating
        /// and inserts them in the database
        /// </summary>
        public void NewRating(int score, int videoID)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "INSERT INTO [Ratings] ([Ratings_Score], [Ratings_Video_Id]) VALUES (@score,@videoID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@score", score);
            command.Parameters.AddWithValue("@videoID", videoID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
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
        }

        /// <summary>
        /// Receives a comment id
        /// and removes it from the database
        /// </summary>
        public void DeleteComment(int id)
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "DELETE from [Comments] where Comments_Id = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", id);            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Receives a Name, URL and a Description
        /// and inserts them in the database
        /// </summary>
        public void NewVideo(string name, string url, string description)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "INSERT INTO [Videos] ([Videos_Name], [Videos_URL], [Videos_Description], [Videos_Date]) values(@name,@url,@description,GETDATE())";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@url", url);
            command.Parameters.AddWithValue("@description", description);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
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
        }

        /// <summary>
        /// Receives a video id
        /// and removes it from the database
        /// </summary>
        public void DeleteVideo(int id)
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Videos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "DELETE from [Videos] where Videos_Id = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", id);            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }



    }


}
