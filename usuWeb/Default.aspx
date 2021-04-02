<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="usuWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Página de usuarios</h1>
        <div>
            <div>
                <asp:Label ID = "mostrarMensaje" runat ="server"></asp:Label>
            </div>

            <p>
                NIF: <asp:TextBox ID="NIFTextBox" TextMode="SingleLine" 
                    Columns="9" runat="server"  /> 
            </p>
            <p>
                Nombre: <asp:TextBox ID="NombreTextBox" TextMode="SingleLine" 
                    Columns="30" runat="server"  /> 
            </p>
            <p>
                Edad: <asp:TextBox ID="EdadTextBox" TextMode="SingleLine" 
                    Columns="3" runat="server"/> 
            </p>

            <asp:Button ID="BotonLeerUsuario" Text="Leer" runat="server" OnClick="LeerUsuario" />
            <asp:Button ID="BotonLeerPrimerUsuario" Text="Leer Primero" runat="server" OnClick="LeerPrimerUsuario" />
            <asp:Button ID="BotonLeerAnteriorUsuario" Text="Leer Anterior" runat="server" OnClick="LeerAnteriorUsuario" />
            <asp:Button ID="BotonLeerSiguienteUsuario" Text="Leer Siguiente" runat="server" OnClick="LeerSiguienteUsuario" />
            <asp:Button ID="BotonCrearUsuario" Text="Crear" runat="server" OnClick="CrearUsuario" />
            <asp:Button ID="BotonActualizar" Text="Actualizar" runat="server" OnClick="Actualizar" />
            <asp:Button ID="BotonBorrarUsuario" Text="Borrar" runat="server" OnClick="BorrarUsuario" />

        </div>

</asp:Content>
