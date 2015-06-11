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
using System.Globalization;


namespace Proyecto_Final
{
    public partial class Registro_Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listaPaises.DataSource = GetCountryInfo();
            listaPaises.DataBind();
        }

        public void mensajeError(String error)
        {
            string script = @"<script type='text/javascript'>alert('" + error + "');</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        public List<string> GetCountryInfo()
        {
            List<string> list = new List<string>();
            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo inforeg = new RegionInfo(info.LCID);
                if (!list.Contains(inforeg.EnglishName))
                {
                    list.Add(inforeg.EnglishName);
                    list.Sort();
                }
            }
            return list;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //-------------------------Verifica que los campos de texto no esten vacio---------\\
            try
            {
                int can = Int32.Parse(cantidad.Text);
                if (can <= 0)
                {
                    mensajeError("Cantidad de producto invlida");
                    return;
                }
            }
            catch
            {
                mensajeError("Cantidad de producto invlida");
            }

            if (nombre.Text == "")
            {
                mensajeError("Debe ingresar el nombre de producto");
                return;
            }
            if (codigo.Text == "")
            {
                mensajeError("Debe ingresar el código del producto");
                return;
            }
            if (costo.Text == "")
            {
                mensajeError("Debe ingresar el costo unitario del producto");
                return;
            }
            if (precio.Text == "")
            {
                mensajeError("Debe ingresar el precio del producto");
                return;
            }
            if (Descripcion.Text == "")
            {
                mensajeError("Debe ingresar la descripción del producto");
                return;
            }
            if (envio.Text == "")
            {
                mensajeError("Debe ingresar el código de envio del producto");
                return;
            }
            if (cantidad.Text == "")
            {
                mensajeError("Debe ingresar la cantidad del producto");
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
                SqlCommand command = new SqlCommand("CC.SP_INSERTAR_PRODUCTO", conexion);
                command.CommandType = CommandType.StoredProcedure;
                //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\
                command.Parameters.AddWithValue("@NOMBRE", nombre.Text);
                command.Parameters.AddWithValue("@CODIGO", codigo.Text);
                command.Parameters.AddWithValue("@COSTO", costo.Text);
                command.Parameters.AddWithValue("@PRECIO", precio.Text);
                command.Parameters.AddWithValue("@DESCRIPCION", Descripcion.Text);
                command.Parameters.AddWithValue("@ENVIO", envio.Text);
                //---------------ejecuta la consulta-------------------------------------\\
                int res = command.ExecuteNonQuery();
                conexion.Close();
                if (res == -1)
                {
                    SqlConnection conexion2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
                    //---------------habre la conexion------------------------------\\
                    conexion2.Open();
                    //---------------se ingresa el string de la consulta sql--------\\
                    //--------------Crea el comando de sql que se ejecutara---------\\
                    string consulta_IDProducto = "select ID_Producto from CC.producto where nombre = '"+nombre.Text+"' and codigo_producto = '"+codigo.Text+"' and  costo_unitario = '"+costo.Text+"'";
                    string consulta_IDPlanta = "select id_planta from CC.planta where nombre = '"+DropDownList2.SelectedValue+"'";
                    SqlCommand command1 = new SqlCommand("CC.SP_INSERTAR_INVENTARIO", conexion2);
                    command1.CommandType = CommandType.StoredProcedure;

                    var cn_IDProducto = new SqlCommand(consulta_IDProducto, conexion2);
                    var cn_IDPlanta = new SqlCommand(consulta_IDPlanta, conexion2);
                    var id_producto = cn_IDProducto.ExecuteScalar();
                    var id_planta = cn_IDPlanta.ExecuteScalar();

                    command1.Parameters.AddWithValue("@ID_Producto",id_producto);
                    command1.Parameters.AddWithValue("@ID_Planta", id_producto);
                    command1.Parameters.AddWithValue("@CANTIDAD", cantidad.Text);
                    int res1 = command1.ExecuteNonQuery();
                    conexion2.Close();
                    if (res1 == -1)
                    {
                        nombre.Text = "";
                        codigo.Text = "";
                        costo.Text = "";
                        precio.Text = "";
                        Descripcion.Text = "";
                        envio.Text = "";
                        cantidad.Text = "";

                        mensajeError("El producto se ingreso correctamenta");
                    }
                }
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 8114)
                {
                    mensajeError("El precio del producto, el costo del producto o el código de envio son incorrectos");
                }

                if (sqlex.Number == 50000)
                {
                    int largo = sqlex.Message.Length;
                    string mensaje = sqlex.Message;
                    mensajeError(mensaje);
                }

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            registrarPlanta.Visible = true;
            Button1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //-------------------------Verifica que los campos de texto no esten vacio---------\\
            if (nombrePlanta.Text == "")
            {

                mensajeError("Debe ingresar el nombre de la planta");
                return;


            }
            if (codigoPlanta.Text == "")
            {
                mensajeError("Debe ingresar el código de la planta");
                return;
            }
            if (codigoZIP.Text == "")
            {
                mensajeError("Debe ingresar el código ZIP planta");
                return;
            }
            try
            {
                SqlConnection conexion1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
                //---------------habre la conexion------------------------------\\
                conexion1.Open();
                //---------------se ingresa el string de la consulta sql--------\\
                //--------------Crea el comando de sql que se ejecutara---------\\
                SqlCommand command = new SqlCommand("CC.SP_INSERTAR_PLANTA", conexion1);
                command.CommandType = CommandType.StoredProcedure;
                //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\
                command.Parameters.AddWithValue("@NOMBRE", nombrePlanta.Text);
                command.Parameters.AddWithValue("@CODIGO", codigoPlanta.Text);
                command.Parameters.AddWithValue("@REGION", region.Text);
                command.Parameters.AddWithValue("@ZIP", codigoZIP.Text);
                command.Parameters.AddWithValue("@PAIS", listaPaises.SelectedValue);
                //---------------ejecuta la consulta-------------------------------------\\
                int res = command.ExecuteNonQuery();
                conexion1.Close();
                if (res == -1)
                {

                    DropDownList2.Items.Clear();
                    DropDownList2.DataBind();
                    DropDownList2.DataSourceID = "SqlDataSource1";
                    DropDownList2.DataTextField = "NOMBRE";
                    DropDownList2.DataValueField = "NOMBRE";
                    DropDownList2.SelectedValue = nombrePlanta.Text;
                    DropDownList2.Text = nombrePlanta.Text;

                    DropDownList2.DataBind();
                    Button1.Visible = true;
                    registrarPlanta.Visible = false;
                    Button1.Visible = true;
                    mensajeError("La planta se ingreso correctamente");
                    DropDownList2.SelectedValue = nombrePlanta.Text;
                    nombrePlanta.Text = "";
                    codigoPlanta.Text = "";
                    codigoZIP.Text = "";
                    region.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:Forzar();", true);

                }
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 8114)
                {
                    mensajeError("El Código de la planta o el Código ZIP son incorrectos");
                }

                if (sqlex.Number == 50000)
                {
                    int largo = sqlex.Message.Length;
                    string mensaje = sqlex.Message;
                    mensajeError(mensaje);
                }

                ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarTablaPlanta()", true);

            }



        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            registrarPlanta.Visible = false;
            Button1.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:Forzar();", true);

        }


    }



}