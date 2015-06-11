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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;




namespace Proyecto_Final
{
    public partial class RealizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void EnviarCorreo(string correo, string mensaje)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correo);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Tienda ACME: Detalles de la compra realizada";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            // mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = mensaje;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("acmetiendabd@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("acmetiendabd@gmail.com", "pepe1196");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

            cliente.Port = 587;
            cliente.EnableSsl = true;


            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                mensajeError("mensaje no enviado");
            }
        }

        public static bool ComprobarFormatoEmail(string eMail)
        {
            return Regex.IsMatch(eMail, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (nombreUsuario.SelectedValue == "(----Seleccione un nombre de usuario----)")
            {
                mensajeError("seleccione un nombre de usuario para poder ingresar una cuenta");
                return;
            }
            if (DropDownList2.SelectedValue == "------Seleccione un tipo de cuenta--------")
            {
                mensajeError("Seleccione un tipo de cuenta");
                return;
            }
            if (DropDownList1.SelectedValue == "------Seleccione un método de pago------")
            {
                mensajeError("Seleccione un método de pago");
                return;
            }
            if (direccionC.Text == "")
            {
                mensajeError("Ingrese una dirección");
            }
            //---------------Conexion con la base de datos------------------\\
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
            //---------------habre la conexion------------------------------\\
            conexion.Open();
            //---------------se ingresa el string de la consulta sql--------\\
            //--------------Crea el comando de sql que se ejecutara---------\\
            SqlCommand command = new SqlCommand("CC.SP_INSERTAR_CUENTA", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\
            command.Parameters.AddWithValue("@M_PAGO", DropDownList1.SelectedValue);
            command.Parameters.AddWithValue("@NOMBRE_USER", nombreUsuario.SelectedValue);
            command.Parameters.AddWithValue("@TIPO_CUENTA", DropDownList2.SelectedValue);
            command.Parameters.AddWithValue("@DIRECCION", direccionC.Text);
            command.ExecuteNonQuery();
            insertarCuenta.Visible = false;
            direccionC.Text = "";
            DropDownList1.SelectedValue = "------Seleccione un método de pago------";
            DropDownList2.SelectedValue = "------Seleccione un tipo de cuenta--------";

            source.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            string nomUsuario = Convert.ToString(nombreUsuario.SelectedValue);
            source.SelectCommand = "SELECT id_cuenta from CC.cuenta where nombreusuario = '" + nomUsuario + "'";

            cuenta.Items.Clear();

            cuenta.DataSourceID = "source";
            cuenta.DataTextField = "id_cuenta";
            cuenta.DataValueField = "id_cuenta";
            cuenta.DataBind();
            cuenta.Items.Insert(0, new ListItem("(----Seleccione una cuenta----)"));


            //---------------ejecuta la consulta-------------------------------------\\
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            insertarCuenta.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            insertarCuenta.Visible = false;
            direccionC.Text = "";
            DropDownList1.SelectedValue = "------Seleccione un método de pago------";
            DropDownList2.SelectedValue = "------Seleccione un tipo de cuenta--------";

        }

        protected void nombreUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            source.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            string nomUsuario = Convert.ToString(nombreUsuario.SelectedValue);
            source.SelectCommand = "SELECT id_cuenta from CC.cuenta where nombreusuario = '" + nomUsuario + "'";

            cuenta.Items.Clear();

            cuenta.DataSourceID = "source";
            cuenta.DataTextField = "id_cuenta";
            cuenta.DataValueField = "id_cuenta";
            cuenta.DataBind();
            cuenta.Items.Insert(0, new ListItem("(----Seleccione una cuenta----)"));

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
            string strSQL = "select nombre as nombreCliente,cedula as cedulaCliente from CC.cliente where nombreusuario = '" + nomUsuario + "'";
            var datos_Consulta = new SqlCommand(strSQL, conexion);
            conexion.Open();
            SqlDataReader reader = datos_Consulta.ExecuteReader();

            reader.Read();
            string nombre = reader.GetString(reader.GetOrdinal("nombreCliente"));
            int cedula = reader.GetInt32(reader.GetOrdinal("cedulaCliente"));
            reader.Close();
            conexion.Close();
            nombreU.Text = nomUsuario;
            nombreC.Text = nombre;
            cedulaU.Text = cedula.ToString();

        }

        protected void cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cuenta.SelectedValue == "(----Seleccione una cuenta----)")
            {
                mensajeError("Cuenta Invalida");
                return;
            }
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
            string strSQL = "select metodo_pago as metodo, tipo_cuenta as tipo, direccionentrega as direccion from CC.cuenta where id_cuenta ='" + cuenta.SelectedValue + "'";
            var datos_Consulta = new SqlCommand(strSQL, conexion);
            conexion.Open();
            SqlDataReader reader = datos_Consulta.ExecuteReader();

            reader.Read();
            string metodoP = reader.GetString(reader.GetOrdinal("metodo"));
            string tipoC = reader.GetString(reader.GetOrdinal("tipo"));
            string direccionE = reader.GetString(reader.GetOrdinal("direccion"));
            reader.Close();
            conexion.Close();
            idCuenta.Text = cuenta.SelectedValue;
            metodo.Text = metodoP;
            tipo.Text = tipoC;
            direccion.Text = direccionE;
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
            string consulta_precio = "select precio_unitario from CC.producto where nombre = '" + drowProducto.SelectedValue + "'";
            string id_producto = "select id_producto from CC.producto where nombre = '" + drowProducto.SelectedValue + "'";
            string funcionVerificaInventario = "SELECT  CC.VERIFICAR_COMPRA_INVENTARIO(" + TextCantidad.Text + ",'" + drowProducto.SelectedValue + "')";

            var cn_Precio = new SqlCommand(consulta_precio, conexion);
            var cn_IDProducto = new SqlCommand(id_producto, conexion);
            var cn_verificaInventario = new SqlCommand(funcionVerificaInventario, conexion);
            SqlCommand command = new SqlCommand("CC.SP_UPDATE_INVENTARIO", conexion);
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
            string cn_cantidad = "select cantidad from CC.inventario where id_producto = '" + idProducto + "'";
            SqlCommand cmmCantidad = new SqlCommand(cn_cantidad, conexion);
            var cantidad = cmmCantidad.ExecuteScalar();
            int cantidadNueva = Int32.Parse(cantidad.ToString()) - Int32.Parse(TextCantidad.Text);
            command.Parameters.AddWithValue("@ID_Producto", idProducto);
            command.Parameters.AddWithValue("@CANTIDAD", cantidadNueva);
            command.ExecuteNonQuery();
            conexion.Close();
            ListBox1.Items.Add(drowProducto.SelectedValue);
            ListBox2.Items.Add("$ " + precio.ToString());
            ListBox3.Items.Add(TextCantidad.Text);
            int subTotal = Int32.Parse(TextCantidad.Text) * Int32.Parse(precio.ToString());
            ListBox4.Items.Add("$ " + subTotal);
            total.Text = (Int32.Parse(total.Text.ToString()) + subTotal).ToString();
            TextCantidad.Text = "";

            float p = 2;
            float i = 13;
            float t = 100;


            costoEnvio.Text = (Int32.Parse(total.Text.ToString()) * (p / t)).ToString();
            impuesto.Text = (Int32.Parse(total.Text.ToString()) * (i / t)).ToString();
            totalPagar.Text = (float.Parse(costoEnvio.Text.ToString()) + float.Parse(impuesto.Text.ToString()) + Int32.Parse(total.Text.ToString())).ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBox1.SelectedIndex == 0)
                {
                    mensajeError("Elemento invalido");
                    return;
                }

                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
                conexion.Open();
                string id_producto = "select id_producto from CC.producto where nombre = '" + ListBox1.Items[ListBox1.SelectedIndex].ToString() + "'";
                var cn_IDProducto = new SqlCommand(id_producto, conexion);
                var idProducto = cn_IDProducto.ExecuteScalar();

                string cn_cantidad = "select cantidad from CC.inventario where id_producto = '" + idProducto + "'";
                var cmm_cantidad = new SqlCommand(cn_cantidad, conexion);
                var cantidadInventario = cmm_cantidad.ExecuteScalar();
                string cantidad = ListBox3.Items[ListBox1.SelectedIndex].ToString();
                int cantidadNueva = Int32.Parse(cantidadInventario.ToString()) + Int32.Parse(cantidad);
                //---------------se ingresa el string de la consulta sql--------\\
                //--------------Crea el comando de sql que se ejecutara---------\\
                SqlCommand command = new SqlCommand("CC.SP_UPDATE_INVENTARIO", conexion);
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

            }
            catch
            {
                mensajeError("Seleccione el producto que desea eliminar de la lista");
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                lblcorreo.Visible = true;
                correo.Visible = true;
            }
            else
            {
                lblcorreo.Visible = false;
                correo.Visible = false;
                correo.Text = "";
            }

        }

        public void ChecBox1_UnCheckedChange(object sender, EventArgs e)
        {
            lblcorreo.Visible = false;
            correo.Visible = false;
            correo.Text = "";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (nombreC.Text == "" || nombreU.Text == "" || cedulaU.Text == "")
            {
                mensajeError("Debe seleccionar un nombre de usuario para poder realizar la compra");
                return;
            }
            if (idCuenta.Text == "" || metodo.Text == "" || tipo.Text == "" || direccion.Text == "")
            {
                mensajeError("Debe seleccionar una cuenta para poder realizar la compra");
                return;
            }


            if (CheckBox1.Checked == true)
            {
                bool verificarCorreo = ComprobarFormatoEmail(correo.Text);
                if (verificarCorreo == false)
                {
                    mensajeError("correo invalido");
                    return;
                }
                else
                {
                    string nombreCliente = "<br>Nombre del Cliente: " + nombreC.Text + "<br/>";
                    string nombreUsuario = "<br>Nombre de Usuario: " + nombreU.Text + "<br/>";
                    string cedula = "<br>Cédula: " + cedulaU.Text + "<br/>";
                    string Cuenta = "<br>Cuenta #: " + idCuenta.Text + "<br/>";
                    string Metodo = "<br>Metodo de Pago: " + metodo.Text + "<br/>";
                    string Tipo = "<br>Tipo de Cliente: " + tipo.Text + "<br/>";
                    string Direccion = "<br>Dirección de Entrega: " + direccion.Text + "<br/>";
                    string detalles = "<br><br/><br>" + "<<<<<<<<<<<<<<<<<<<<<<<   Detalles de la compra de productos  >>>>>>>>>>>>>>>>>>>>>>>>>" + "<br/>";
                    string encabezado = nombreCliente + nombreUsuario + cedula + Cuenta + Metodo + Tipo + Direccion + detalles;
                    string detallesProducto = "";

                    int cont = 0;
                    foreach (object producto in ListBox1.Items)
                    {
                        if (cont == 0)
                        {
                            
                        }
                        else
                        {
                            detallesProducto = detallesProducto + "<br>-----------Producto-----------<br/>" + "<br>" + producto.ToString() + "<br/>";
                            detallesProducto = detallesProducto + "<br>" + "Precio: " + ListBox2.Items[cont].ToString() + "<br/>" + "<br>" + "Cantidad: " + ListBox3.Items[cont].ToString() + "<br/>" + "<br>" + "Subtotal: " + ListBox4.Items[cont].ToString() + "<br/>";

                        }
                        cont++;
                    }

                    detallesProducto = detallesProducto + "<br>---------------------------------------------------------------------------------<br/>";
                    detallesProducto = detallesProducto + "<br>Monto Total: $ " + total.Text + "<br/>";
                    detallesProducto = detallesProducto + "<br>Costo de Envio: $ " + costoEnvio.Text + "<br/>";
                    detallesProducto = detallesProducto + "<br>Impuesto de Vento: $ " + impuesto.Text + "<br/>";
                    detallesProducto = detallesProducto + "<br>TOTAL A PAGAR: $ " + totalPagar.Text + "<br/>";
                    detallesProducto = detallesProducto + "<br>Transportista: " + transportista.Text + "<br/>";
                    detallesProducto = detallesProducto + "<br><br/>";
                    detallesProducto = detallesProducto + "<br>      Gracias por realizar la compra, estamos para servirle<br/>";
                    detallesProducto = detallesProducto + "<br><<<<<<<<<<<<<<<<<<<<<<<--------->>>>>>>>>>>>>>>>>>>>>>>>>><br/>";

                    EnviarCorreo(correo.Text, encabezado + detallesProducto);
                }
            }
            int desc = 0;
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
            SqlCommand command = new SqlCommand("CC.SP_INSERTAR_COMPRA", conexion);
            command.CommandType = CommandType.StoredProcedure;

            SqlCommand procedure = new SqlCommand("CC.SP_INSERTAR_COMPRAXCLIENTE", conexion);
            procedure.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            int con = 0;
            foreach (object producto in ListBox1.Items)
            {
                if (con == 0)
                {
                   
                }
                else
                {
                    command.Parameters.AddWithValue("@PRODUCTO", producto.ToString());
                    command.Parameters.AddWithValue("@CANTIDAD", Int32.Parse(ListBox3.Items[con].ToString()));
                    int precioU = Int32.Parse(ListBox2.Items[con].ToString().Substring(2, (ListBox2.Items[con].ToString().Length - 2)));
                    int cantidad = Int32.Parse(ListBox3.Items[con].ToString());
                    int precioTot = precioU * cantidad;

                    command.Parameters.AddWithValue("@PRECIO", precioTot);
                    command.Parameters.AddWithValue("@DESCUENTO", desc);
                    float CEnvio = float.Parse(costoEnvio.Text);
                    command.Parameters.AddWithValue("@ENVIO", CEnvio);
                    command.Parameters.AddWithValue("@TRANSPORTISTA", transportista.SelectedValue.ToString());
                    command.ExecuteNonQuery();
                    command = new SqlCommand("CC.SP_INSERTAR_COMPRA", conexion);
                    command.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@NOMBREUSUARIO", nombreU.Text);
                    procedure.ExecuteNonQuery();
                    procedure = new SqlCommand("CC.SP_INSERTAR_COMPRAXCLIENTE", conexion);
                    procedure.CommandType = CommandType.StoredProcedure;

                }
                con++;
            }
            conexion.Close();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);

            
            SqlCommand cm = new SqlCommand("CC.SP_INSERTAR_CLIENTEXCUENTAXPRODUCTO", cn);
            cn.Open();
            cm.CommandType = CommandType.StoredProcedure;
            int contador = 0;
            foreach (object producto in ListBox1.Items)
            {
                if (contador == 0)
                {
                
                }
                else
                {
                    cm.Parameters.AddWithValue("@producto", producto.ToString());
                    cm.Parameters.AddWithValue("@cuenta", idCuenta.Text.ToString());
                    cm.Parameters.AddWithValue("@nombreusuario", nombreU.Text);
                    cm.ExecuteNonQuery();
                    cm = new SqlCommand("CC.SP_INSERTAR_CLIENTEXCUENTAXPRODUCTO", cn);
                    cm.CommandType = CommandType.StoredProcedure;

                }
                contador++;
            }
            cn.Close();
            mensajeError("Compra realizada exitosamente");
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            ListBox3.Items.Clear();
            ListBox4.Items.Clear();
            ListBox1.Items.Add("--------------Producto-------------");
            ListBox2.Items.Add("----------Precio----------");
            ListBox3.Items.Add("----------Cantidad----------");
            ListBox4.Items.Add("--------SubTotal--------");
            nombreC.Text = "";
            nombreU.Text = "";
            cedulaU.Text = "";
            idCuenta.Text = "";
            metodo.Text = "";
            tipo.Text = "";
            direccion.Text = "";
            total.Text = "0";
            costoEnvio.Text = "0";
            impuesto.Text = "0";
            totalPagar.Text = "0";
            correo.Text = "";
            
        }



    }
}