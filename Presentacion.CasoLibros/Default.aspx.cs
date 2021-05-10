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
            ServiceWeb_CasoLibros.ConsutaLibrosSoapClient servicio = new ServiceWeb_CasoLibros.ConsutaLibrosSoapClient(); 
                
            DataSet DS = servicio.ListarProductos();
            GridView1.DataSource = DS;
            GridView1.DataBind();
        }

        protected void btn_BuscarLibro_Click(object sender, EventArgs e)
        {
            try
            {

                lbl_Resultado.Text = string.Empty;
                var id_libro = int.Parse(txt_IdCodigo.Text);

                using (ServiceWeb_CasoLibros.ConsutaLibrosSoapClient cliente = new ServiceWeb_CasoLibros.ConsutaLibrosSoapClient())
                {

                   var Resultado_ConsultaLibro = cliente.ConsultarLibro(id_libro);

                    if (Resultado_ConsultaLibro == "1")
                    {
                        lbl_Resultado.Text = "Stock Disponible";
                        lbl_Resultado.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                    {
                        lbl_Resultado.Text = "Sin Stock Disponible";
                        lbl_Resultado.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {

                lbl_Resultado.Text = ex.ToString();
            }


        }

        protected void btn_ConsultarStock(object sender, EventArgs e)
        {
            try
            {

                lbl_resultado2.Text = string.Empty;

                var id_libro = int.Parse(txtCodigoLibro.Text);

                using (ServiceWeb_CasoLibros.ConsutaLibrosSoapClient cliente = new ServiceWeb_CasoLibros.ConsutaLibrosSoapClient())
                {
     
                    DataSet DS = cliente.ConsultarLibroDB(id_libro);
                    GridView1.DataSource = DS;
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {

                lbl_resultado2.Text = ex.ToString();
            }

        }




    }
}