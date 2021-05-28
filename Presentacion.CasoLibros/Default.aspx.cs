using System;
using System.Data;
using System.Web.UI;
using Transbank.Webpay;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus;

namespace Presentacion.CasoLibros
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }
        private void ListarProductos()
        {
            wsLibros.WsLibrosSoapClient servicio = new wsLibros.WsLibrosSoapClient();
            ///wsLibros.UserDetails token = new wsLibros.UserDetails();

            //token.AccessKey = "tokenb42636e9261f";

            DataSet ds = servicio.ListarLibros();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btn_BuscarLibro_Click(object sender, EventArgs e)
        {
            try
            {

                lbl_Resultado.Text = string.Empty;

                var codigoLibro = int.Parse(txt_IdCodigo.Text);

                using (wsLibros.WsLibrosSoapClient cliente = new wsLibros.WsLibrosSoapClient())
                {

                    DataSet ds = cliente.ConsultarLibro(codigoLibro);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                lbl_Resultado.Text = ex.ToString();
            }

        }

        protected void btCarro_Click(object sender, EventArgs e)
        {
            var transaction = new Webpay(Configuration.ForTestingWebpayPlusNormal()).NormalTransaction;

            var random = new Random();

            string buyOrder = random.Next(999999999).ToString();
            var sessionId = random.Next(999999999).ToString();
            var amount = 35900; ///Las sumas de productos del carro de compras

            var returnUrl = "https://localhost:44326/Return";
            var finalUrl = "https://localhost:44326/Final";

            var initResult = transaction.initTransaction(amount, buyOrder, sessionId, returnUrl, finalUrl);

            var tokenWs = initResult.token;
            var formAction = initResult.url;


        }
    }
}