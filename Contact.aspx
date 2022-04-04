<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Laboratorio8WebD.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Datos<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        d<asp:Button ID="ButtonCargar" runat="server" OnClick="ButtonCargar_Click" Text="Cargar" />
    </h2>
    <h2>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h2>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
