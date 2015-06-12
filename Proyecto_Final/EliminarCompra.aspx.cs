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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("(Seleccione un nombre de usuario)"));
            }
        }


        public void mensajeError(String error)
        {
            string script = @"<script type='text/javascript'>alert('" + error + "');</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }


        protected void GridView1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];


                //---------------Conexion con la base de datos------------------\\
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString);
                //---------------habre la conexion------------------------------\\
                conexion.Open();
                SqlCommand command = new SqlCommand("CC.SP_DELETE_COMPRA", conexion);
                command.CommandType = CommandType.StoredProcedure;
                //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\
                command.Parameters.AddWithValue("@ID_COMPRA", Int32.Parse(cell.Text));
                //---------------ejecuta la consulta-------------------------------------\\
                command.ExecuteNonQuery();
                conexion.Close();
                GridView1.DataBind();
                SqlDataSource1.DataBind();
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("(Seleccione un nombre de usuario)"));
                mensajeError("Compra Eliminada Correctamente");
            }
            catch
            {
                mensajeError("Error al tratar de eliminar la compra");
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() == "(Seleccione un nombre de usuario)")
            {
                mensajeError("Elemento Invalido");
                return;
            }
            ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["SQLAzureConnection"];
            string consulta = "SELECT C.ID_COMPRA AS COMPRA,CL.NOMBRE AS CLIENTE, P.NOMBRE AS PRODUCTO, C.CANTIDAD AS CANTIDAD, C.PRECIO_TOTAL AS PRECIO_TOTAL, C.FECHA_COMPRA AS FECHA FROM CC.COMPRAXCLIENTE CXC INNER JOIN CC.CLIENTE CL ON CXC.ID_CLIENTE =  CL.ID_CLIENTE INNER JOIN CC.COMPRA C ON C.ID_COMPRA = CXC.ID_COMPRA INNER JOIN CC.PRODUCTO P ON P.ID_PRODUCTO = C.ID_PRODUCTO WHERE CL.NOMBREUSUARIO = '"+DropDownList1.SelectedValue.ToString()+"'";

            //    SqlDataSource sds
            //      = new SqlDataSource(cts.ConnectionString, "SELECT EmployeeID FROM Employees");
            
            SqlDataSource source = new SqlDataSource(cts.ConnectionString, consulta);
            source.DeleteCommand = "Delete from cc.compra where id_compraa = @id_compra";
            source.DataBind();
            GridView1.DataSource = source;
            GridView1.DataBind();

        }
    }
}