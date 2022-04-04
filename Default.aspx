<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio8WebD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        
        Jugador<br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Fecha de Juego<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        Equipo<br />
        <asp:TextBox ID="TextBoxEquipo" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEquipo" runat="server" ControlToValidate="TextBoxEquipo" ErrorMessage="Agrege el nombre del equipo no sea imbecil" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        Goles<br />
        <asp:TextBox ID="TextBoxGoles" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGoles" runat="server" ControlToValidate="TextBoxGoles" ErrorMessage="Debe Ingresar algun dato" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator ID="RangeValidatorGoles" runat="server" ControlToValidate="TextBoxGoles" ErrorMessage="Debe ingresar un numero entre 1 y 10" MaximumValue="10" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        
    </div>

</asp:Content>
