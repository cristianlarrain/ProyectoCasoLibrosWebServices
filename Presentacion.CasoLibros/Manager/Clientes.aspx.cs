using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.CasoLibros.Manager
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {


                string nombreCliente = txtNombreCliente.Text;
                string rutCliente = txtRutCliente.Text;
                string dvCliente = txtDVCliente.Text;

                using (wsClientes.wsClientesSoapClient cliente = new wsClientes.wsClientesSoapClient())
                {
                    cliente.InsertarCliente(nombreCliente, rutCliente, dvCliente);
                    lblResultado.Text = "Cliente ingresado correctamente";
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.ToString();
            }



        }
    }
}