<%@ Page Title="Manager - Libros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="Presentacion.CasoLibros.Manager.Libros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Libros
    </h2>
    <table style="width: 100%;">
        <tr>
            <td>Código libro</td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Título del libro</td>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" Width="380px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>URL imagen</td>
            <td>
                <asp:TextBox ID="txtImagen" runat="server" Width="380px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Reseña</td>
            <td>
                <asp:TextBox ID="txtReseña" runat="server" Rows="10" TextMode="MultiLine" Width="377px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btGuardar" runat="server" Text="Guardar" OnClick="btGuardar_Click" />
                <br />
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </td>
        </tr>
    </table>


</asp:Content>
