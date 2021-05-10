using System;
using System.Data;
using System.Web.Services;
using Datos;

namespace ServicioWeb.CasoLibros
{
    /// <summary>
    /// Descripción breve de ConsutaLibros
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsutaLibros : WebService
    {


        [WebMethod]
        public string ConsultarLibro(int Codigo_Libro)
        {
            /* conexión a base de datos */

            if (Codigo_Libro == 1001)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }


        [WebMethod]
        public string ConsultarStock(int Codigo_Libro)
        {
            if (Codigo_Libro == 1001)
            {
                return "1";
            }
            else

                return "0";
        }


        [WebMethod]
        public DataSet ListarProductos()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PRODUCTOS";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;
        }


        [WebMethod]
        public DataSet ConsultarLibroDB(int Codigo_Libro)
        {

            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PRODUCTOS WHERE CODIGO_PRODUCTO = '" + Codigo_Libro + "'";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;

        }

    }
}

