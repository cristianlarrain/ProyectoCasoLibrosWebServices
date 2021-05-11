
namespace Datos
{
    public class ConexionDatos
    {
       private const string cadenaConexion = @"Data Source=DESKTOP-M1PKGM9;Initial Catalog=LibreriaVirtual;Integrated Security=True";
      
        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }
    }
}
