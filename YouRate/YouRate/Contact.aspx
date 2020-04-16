<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="YouRate.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <address>
        Campus do IPS - Estefanilha,<br />
        2910-761 Setúbal<br />
        <abbr title="Phone">Phone:</abbr>
        265 548 820
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@yourate.com">Support@yourate.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@yourate.com">Marketing@yourate.com</a>
    </address>
</asp:Content>
