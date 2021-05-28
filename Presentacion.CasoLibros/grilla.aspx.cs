using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace Presentacion.CasoLibros
{
    public partial class grilla : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Dictionary<string, object>> GetDataFromDB()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=148.72.23.19;Initial Catalog=LibreriaVirtual;User=sauser;Password=Wmx%y765;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ID_PRODUCTO],[CODIGO_PRODUCTO],[NOMBRE_PRODUCTO] FROM PRODUCTOS ", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return rows;
                }
            }
        }
    }
}