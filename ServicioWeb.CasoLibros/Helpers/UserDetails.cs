namespace ServicioWeb.CasoLibros.Helpers
{
    public class UserDetails : System.Web.Services.Protocols.SoapHeader
    {

        public string AccessKey { get; set; }

        public bool IsValid()
        {
            string token = System.Configuration.ConfigurationManager.AppSettings["token"];

            return AccessKey == token;
        }

    }
}