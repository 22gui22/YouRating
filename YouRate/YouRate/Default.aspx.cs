using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouRate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();
            List<ServiceReference1.Videos> listaVideos= service1Client.GetVideos().ToList();
            string HTMLstring = "";
            foreach (ServiceReference1.Videos v in listaVideos)
            {   
                HTMLstring += "<div class='col-md-3' style='margin: 0px 0px 10px 0px;'>";
                HTMLstring += "<a href = 'Video.aspx?id="+ v.Videos_URL + "' target = '_blank'>";
                HTMLstring += "<div style='background-image: url(https://img.youtube.com/vi/" + v.Videos_URL + "/hqdefault.jpg); background-size: cover; background-repeat: no-repeat; background-position: center; height:118px;width:210px;)'></div></a>";
                HTMLstring += "<h5 style='height: 50px;width: 210px;margin-top: 0px;margin-bottom: 0px;overflow: hidden;text-overflow: ellipsis;'><b>" + v.Videos_Name+ "</b></h5>";
                HTMLstring += "<div class='row' style='width: 210px;float: left;'><div class='col-md-8'>";
                double rate = service1Client.GetVideoRatings(v.Videos_Id);
                for (double i=0.5;i <= 5;i++)
                {
                    if (i <= rate)
                        HTMLstring += "<span class='fa fa-star checked'></span>";
                    else
                        HTMLstring += "<span class='fa fa-star'></span>";
                }
                HTMLstring += "<p style='display: inline-block'>" + Math.Round(rate, 1) + "/5" + "</p>";
                HTMLstring += "</div>";
                HTMLstring += "<div class='col-md-4'>";
                HTMLstring += "<p align='left' style='width: 105px'>" + (v.Videos_Date.Date).ToString("d") + "</p>";
                HTMLstring += "</div>";
                HTMLstring += "</div>";
                HTMLstring += "</div>";
            }

            HTMLstring += "</div>";
            PanelVideos.Controls.Add(new LiteralControl(HTMLstring));
        }

    }
}