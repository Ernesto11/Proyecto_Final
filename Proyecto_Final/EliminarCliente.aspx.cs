﻿using System;
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
    public partial class EliminarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("(Seleccione el cliente que desea eliminar)"));
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
                SqlCommand command = new SqlCommand("CC.SP_DELETE_CLIENTE", conexion);
                command.CommandType = CommandType.StoredProcedure;
                //---------------agrega los parametros de los campos de texto a la consulta para insertarlos a la bd----------------\\
                command.Parameters.AddWithValue("@ID_CLIENTE", Int32.Parse(cell.Text));
                //---------------ejecuta la consulta-------------------------------------\\
                command.ExecuteNonQuery();
                conexion.Close();
                GridView1.DataBind();
                SqlDataSource1.DataBind();
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("(Seleccione el cliente que desea eliminar)"));
                mensajeError("Cliente eliminado Correctamente");
            }
            catch
            {
                mensajeError("El cliente que desea eliminar tiene varias compras relacionadas y no puede ser eliminado");
            }
   
        }  
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() == "(Seleccione el cliente que desea eliminar)")
            {
                mensajeError("Elemento Invalido");
                return;
            }

            ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["SQLAzureConnection"];

        //    SqlDataSource sds
        //      = new SqlDataSource(cts.ConnectionString, "SELECT EmployeeID FROM Employees");

            SqlDataSource source = new SqlDataSource(cts.ConnectionString,"SELECT * FROM CC.CLIENTE WHERE NOMBRE = '"+DropDownList1.SelectedValue.ToString()+"'");
            source.DeleteCommand = "Delete from cc.cliente where id_cliente = @id_cliente";
            source.DataBind();
            GridView1.DataSource = source;
            GridView1.DataBind();
        }
    }
}