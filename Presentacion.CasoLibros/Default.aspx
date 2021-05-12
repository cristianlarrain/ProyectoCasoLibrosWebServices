<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.CasoLibros._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .espacio {
            padding: 20px;
        }
        .espacio2 {
            padding: 10px;
        }
    </style>
    <link href="Static/Css/estilos.css" rel="stylesheet" />

    <div class="jumbotron">
        <h1>Libreria Virtual</h1>
        <div class="row">
            <div class="col-sm-12 bob">

                <p class="lead">Buscar Libro por Código</p>
                <asp:TextBox ID="txtCodigoLibro" TextMode="Number" runat="server" Width="223px" Wrap="False" ></asp:TextBox><br />
                <br />
                <asp:Button ID="btn_BuscarLibro" runat="server" Text="Consultar..." Width="227px" OnClick="btn_ConsultarProducto" />
                <br />
                <br />
                <asp:Label ID="lbl_ResultadoBusquedaLibro" disabled="disable" runat="server"></asp:Label>
            </div>
        </div>

        <asp:GridView ID="GrillaListarLibros" runat="server"
            CellSpacing="10"
            GridLines="Vertical"
            BackColor="White"
            BorderColor="#DEDFDE"
            BorderStyle="Solid"
            BorderWidth="10px"
            AutoGenerateColumns="False"
            Width="100%"
            ForeColor="Black">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("IMAGEN_PRODUCTO") %>' Width="120px" />
                    </ItemTemplate>
                    <ItemStyle CssClass="espacio2" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="NOMBRE_PRODUCTO" runat="server" Font-Size="Large" Font-Bold="false" ><%# Eval("NOMBRE_PRODUCTO") %></asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Font-Bold="true">SKU: <%# Eval("CODIGO_PRODUCTO") %></asp:Label>
                        <br />
                        <asp:Label ID="DESCRIPCION" runat="server" Font-Size="Small"><%# Eval("DESCRIPCION") %></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="espacio" />


                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
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
