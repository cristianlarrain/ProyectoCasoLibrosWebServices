using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                int CODIGO_PRODUCTO = int.Parse(txtCodigo.Text);
                string NOMBRE_PRODUCTO = txtTitulo.Text;
                string IMAGEN_PRODUCTO = txtImagen.Text;
                string DESCRIPCION = txtReseña.Text;

                using (wsLibros.wsLibrosSoapClient cliente = new wsLibros.wsLibrosSoapClient())
                {
                    cliente.InsertarLibro(CODIGO_PRODUCTO, NOMBRE_PRODUCTO, IMAGEN_PRODUCTO, DESCRIPCION);
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