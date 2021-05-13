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

    public class WsLibros : WebService
    {
        public new UserDetails User;

       
        [WebMethod]
        [SoapHeader("User")]

        /* listar productos conectados a una base de datos sql server */
        public DataSet ListarLibros()
        {      
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PRODUCTOS";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;
        }


        [WebMethod]
        /* consultar producto por codigo, conectados a una base de datos sql server */
        public DataSet ConsultarLibro(int codigoLibro)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PRODUCTOS WHERE CODIGO_PRODUCTO = '" + codigoLibro + "'";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;
        }

        [WebMethod]
        public void EliminarLibro(int codigoProducto)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "DELETE FROM PRODUCTOS WHERE CODIGO_PRODUCTO = " + codigoProducto + " ";
            ConfiguracionDatos.EjecutarComando(comando);
        }

        [WebMethod]
        public void InsertarLibro(int codigoProducto, string nombreProducto, string imagenProducto, string descripcion)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "INSERT INTO PRODUCTOS ( CODIGO_PRODUCTO , NOMBRE_PRODUCTO , IMAGEN_PRODUCTO , DESCRIPCION) VALUES ( '" + codigoProducto + "', '" + nombreProducto + "' , '" + imagenProducto + "', '" + descripcion + "')";

            ConfiguracionDatos.EjecutarComando(comando);
        }

        [WebMethod]
        public void ActualizarLibro(int codigoProducto, string nombreProducto, string imagenProducto, string descripcion)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "UPDATE PRODUCTOS SET NOMBRE_PRODUCTO = '" + nombreProducto + "' , IMAGEN_PRODUCTO = '" + imagenProducto + "' , DESCRIPCION = '" + descripcion + "' WHERE  CODIGO_PRODUCTO = '" + codigoProducto + "'";
            ConfiguracionDatos.EjecutarComando(comando);
        }



        //public DataSet ListarLibros()
        //{
        //    try
        //    {
        //        if (User != null)
        //        {
        //            if (User.IsValid())
        //            {
        //                var comando = ConfiguracionDatos.CrearComando();
        //                comando.CommandText = "SELECT * FROM PRODUCTOS";
        //                DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
        //                return dt;
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }

    }
}

