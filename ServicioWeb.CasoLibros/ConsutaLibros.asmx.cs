using System;
using System.Data;
using System.Web.Services;
using System.Web.Services.Protocols;
using Datos;
using ServicioWeb.CasoLibros.Helpers;

namespace ServicioWeb.CasoLibros
{
    /// <summary>
    /// Descripción breve de ConsutaLibros
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class ConsutaLibros : WebService
    {
        public new UserDetails User;


        [WebMethod]
        [SoapHeader("User")]

        /* listar productos conectados a una base de datos sql server */

        public DataSet ListarProductos()
        {
            try
            {
                if (User != null)
                {
                    if (User.IsValid())
                    {
                        var comando = ConfiguracionDatos.CrearComando();
                        comando.CommandText = "SELECT * FROM PRODUCTOS";
                        DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
                        return dt;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }

        }


        [WebMethod]
        /* consultar producto por codigo, conectados a una base de datos sql server */
        public DataSet ConsultarLibroDB(int Codigo_Libro)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PRODUCTOS WHERE CODIGO_PRODUCTO = '" + Codigo_Libro + "'";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;
        }


        //[WebMethod]
        //public string ConsultarLibro(int Codigo_Libro)
        //{
        //    /* conexión a base de datos */

        //    if (Codigo_Libro == 1001)
        //    {
        //        return "1";
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}

        //[WebMethod]
        //public string ConsultarStock(int Codigo_Libro)
        //{
        //    if (Codigo_Libro == 1001)
        //    {
        //        return "1";
        //    }
        //    else

        //        return "0";
        //}



    }
}

