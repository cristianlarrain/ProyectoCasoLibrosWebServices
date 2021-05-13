using System;
using System.Data;
using System.Web.UI;

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
            wsLibros.UserDetails token  = new wsLibros.UserDetails();

            token.AccessKey = "tokenb42636e9261f";
       
            DataSet ds = servicio.ListarLibros(token);
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




    }
}