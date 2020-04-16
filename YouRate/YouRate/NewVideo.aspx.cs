using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouRate
{
    public partial class NewVideo : System.Web.UI.Page
    {
        ServiceReference1.Service1Client service1Client;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/");

            service1Client = new ServiceReference1.Service1Client();
        }

        protected void SaveVideo(object sender, EventArgs e)
        {
            string titulo = Titulo.Text;
            string url = Url.Text;
            string descricao = Description.Text;
            service1Client.NewVideo(titulo,url,descricao);
            Titulo.Text = Url.Text = Description.Text = "";
        }
    }
}