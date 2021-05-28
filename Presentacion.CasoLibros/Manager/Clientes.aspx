<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Presentacion.CasoLibros.Manager.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            AGREGAR NUEVO CLIENTE<br />
            <br />
            <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtRutCliente" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDVCliente" runat="server" Width="40px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
        </div>
        <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
