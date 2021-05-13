using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConfiguracionDatos
    {
        public static SqlCommand CrearComando()
        {
            string cadenaConexion = ConexionDatos.CadenaConexion;
            SqlConnection conexion = new SqlConnection { ConnectionString = cadenaConexion };
            var comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            return comando;
        }

        public static SqlCommand CrearComandoProc(string proc)
        {
            string cadenaConexion = ConexionDatos.CadenaConexion;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(proc, conexion) { CommandType = CommandType.StoredProcedure };
            return comando;
        }

        public static int EjecutarComando(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }

        public static DataTable EjecutarComandoSelect(SqlCommand comando)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter { SelectCommand = comando };
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { comando.Connection.Close(); }
            return tabla;
        }


        public static DataSet CrearDataSet(SqlCommand comando)
        {
            DataSet tabla = new DataSet();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter { SelectCommand = comando };
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { comando.Connection.Close(); }
            return tabla;
        }



        public static DataTable EjecutarComandoDt(SqlCommand comando)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter { SelectCommand = comando };
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Close();
            }
            return tabla;
        }
    }
}

