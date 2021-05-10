<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.CasoLibros._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Static/Css/estilos.css" rel="stylesheet" />

    <div class="jumbotron">
        <h1>Libreria Virtual</h1>
        <div class="row">
            <div class="col-sm-6 bob">

                <p class="lead">Buscar Libros Por un Codigo</p>
                <br />
                <asp:TextBox ID="txt_IdCodigo" TextMode="Number" runat="server" Width="223px"></asp:TextBox><br />
                <br />
                <asp:Button ID="btn_BuscarLibro" runat="server" Text="Buscar..." Width="227px" OnClick="btn_BuscarLibro_Click" />
                <br />
                <br />
                <asp:Label ID="lbl_Resultado" disabled="disable" runat="server"></asp:Label>
                <br />
                <br />
            </div>
            <div class="col-sm-6 bob">

                <p class="lead">Consultar Stock Libro</p>
                <br />
                <asp:TextBox ID="txtCodigoLibro" TextMode="Number" runat="server" Width="223px"></asp:TextBox><br />
                <br />
                <asp:Button ID="btn_Consultar_stock" runat="server" Text="Consultar..." Width="227px" OnClick="btn_ConsultarStock" />
                <br />
                <br />
                <asp:Label ID="lbl_resultado2" disabled="disable" runat="server"></asp:Label>
                <br />
                <br />
            </div>
        </div>

        <asp:GridView ID="GridView1" runat="server" CellPadding="3" GridLines="None"
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="10" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Imagen">

                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("IMAGEN_PRODUCTO") %>' Width="120px" />
                        <asp:Label ID="codigo_PRODUCTO" runat="server" Text='<%# Eval("codigo_PRODUCTO") %>'></asp:Label>
                        <asp:Label ID="nombre_PRODUCTO" runat="server" Text='<%# Eval("nombre_PRODUCTO") %>'></asp:Label>
                        <br />
                        <asp:Label ID="descripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                    </ItemTemplate>


                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>

    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Productos destacados</h2>
            <p>
                <img alt="portada El Universo en tu Mano" src="https://images.cdn1.buscalibre.com/fit-in/360x360/4d/49/4d49ad4d36afe0237735c76b22ad7c45.jpg" />
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Leer más &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Novedades</h2>
            <p>
                <img alt="portada La Razon de Estar Contigo" src="https://images.cdn2.buscalibre.com/fit-in/360x360/ac/16/ac16eb9900af78f514b8b160131a226a.jpg" />
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Leer más &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Exito de ventas</h2>
            <p>
                <img alt="portada Alimenta tu Cerebro" src="https://images.cdn3.buscalibre.com/fit-in/360x360/f9/af/f9afd152c649ce5162b692fbd63ed287.jpg" />
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Leer más &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
