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

    public class wsLibros : WebService
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
        public DataSet ConsultarLibro(int Codigo_Libro)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PRODUCTOS WHERE CODIGO_PRODUCTO = '" + Codigo_Libro + "'";
            DataSet dt = ConfiguracionDatos.CrearDataSet(comando);
            return dt;
        }

        [WebMethod]
        public void EliminarLibro(int CODIGO_PRODUCTO)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "DELETE FROM PRODUCTOS WHERE CODIGO_PRODUCTO = " + CODIGO_PRODUCTO + " ";
            ConfiguracionDatos.EjecutarComando(comando);
        }

        [WebMethod]
        public void InsertarLibro(int CODIGO_PRODUCTO, string NOMBRE_PRODUCTO, string IMAGEN_PRODUCTO, string DESCRIPCION)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "INSERT INTO PRODUCTOS ( CODIGO_PRODUCTO , NOMBRE_PRODUCTO , IMAGEN_PRODUCTO , DESCRIPCION) VALUES ( '" + CODIGO_PRODUCTO + "', '" + NOMBRE_PRODUCTO + "' , '" + IMAGEN_PRODUCTO + "', '" + DESCRIPCION + "')";

            ConfiguracionDatos.EjecutarComando(comando);
        }

        [WebMethod]
        public void ActualizarLibro(int CODIGO_PRODUCTO, string NOMBRE_PRODUCTO, string IMAGEN_PRODUCTO, string DESCRIPCION)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "UPDATE PRODUCTOS SET NOMBRE_PRODUCTO = '" + NOMBRE_PRODUCTO + "' , IMAGEN_PRODUCTO = '" + IMAGEN_PRODUCTO + "' , DESCRIPCION = '" + DESCRIPCION + "' WHERE  CODIGO_PRODUCTO = '" + CODIGO_PRODUCTO + "'";
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

