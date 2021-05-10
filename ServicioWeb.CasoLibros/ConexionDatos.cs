
namespace Datos
{
    public class ConexionDatos
    {
       ///private const string cadenaConexion = @"Data Source=DESKTOP-M1PKGM9;Initial Catalog=LibreriaVirtual;Integrated Security=True";
       private const string cadenaConexion = @"Data Source=148.72.23.19;Initial Catalog=LibreriaVirtual;User=sauser;Password=Wmx%y765;";
        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }
    }
}
