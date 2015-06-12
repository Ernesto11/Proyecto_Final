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
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void mensajeError(String error)
        {
            string script = @"<script type='text/javascript'>alert('" + error + "');</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  ControlParameter cp = new ControlParameter("nombre", TypeCode.String, "DropDownList1", "SelectedValue");
          //  SqlDataSource1.SelectCommand = "select * from cc.cliente where nombre = @nombre";
          //  SqlDataSource1.SelectParameters.Add("@nombre",DropDownList1.SelectedValue.ToString());
         //   SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

    }
}