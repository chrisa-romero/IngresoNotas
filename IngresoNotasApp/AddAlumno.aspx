<%@ Page Title="Add Alumno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAlumno.aspx.cs" Inherits="IngresoNotasApp.AddAlumno" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div><asp:Label ID="lblCarnet" runat="server">Carnet:</asp:Label></div>
    <div><asp:TextBox ID="txtCarnet" runat="server" Placeholder="Carnet"></asp:TextBox></div>
    <div><asp:Label ID="lblNombres" runat="server">Nombres:</asp:Label></div>
    <div><asp:TextBox ID="txtNombres" runat="server" Placeholder="Nombres"></asp:TextBox></div>
    <div><asp:Label ID="lblApellidos" runat="server">Apellidos:</asp:Label></div>
    <div><asp:TextBox ID="txtApellidos" runat="server" Placeholder="Apellidos"></asp:TextBox></div>
    <div><asp:Label ID="lblFechaIngreso" runat="server">Fecha de Ingreso (MM/dd/yyyy):</asp:Label></div>
    <div><asp:TextBox ID="txtFechaIngreso" runat="server" Placeholder="Fecha Ingreso"></asp:TextBox></div>
    <div><asp:Label ID="lblCarreraID" runat="server">Carrera:</asp:Label></div>
    <div><asp:TextBox ID="txtCarreraId" runat="server" Placeholder="Carrera ID"></asp:TextBox></div>

    <asp:Button ID="btnSubmit" runat="server" Text="Add Alumno" OnClick="btnSubmit_Click" />
</asp:Content>