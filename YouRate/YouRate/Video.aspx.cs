using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouRate
{
    public partial class Video : System.Web.UI.Page
    {
        ServiceReference1.Service1Client service1Client;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.ToString().Length <= 0)
                Response.Redirect("~/");

            if (Context.User.Identity.IsAuthenticated)
                DeleteVideo.Visible = true;

            service1Client = new ServiceReference1.Service1Client();
            LoadPannel();
        }

        /// <summary>
        /// Sends a Comment to the Soap Service so that it can be added to the database.
        /// And clears the TextBox
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBoxComment.Text.Length > 0) {
                service1Client.NewComment(TextBoxComment.Text, id);
                TextBoxComment.Text = string.Empty;
                LoadPannel();
            }
            
        }

        /// <summary>
        /// Loads the panel that contains the Comments.
        /// </summary>
        protected void LoadPannel()
        {
            PanelVideo.Controls.Clear();

            string video;
            string HTMLstring = "";

            using (WebClient client = new WebClient())
            {
                video = Request.QueryString[0];
            }

            ServiceReference1.Videos videoinfo = service1Client.GetSingleVideo(video);

            id = videoinfo.Videos_Id;
            string title = videoinfo.Videos_Name;
            DateTime date = videoinfo.Videos_Date;
            string description = videoinfo.Videos_Description;

            List<ServiceReference1.Comments> listaComments = service1Client.GetVideoComments(id).ToList();
            double rating = service1Client.GetVideoRatings(id);

            Random rnd = new Random();

            txtTitulo.InnerText = title;
            iFrame.Src = "https://www.youtube.com/embed/" + video;
            descricao.InnerText = description;

            HTMLstring += "<center>";
            HTMLstring += "<div style='width: 560px;'>";
            HTMLstring += "</center>";
            foreach (ServiceReference1.Comments c in listaComments)
            {
                HTMLstring += "<div class='row' style='background-color: #f1f1f1; margin: 0px 0px 10px 0px;border-radius: 25px;'>";

                HTMLstring += "<div class='col-md-1'>";
                HTMLstring += "<img src='https://api.adorable.io/avatars/80/" + rnd.Next(1000) + "' style='width: 80px; height: 80px;margin: 20px 0px 20px 0px;' >";
                HTMLstring += "</div>";

                HTMLstring += "<div class='col-md-10'>";
                HTMLstring += "<p style='margin: 20px;'><b>" + c.Comments_Comments + "</b></p>";
                HTMLstring += "</div>";

                if (Context.User.Identity.IsAuthenticated) {

                    var ButtonChange = new Button();
                    ButtonChange.Text = "Delete";
                    ButtonChange.ID = "btnNew_" + c.Comments_Id.ToString();
                    ButtonChange.CommandArgument = c.Comments_Id.ToString();
                    ButtonChange.CssClass = "input-group-addon btn btn-primary";
                    ButtonChange.Height = 25;
                    ButtonChange.Width = 60;
                    ButtonChange.Style.Add("Margin", "10px");
                    ButtonChange.Style.Add("float", "left");
                    ButtonChange.Command += Delete_Comments;

                    HTMLstring += "<div class='col-md-1'>";

                    PanelVideo.Controls.Add(new LiteralControl(HTMLstring));
                    HTMLstring = "";

                    PanelVideo.Controls.Add(ButtonChange);

                    HTMLstring += "<p style='line-height: 60px;'>" + (c.Comments_Date.Date).ToString("d") + "</p>";
                    HTMLstring += "</div>";
                }
                else {
                    HTMLstring += "<div class='col-md-1'>";
                    HTMLstring += "<p style='line-height: 60px;'>" + (c.Comments_Date.Date).ToString("d") + "</p>";
                    HTMLstring += "</div>";
                }

                HTMLstring += "</div>";
            }
            HTMLstring += "</div>";

            PanelVideo.Controls.Add(new LiteralControl(HTMLstring));
        }

        /// <summary>
        /// Sends rating to Soap Service so that it can be added to the database.
        /// </summary>
        public void SaveRating(object sender, EventArgs e)
        {
            int rating = 0;
            System.Web.UI.HtmlControls.HtmlAnchor button = (System.Web.UI.HtmlControls.HtmlAnchor)sender;
            if (button.ID == "a5")
            {
                rating = 5;
            }
            else if (button.ID == "a4")
            {
                rating = 4;
            }
            else if (button.ID == "a3")
            {
                rating = 3;
            }
            else if (button.ID == "a2")
            {
                rating = 2;
            }
            else if (button.ID == "a1")
            {
                rating = 1;
            }

            service1Client.NewRating(rating, this.id);
        }

        /// <summary>
        /// Sends a Comment ID to Soap Service so that it can be removed from the database.
        /// </summary>
        private void Delete_Comments(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            service1Client.DeleteComment(id);
            LoadPannel();
        }

        /// <summary>
        /// Sends a Video ID to Soap Service so that it can be removed from the database.
        /// </summary>
        protected void Delete_Video(object sender, EventArgs e)
        {
            service1Client.DeleteVideo(id);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}