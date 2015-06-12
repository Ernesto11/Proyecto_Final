using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Final
{
    public partial class ClienteEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlParameter cp = new ControlParameter("nombre", TypeCode.String, "DropDownList1", "SelectedValue");
            SqlDataSource2.SelectCommand = "select * from cc.cliente where nombre = @nombre";
            SqlDataSource2.SelectParameters.Add("nombre", DropDownList1.SelectedValue.ToString());
            SqlDataSource2.DataBind();
            GridView1.DataSource = SqlDataSource2;
            GridView1.DataBind();
        }
    }
}