<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grilla.aspx.cs" Inherits="Presentacion.CasoLibros.grilla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link type="text/css" href="grid/jquery-ui-1.9.2.custom.css" rel="stylesheet" />
    <link type="text/css" href="grid/ui.jqgrid.css" rel="stylesheet" />

    <script type="text/javascript" src="grid/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="grid/jquery-ui-1.9.2.custom.js"></script>

    <script src="grid/grid.locale-en.js" type="text/javascript"></script>

    <script src="grid/jquery.jqGrid.min.js" type="text/javascript"></script>


    <script type="text/javascript">  

        $(function () {
            $("#dataGrid").jqGrid({
                url: 'grilla.aspx/GetDataFromDB',
                datatype: 'json',
                mtype: 'POST',

                serializeGridData: function (postData) {
                    return JSON.stringify(postData);
                },

                ajaxGridOptions: { contentType: "application/json" },
                loadonce: true,
                colNames: ['SKU', 'CODIGO', 'LIBRO'],
                colModel: [
                    { name: 'ID_PRODUCTO', index: 'ID_PRODUCTO', width: 40 },
                    { name: 'CODIGO_PRODUCTO', index: 'CODIGO_PRODUCTO', width: 80 },
                    { name: 'NOMBRE_PRODUCTO', index: 'NOMBRE_PRODUCTO', width: 360 },
                ],

                pager: '#pagingGrid',
                rowNum: 5,
                rowList: [10, 20, 30],
                viewrecords: true,
                gridview: true,
                jsonReader: {
                    page: function (obj) { return 1; },
                    total: function (obj) { return 1; },
                    records: function (obj) { return obj.d.length; },
                    root: function (obj) { return obj.d; },
                    repeatitems: false,
                    id: "0"
                },
                caption: 'Listado de productos'
            });
        }).pagingGrid("#pager", { edit: true, add: true, del: false });


    </script>
</head>
<body style="font-family: Arial; font-size: 11pt">


                    <table id="dataGrid" style="text-align: center;"></table>
                <div id="pagingGrid"></div>

</body>
</html>
