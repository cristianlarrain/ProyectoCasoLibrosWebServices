using System;

namespace Presentacion.CasoLibros.Manager
{
    public partial class Libros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                lblResultado.Text = string.Empty;

                int codigoProducto = int.Parse(txtCodigo.Text);
                string nombreProducto = txtTitulo.Text;
                string imagenProducto = txtImagen.Text;
                string descripcion = txtReseña.Text;

                using (wsLibros.WsLibrosSoapClient cliente = new wsLibros.WsLibrosSoapClient())
                {
                    cliente.InsertarLibro(codigoProducto, nombreProducto, imagenProducto, descripcion);
                    lblResultado.Text = "Libro ingresado correctamente";
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.ToString();
            }


        }
    }
}