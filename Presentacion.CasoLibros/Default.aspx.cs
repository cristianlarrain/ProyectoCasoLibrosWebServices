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

        public string clave = "tokenb42636e9261f";

        private void ListarProductos()
        {
            ServiceWeb_CasoLibros.ConsutaLibrosSoapClient servicio = new ServiceWeb_CasoLibros.ConsutaLibrosSoapClient();
            ServiceWeb_CasoLibros.UserDetails token = new ServiceWeb_CasoLibros.UserDetails
            {
                AccessKey = clave
            };

            DataSet DS = servicio.ListarProductos(token);
            GrillaListarLibros.DataSource = DS;
            GrillaListarLibros.DataBind();
        }


        protected void btn_ConsultarProducto(object sender, EventArgs e)
        {
            try
            {

                lbl_ResultadoBusquedaLibro.Text = string.Empty;

                var id_libro = int.Parse(txtCodigoLibro.Text);

                using (ServiceWeb_CasoLibros.ConsutaLibrosSoapClient servicio = new ServiceWeb_CasoLibros.ConsutaLibrosSoapClient())
                {

                    DataSet DS = servicio.ConsultarLibroDB(id_libro);
                    GrillaListarLibros.DataSource = DS;
                    GrillaListarLibros.DataBind();

                }
            }
            catch (Exception ex)
            {

                lbl_ResultadoBusquedaLibro.Text = ex.ToString();
            }

        }


        protected void btn_BuscarLibro_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    lbl_Resultado.Text = string.Empty;
            //    var id_libro = int.Parse(txt_IdCodigo.Text);

            //    using (ServiceWeb_CasoLibros.ConsutaLibrosSoapClient cliente = new ServiceWeb_CasoLibros.ConsutaLibrosSoapClient())
            //    {

            //       var Resultado_ConsultaLibro = cliente.ConsultarLibro(id_libro);

            //        if (Resultado_ConsultaLibro == "1")
            //        {
            //            lbl_Resultado.Text = "Stock Disponible";
            //            lbl_Resultado.ForeColor = System.Drawing.Color.DarkGreen;
            //        }
            //        else
            //        {
            //            lbl_Resultado.Text = "Sin Stock Disponible";
            //            lbl_Resultado.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    lbl_Resultado.Text = ex.ToString();
            //}


        }


    }
}