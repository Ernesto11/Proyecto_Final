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

namespace Proyecto_Final
{
    public partial class RealizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            insertarCuenta.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            insertarCuenta.Visible = false;
        }

        protected void nombreUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
           source.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            string nomUsuario = Convert.ToString(nombreUsuario.SelectedValue);
            source.SelectCommand = "SELECT id_cuenta from caso2.cuenta where nombreusuario = '" +nomUsuario + "'";

            cuenta.Items.Clear();
            cuenta.DataBind();
            cuenta.DataSourceID = "source";
            cuenta.Items.Insert(0, "----Seleccione una cuenta----");
            cuenta.DataTextField = "id_cuenta";
            cuenta.DataValueField = "id_cuenta";
        }

        protected void cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void mensajeError(String error)
        {
            string script = @"<script type='text/javascript'>alert('" + error + "');</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextCantidad.Text == "")
            {
                mensajeError("Ingrese la cantidad de unidades del producto que desea comprar");
                return;
            }
            try
            {
                int can = Int32.Parse(TextCantidad.Text);
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
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
            //---------------habre la conexion------------------------------\\
            conexion.Open();
            //---------------se ingresa el string de la consulta sql--------\\
            string consulta_precio = "select precio_unitario from caso2.producto where nombre = '" + drowProducto.SelectedValue + "'";
            string id_producto = "select id_producto from caso2.producto where nombre = '" + drowProducto.SelectedValue + "'";
            string funcionVerificaInventario = "SELECT  CASO2.VERIFICAR_COMPRA_INVENTARIO(" + TextCantidad.Text + ",'"  + drowProducto.SelectedValue + "')";

            var cn_Precio = new SqlCommand(consulta_precio, conexion);
            var cn_IDProducto = new SqlCommand(id_producto, conexion);
            var cn_verificaInventario = new SqlCommand(funcionVerificaInventario, conexion);
            SqlCommand command = new SqlCommand("CASO2.SP_UPDATE_INVENTARIO", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\

            
            var precio = cn_Precio.ExecuteScalar();
            cn_verificaInventario.ExecuteScalar();
            var res = cn_verificaInventario.ExecuteScalar();
            var idProducto = cn_IDProducto.ExecuteScalar();

            int resCantidadInventario = Int32.Parse(res.ToString());
            if (resCantidadInventario == 0)
            {
                mensajeError("Disculpe, la cantidad del producto que desea comprar no se encuentra en el inventario");
                conexion.Close();
                return;
            }
            string cn_cantidad = "select cantidad from caso2.inventario where id_producto = '" +idProducto+ "'";
            SqlCommand cmmCantidad = new SqlCommand(cn_cantidad,conexion);
            var cantidad = cmmCantidad.ExecuteScalar();
            int cantidadNueva = Int32.Parse(cantidad.ToString())-Int32.Parse(TextCantidad.Text);
            command.Parameters.AddWithValue("@ID_Producto", idProducto);
            command.Parameters.AddWithValue("@CANTIDAD", cantidadNueva);
            command.ExecuteNonQuery();
            conexion.Close();
            ListBox1.Items.Add(drowProducto.SelectedValue);
            ListBox2.Items.Add("₡ " + precio.ToString());
            ListBox3.Items.Add(TextCantidad.Text);
            int subTotal = Int32.Parse(TextCantidad.Text) * Int32.Parse(precio.ToString());
            ListBox4.Items.Add("₡ "+subTotal);
            total.Text = (Int32.Parse(total.Text.ToString())+subTotal).ToString();
            TextCantidad.Text = "";


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
         //   try
         //   {
                if (ListBox1.SelectedIndex == 0)
                {
                    mensajeError("Elemento invalido");
                    return;
                }

                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
                conexion.Open();
                string id_producto = "select id_producto from caso2.producto where nombre = '" + ListBox1.Items[ListBox1.SelectedIndex].ToString()+"'";
                var cn_IDProducto = new SqlCommand(id_producto, conexion);
                var idProducto = cn_IDProducto.ExecuteScalar();

                string cn_cantidad = "select cantidad from caso2.inventario where id_producto = '" +idProducto+ "'";
                var cmm_cantidad = new SqlCommand(cn_cantidad, conexion);
                var cantidadInventario = cmm_cantidad.ExecuteScalar();
                string cantidad = ListBox3.Items[ListBox1.SelectedIndex].ToString();
                int cantidadNueva = Int32.Parse(cantidadInventario.ToString())+Int32.Parse(cantidad);
                //---------------se ingresa el string de la consulta sql--------\\
                //--------------Crea el comando de sql que se ejecutara---------\\
                SqlCommand command = new SqlCommand("CASO2.SP_UPDATE_INVENTARIO", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID_Producto", Int32.Parse(idProducto.ToString()));
                command.Parameters.AddWithValue("@CANTIDAD", cantidadNueva);
                command.ExecuteNonQuery();
                conexion.Close();
                string precioConSimbolo = ListBox4.Items[ListBox1.SelectedIndex].ToString();
                string precio = precioConSimbolo.Substring(2, (precioConSimbolo.Length - 2));
                total.Text = (Int32.Parse(total.Text) - Int32.Parse(precio)).ToString();
                ListBox2.Items.RemoveAt(ListBox1.SelectedIndex);
                ListBox3.Items.RemoveAt(ListBox1.SelectedIndex);
                ListBox4.Items.RemoveAt(ListBox1.SelectedIndex);
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex);

//            }
 //           catch {
  //              mensajeError("Seleccione el producto que desea eliminar de la lista");
   //         }
            
        }
    }
}