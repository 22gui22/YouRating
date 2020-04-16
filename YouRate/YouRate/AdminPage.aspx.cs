using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouRate
{
    public partial class AdminPage : System.Web.UI.Page
    {
        ServiceReference1.Service1Client service1Client;
        List<Users> users;
        List<ServiceReference1.Videos> videos;
        List<ServiceReference1.Comments> comments;
        List<ServiceReference1.Ratings> ratings;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/");

            service1Client = new ServiceReference1.Service1Client();
            FillGrids();
        }

        protected async void FillGrids()
        {
            HttpClient client = CreateRestClient();
            HttpResponseMessage res = await client.GetAsync("api/Users/");
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {
                users = await res.Content.ReadAsAsync<List<Users>>();
                GridViewUsers.DataSource = users;
                GridViewUsers.DataBind();
                GridViewUsers.HeaderRow.Cells[0].Text = "ID";
                GridViewUsers.HeaderRow.Cells[0].Width = 25;
                GridViewUsers.HeaderRow.Cells[1].Text = "First Name";
                GridViewUsers.HeaderRow.Cells[1].Width = 100;
                GridViewUsers.HeaderRow.Cells[2].Text = "Last Name";
                GridViewUsers.HeaderRow.Cells[2].Width = 100;
                GridViewUsers.HeaderRow.Cells[3].Text = "Email";
                GridViewUsers.HeaderRow.Cells[3].Width = 200;
                GridViewUsers.HeaderRow.Cells[4].Text = "Password";
                GridViewUsers.HeaderRow.Cells[4].Width = 100;  
            }

            videos = service1Client.GetVideos().ToList();

            GridViewVideos.DataSource = videos;
            GridViewVideos.DataBind();

            GridViewVideos.HeaderRow.Cells[0].Text = "Date";
            GridViewVideos.HeaderRow.Cells[1].Text = "Description";
            GridViewVideos.HeaderRow.Cells[2].Text = "Video ID";
            GridViewVideos.HeaderRow.Cells[3].Text = "Title";
            GridViewVideos.HeaderRow.Cells[4].Text = "URL";


            comments = service1Client.GetComments().ToList();

            GridViewComments.DataSource = comments;
            GridViewComments.DataBind();

            GridViewComments.HeaderRow.Cells[0].Text = "Comment";
            GridViewComments.HeaderRow.Cells[1].Text = "Date";
            GridViewComments.HeaderRow.Cells[2].Text = "Comment ID";
            GridViewComments.HeaderRow.Cells[3].Text = "Video ID";


            ratings = service1Client.GetRatings().ToList();

            GridViewRatings.DataSource = ratings;
            GridViewRatings.DataBind();

            GridViewRatings.HeaderRow.Cells[0].Text = "Rating ID";
            GridViewRatings.HeaderRow.Cells[1].Text = "Score";
            GridViewRatings.HeaderRow.Cells[2].Text = "Video ID";


            UsersText.InnerText = "Admin Accounts: " + users.Count();
            VideosText.InnerText = "Videos: " + videos.Count();
            CommentsText.InnerText = "Comments: " + comments.Count();
            RatingsText.InnerText = "Ratings: " + ratings.Count();


        }

        private HttpClient CreateRestClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61864/API");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}