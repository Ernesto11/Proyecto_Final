using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace Proyecto_Final
{
    public partial class ModuloAdministrativo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        public void mensajeError(String error)
        {
            string script = @"<script type='text/javascript'>alert('" + error + "');</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


        }
        //----------Boton que muestra el calendario---------------\\
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            //----se hacen visibles los atributos-----------\\
            Año.Visible = true;
            Mes.Visible = true;
            añoSelect.Visible = true;
            mesSelector.Visible = true;
            Calendar.Visible = true;

        }

        //---------------------Acción del boton para insertar un cliente en la base de datos-------------------------------------\\
        protected void Button4_Click(object sender, EventArgs e)
        {
            //----------------------Verificar campos vacios antes e insertar------------------------\\
            if (nombre.Text == "")
            {
                mensajeError("Debe ingresar un nombre");
                return;
            }
            if (apellido.Text == "")
            {
                mensajeError("Debe ingresar un apellido");
                return;
            }
            if (fecha.Text == "")
            {
                mensajeError("Por favor, seleccione una fecha de nacimiento");
                return;
            }
            if (direccion.Text == "")
            {
                mensajeError("Debe ingresar una dirección");
                return;
            }
            try
            {
                //---------------Conexion con la base de datos------------------\\
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
                //---------------habre la conexion------------------------------\\
                conexion.Open();
                //---------------se ingresa el string de la consulta sql--------\\
                //--------------Crea el comando de sql que se ejecutara---------\\
                SqlCommand command = new SqlCommand("CASO2.SP_INSERTAR_CLIENTE", conexion);
                command.CommandType = CommandType.StoredProcedure;
                //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\
                command.Parameters.AddWithValue("@NOMBRE", nombre.Text);
                command.Parameters.AddWithValue("@APELLIDO", apellido.Text);
                command.Parameters.AddWithValue("@CEDULA", (cedula.Text));
                command.Parameters.AddWithValue("@GENERO", genero.SelectedValue);
                command.Parameters.AddWithValue("@FECHA_NAC", Convert.ToDateTime(fecha.Text));
                command.Parameters.AddWithValue("@DIRECCION", direccion.Text);
                command.Parameters.AddWithValue("@NOMB_USER", n_usuario.Text);
                command.Parameters.AddWithValue("@TELEFONO", telefono.Text);
                //---------------ejecuta la consulta-------------------------------------\\
                int res = command.ExecuteNonQuery();
                //------------------Mensaje de exito de consulta------------------\\
                if (res == -1)
                {
                    //---------------Restablecer los campos de texto--------------------\\
                    nombre.Text = "";
                    apellido.Text = "";
                    cedula.Text = "";
                    fecha.Text = "";
                    direccion.Text= "";
                    n_usuario.Text = "";
                    telefono.Text = "";
                    mensajeError("Cliente Ingresada Correctamente");
                }
                conexion.Close();
            }
            //------------------------Captura de errores----------------------\\
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 8114)
                {
                    mensajeError("La cédula ingresada o el número de teléfono no cumplen con el formato requerido");
                }

                if (sqlex.Number == 50000)
                {
                    int largo = sqlex.Message.Length;
                    string mensaje = sqlex.Message;
                    mensajeError(mensaje);
                }


            }


            //--------------cierra la conección---------------\\

        }

        //-----------------------Metodo que selecciona la fecha del calendario y lo agrega al campo de texto-------------------\\
        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            //-------selecciona la fecha del calendario y oculta los atributos-------------------\\
            fecha.Text = Calendar.SelectedDate.ToString("dd -MM -yyyy");
            Calendar.Visible = false;
            Año.Visible = false;
            Mes.Visible = false;
            añoSelect.Visible = false;
            mesSelector.Visible = false;
        }

        protected void añoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int año = Convert.ToInt16(añoSelect.SelectedValue);
            int mes = Convert.ToInt16(mesSelector.SelectedValue);
            Calendar.VisibleDate = new DateTime(año, mes, 1);
        }

        protected void mesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int año = Convert.ToInt16(añoSelect.SelectedValue);
            int mes = Convert.ToInt16(mesSelector.SelectedValue);
            Calendar.VisibleDate = new DateTime(año, mes, 1);
        }



    }

}




