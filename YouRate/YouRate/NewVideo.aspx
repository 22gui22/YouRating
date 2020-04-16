<%@ Page Title="New Video" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewVideo.aspx.cs" Inherits="YouRate.NewVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br><br>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Titulo" CssClass="col-md-2 control-label" Style="text-align: right;">Titulo:</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Titulo" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Titulo" CssClass="text-danger" ErrorMessage="The Title field is required." />
        </div>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Url" CssClass="col-md-2 control-label" Style="text-align: right;">Url:</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Url" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Url" CssClass="text-danger" ErrorMessage="The Url field is required." />
        </div>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label" Style="text-align: right;">Description:</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Description" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Description" CssClass="text-danger" ErrorMessage="The Description field is required." />
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" OnClick="SaveVideo" Text="Save Video" CssClass="btn btn-default" />
        </div>
    </div>



</asp:Content>
