using System;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using YouRate.Models;

namespace YouRate.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/");
        }

        protected async void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {

                HttpClient client = CreateRestClient();
                Users user = new Users() { Users_Email = Email.Text, Users_Password = Password.Text };
                HttpResponseMessage res = await client.PostAsJsonAsync("api/Users/",user);
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    user = await res.Content.ReadAsAsync<Users>();
                    FormsAuthentication.RedirectFromLoginPage(user.Users_FirstName + " " + user.Users_LastName,true);
                }

            }
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