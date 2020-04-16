<%@ Page Title="Video" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="YouRate.Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript" src="../Scripts/Gui.js" async defer></script>
    
    
    <center>
        <div class="col-md-1"> </div>
        <div class="col-md-10">
            <h2 id="txtTitulo" runat="server"></h2>
        </div>
        <div class="col-md-1">
            <asp:Button ID="DeleteVideo" runat="server" class='input-group-addon btn btn-primary' Text="Delete Video" Height="37px" OnClick="Delete_Video" Width="135px" Visible="False" ></asp:Button>
        </div>
        <iframe id="iFrame" runat="server" width='560' height='315' src='' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>
        <div runat="server" style='font-size: 25px;'>
            <a id='a1' style="text-decoration:none;color: grey;" runat="server" OnServerClick="SaveRating" class='fa fa-star'></a>
            <a id='a2' style="text-decoration:none;color: grey;" runat="server" OnServerClick="SaveRating" class='fa fa-star'></a>
            <a id='a3' style="text-decoration:none;color: grey;" runat="server" OnServerClick="SaveRating" class='fa fa-star'></a>
            <a id='a4' style="text-decoration:none;color: grey;" runat="server" OnServerClick="SaveRating" class='fa fa-star'></a>
            <a id='a5' style="text-decoration:none;color: grey;" runat="server" OnServerClick="SaveRating" class='fa fa-star'></a>
        </div>
        <p id="descricao" runat="server"></p>
        <h3>Comments</h3>
    </center>

    <asp:Panel ID="PanelVideo" runat="server">
        </asp:Panel>

    <center>
    <div class='input-group' style='width: 1170px;'>
        <asp:TextBox ID="TextBoxComment" runat="server" MaxLength="300" TextMode="MultiLine" class='form-control' Rows="5"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" class='input-group-addon btn btn-primary' Text="Post Comment" Height="37px" OnClick="Button1_Click" Width="135px" ></asp:Button>
    </div>
    </center>

    
</asp:Content>
