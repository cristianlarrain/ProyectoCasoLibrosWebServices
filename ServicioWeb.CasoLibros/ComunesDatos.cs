using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Datos.Views
{
    public class ComunesDatos
    {

        public static void EliminarAporte(int aporteId)
        {
            var comando = ConfiguracionDatos.CrearComandoProc("APORTES_DELETEPROCEDURE");
            comando.Parameters.AddWithValue("@APO_ID", aporteId);
            ConfiguracionDatos.EjecutarComando(comando);
        }


        public static void IngresarEntrevista(
            int idFamilia, int tipoEntrevista, DateTime fechaEntrevista, string observaciones, int procesoId, List<ListItem> profesionalesResponsables)
        {
            var comando = ConfiguracionDatos.CrearComandoProc("ENTREVISTA_INSERTPROCEDURE");
            comando.Parameters.AddWithValue("ENT_TIP_ID", tipoEntrevista);
            comando.Parameters.AddWithValue("ENT_FECHA", fechaEntrevista);
            comando.Parameters.AddWithValue("ENT_RESULTADO", observaciones);
            comando.Parameters.AddWithValue("PROCESO_ID", procesoId);
            comando.Parameters.AddWithValue("FAM_ID", idFamilia);
            comando.Parameters.AddWithValue("ENT_ID", SqlDbType.Int).Direction = ParameterDirection.Output;

            ConfiguracionDatos.EjecutarComando(comando);
            var entId = Convert.ToInt32(comando.Parameters["ENT_ID"].Value);



            foreach (ListItem element in profesionalesResponsables)
            {


                var comando2 = ConfiguracionDatos.CrearComandoProc("EVALUADOR_ENTREVISTA_INSERTPROCEDURE");
                comando2.Parameters.AddWithValue("ENT_ID", entId);
                comando2.Parameters.AddWithValue("FNC_ID", element.Value);
                ConfiguracionDatos.EjecutarComando(comando2);

            }




        }

        public static void IngresarPagos(
            int idFamilia, DateTime fechaAporte, string observaciones, int procesoId, int tipoAporte, int formaPago,
            int monto)
        {
            var comando = ConfiguracionDatos.CrearComandoProc("APORTES_INSERTPROCEDURE");
            comando.Parameters.AddWithValue("APO_TIP_ID", tipoAporte);
            comando.Parameters.AddWithValue("FORM_PAG_ID", formaPago);
            comando.Parameters.AddWithValue("FAM_ID", idFamilia);
            comando.Parameters.AddWithValue("APO_FECHA_APORTE", fechaAporte);
            comando.Parameters.AddWithValue("APO_MONTO", monto);
            comando.Parameters.AddWithValue("APO_NOTAS", observaciones);
            comando.Parameters.AddWithValue("PROCESO_ID", procesoId);

            ConfiguracionDatos.EjecutarComando(comando);
        }

        public static DataTable Comunas()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM COMUNA ORDER BY COM_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Comunas(int prvId)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM COMUNA WHERE PRV_ID =" + prvId + "ORDER BY COM_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Provincias()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PROVINCIA ORDER BY PRV_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Provincias(int regId)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PROVINCIA WHERE REG_ID=" + regId + " ORDER BY PRV_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Regiones()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText =
                "SELECT (ROMANO + ' - ' + REG_NOMBRE) AS REG_NOMBRE, REG_ID FROM REGION ORDER BY REG_ID";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Cargos()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM CARGO ORDER BY CRG_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Estados()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM ESTADO ORDER BY EST_VALOR";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable EstadoFamilia()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM ESTADO_POSTULACION ORDER BY EST_VALOR";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable EstadoCivil()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM ESTADO_CIVIL ORDER BY EST_CIVIL_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable FormaPago()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM FORMA_PAGO ORDER BY FORM_PAG_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Genero()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM GENERO ORDER BY GEN_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Profesiones()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM PROFESION ORDER BY PRF_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable TipoEntrevistas()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM ENTREVISTA_TIPO ORDER BY ENT_TIP_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable ProfesionalesResponsables()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText =
                "SELECT (FNC_NOMBRES + ' '+ FNC_APELLIDO_PAT) AS NOMBRE_FUNCIONARIO, * FROM FUNCIONARIO ORDER BY FNC_NOMBRES";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable ProfesionalesEntrevistas(int entrevistaId)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText =
                "SELECT (A.FNC_NOMBRES + ' ' + A.FNC_APELLIDO_PAT) PROFESIONAL FROM FUNCIONARIO A INNER JOIN PROFESIONAL_RESPONSABLE B " +
                " ON A.FNC_ID= B.FNC_ID AND B.ENT_ID= " + entrevistaId + " ORDER BY FNC_NOMBRES";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable ListarEntrevistas(int procesoId)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM VIEW_LISTARENTREVISTAS WHERE PROCESO_ID=" + procesoId;
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable TipoHijos()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM HIJOS_TIPO";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable TiposAporte()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM APORTE_TIPO";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }



        public static DataTable ListarPagosFecha(DateTime fecha1, DateTime fecha2)
        {

            var comando = ConfiguracionDatos.CrearComandoProc("FINANZAS_BUSCAR_FECHA"); ;
            comando.Parameters.AddWithValue("FECHA1", fecha1);
            comando.Parameters.AddWithValue("FECHA2", fecha2);

            return ConfiguracionDatos.EjecutarComandoDt(comando);


            //var comando = ConfiguracionDatos.CrearComando();
            //comando.CommandText = "SELECT * FROM View_ListarPagos  WHERE (FECHA_APORTE BETWEEN '" + fecha1 + "' AND '" + fecha2 + "') order by postulante, fecha_aporte";

            //return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable ListarPagos()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM View_ListarPagos order by postulante, fecha_aporte";

            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }


        public static DataTable ListarPagosPersona(string persona)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM View_ListarPagos  WHERE  (RUT LIKE '%" + persona + "%') " +
                                  " OR  (POSTULANTE LIKE '%" + persona + "%')  order by postulante, fecha_aporte";

            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        //comando.CommandText = "SELECT * FROM View_ListarPagos  WHERE " +
        //              " (RUT LIKE '%" + persona + "%') " +
        //              " OR " +
        //              " (POSTULANTE LIKE '%" + persona + "%')  " +
        //              " OR " +
        //              " (FECHA_APORTE BETWEEN '" + fecha1 + "' AND '" + fecha2 + "') order by postulante, fecha_aporte";

        public static DataTable ListarPagosAporte(int tipoAporte)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM View_ListarPagos  WHERE APO_TIP_ID =  " + tipoAporte + " order by postulante, fecha_aporte";

            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable ListarPagos(int procesoId)
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM View_ListarPagos WHERE PROCESO_ID=" + procesoId;
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable Ocupaciones()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM OCUPACION ORDER BY OCUP_NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable ViaIngreso()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM VIA_INGRESO ORDER BY NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }

        public static DataTable CausalEgreso()
        {
            var comando = ConfiguracionDatos.CrearComando();
            comando.CommandText = "SELECT * FROM CAUSAL_EGRESO ORDER BY NOMBRE";
            return ConfiguracionDatos.EjecutarComandoSelect(comando);
        }
    }
}