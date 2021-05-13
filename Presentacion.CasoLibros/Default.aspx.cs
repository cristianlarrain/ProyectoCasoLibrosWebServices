using System;
using System.Data;
using System.Web.UI;

namespace Presentacion.CasoLibros
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }
        private void ListarProductos()
        {
            wsLibros.wsLibrosSoapClient servicio = new wsLibros.wsLibrosSoapClient();
            wsLibros.UserDetails token  = new wsLibros.UserDetails();

            token.AccessKey = "tokenb42636e9261f";
       
            DataSet DS = servicio.ListarLibros(token);
            GridView1.DataSource = DS;
            GridView1.DataBind();
        }

        protected void btn_BuscarLibro_Click(object sender, EventArgs e)
        {
            try
            {

                lbl_Resultado.Text = string.Empty;

                var CodigoLibro = int.Parse(txt_IdCodigo.Text);

                using (wsLibros.wsLibrosSoapClient cliente = new wsLibros.wsLibrosSoapClient())
                {
     
                    DataSet DS = cliente.ConsultarLibro(CodigoLibro);
                    GridView1.DataSource = DS;
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