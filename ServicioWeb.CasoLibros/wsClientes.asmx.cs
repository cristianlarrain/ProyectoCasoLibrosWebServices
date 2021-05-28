using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioWeb.CasoLibros
{
    /// <summary>
    /// Descripción breve de wsClientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsClientes : System.Web.Services.WebService
    {

        [WebMethod]

        public void InsertarCliente(string nombreCliente, string rutCliente, string dvCliente)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "INSERT INTO CLIENTES ( [NOMBRE_CLIENTE] ,[RUT_CLIENTE] , [DV_CLIENTE]) VALUES ( '" + nombreCliente + "', '" + rutCliente + "' , '" + dvCliente + "')";

            ConfiguracionDatos.EjecutarComando(comando);
        }


        [WebMethod]

        /* listar productos conectados a una base de datos sql server */
        public DataSet ListarClientes()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM CLIENTES";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;
        }
    }
}
