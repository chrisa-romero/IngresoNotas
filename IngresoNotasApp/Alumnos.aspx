<%@ Page Title="Alumnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="IngresoNotasApp.Alumnos" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <asp:GridView ID="GridViewAlumnos" runat="server" AutoGenerateColumns="false" DataKeyNames="Carnet"
        OnRowEditing="GridViewAlumnos_RowEditing"
        OnRowUpdating="GridViewAlumnos_RowUpdating"
        OnRowDeleting="GridViewAlumnos_RowDeleting"
        OnRowCancelingEdit="GridViewAlumnos_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="Carnet" HeaderText="Carnet" ReadOnly="true" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha Ingreso" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="CarreraId" HeaderText="Carrera ID" />

            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAdd" runat="server" Text="Add New Alumno" OnClick="btnAdd_Click" />

</asp:Content>