<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealizarCompra.aspx.cs" Inherits="Proyecto_Final.RealizarCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 46%;
            height: 169px;
        }
        .auto-style2 {
            width: 298px;
        }
        .auto-style3 {
            width: 43%;
            height: 137px;
        }
        .auto-style4 {
        }
        .auto-style5 {
            width: 191px;
        }
        .auto-style6 {
            position:absolute;
            width: 47%;
            height: 433px;
            z-index:11;
            left: 611px;
            top: 74px;
        }
        .auto-style7 {
        }
        .auto-style8 {
            width: 42%;
            height: 34px;
        }
        .auto-style9 {
            width: 179px;
        }
        .auto-style10 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Control de las Compras de la Tienda ACME<br />
        <br />
        <br />
    
    </div>
        <table class="auto-style1">
            <tr>
                <td colspan="2">Seleccione los Datos Personales del Cliente, necesarios<br />
                    par realizar la compra: </td>
            </tr>
            <tr>
                <td class="auto-style2">Seleccione el nombre de usuario del cliente:</td>
                <td>
                    <asp:DropDownList ID="nombreUsuario" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOMBREUSUARIO" DataValueField="NOMBREUSUARIO" ToolTip="Seleccione el nombre de usuario" Height="16px" Width="176px" AutoPostBack="True" OnSelectedIndexChanged="nombreUsuario_SelectedIndexChanged">
                        <asp:ListItem>---------Seleccione un Nombre de Usuario--------</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLAzureConnection %>" SelectCommand="SELECT NOMBREUSUARIO FROM CASO2.CLIENTE"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Seleccione la cuenta relacionada con el cliente:</td>
                <td>
                    <asp:DropDownList ID="cuenta" runat="server" ToolTip="Seleccione una cuenta relaciond con el nombre de usuario para realizar la compra" AutoPostBack="True" OnSelectedIndexChanged="cuenta_SelectedIndexChanged">
                        <asp:ListItem>----Seleccione una cuenta----</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Click para crear una nueva cuenta" Height="38px" ImageUrl="~/Content/login.png" Width="36px" OnClick="ImageButton1_Click" />
                </td>
            </tr>
        </table>
        <table runat="server" visible="false" class="auto-style3" id="insertarCuenta">
            <tr>
                <td class="auto-style4" colspan="2">Ingrese los siguientes datos necesarios para crear la cuenta:</td>
            </tr>
            <tr>
                <td class="auto-style5">Método de Pago</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>------Seleccione un método de pago------</asp:ListItem>
                        <asp:ListItem>Tarjeta de crédito</asp:ListItem>
                        <asp:ListItem>Tarjeta de débito</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Tipo de Cuenta:</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Value="------Seleccione un tipo de cuenta--------">------Seleccione un tipo de cuenta--------</asp:ListItem>
                        <asp:ListItem>Cliente Regular</asp:ListItem>
                        <asp:ListItem>Cliente Preferencial</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Dirección de Entrega</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="242px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:SqlDataSource ID="source" runat="server"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Height="26px" OnClick="Button1_Click" Text="Aceptar" ToolTip="Click para crear la cuenta" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancelar" />
                </td>
            </tr>
        </table>
        <table id="detallesCompra" class="auto-style6">
            <tr>
                <td colspan="2">
    <table id="detallesCompra" class="auto-style6">
        <tr>
            <td>&nbsp;</td>
        </tr>
        </table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Detalles de la Compra</td>
        </tr>
        <tr>
            <td class="auto-style10">Nombre del Cliente:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="208px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Nombre de Usuario:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="207px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Cedula:</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="203px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Cuenta:</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Width="201px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Metodo de Pago:</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Width="203px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Tipo de Cliente:</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Dirección de Entrega:</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" Width="199px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Detalles de la Compra de Productos&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="2">&nbsp;
                <asp:ListBox ID="ListBox1" runat="server" Height="162px" ToolTip="Lista de pedido de productos" Width="176px">
                    <asp:ListItem>------------Producto----------</asp:ListItem>
                </asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="ListBox2" runat="server" Height="162px" Width="119px">
                    <asp:ListItem>----------Precio----------</asp:ListItem>
                </asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="ListBox3" runat="server" Height="162px" Width="125px">
                    <asp:ListItem>--------Cantidad--------</asp:ListItem>
                </asp:ListBox>
&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="ListBox4" runat="server" Height="161px" Width="116px">
                    <asp:ListItem>--------SubTotal--------</asp:ListItem>
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Eliminar Producto" Width="113px" />
            </td>
            <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total: ₡ &nbsp;<asp:TextBox ID="total" runat="server" Height="20px" ReadOnly="True" ToolTip="Monto total de la compra" Width="115px">0</asp:TextBox>
            </td>
        </tr>
    </table>
        <p>
            Seleccione el producto y la cantidad:</p>
        <table class="auto-style8">
            <tr>
                <td class="auto-style9">Producto:</td>
                <td>
                    <asp:DropDownList ID="drowProducto" runat="server" DataSourceID="SqlDataSource2" DataTextField="nombre" DataValueField="nombre" Height="26px" Width="184px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Cantidad:</td>
                <td>
                    <asp:TextBox ID="TextCantidad" runat="server" Width="173px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLAzureConnection %>" SelectCommand="Select nombre from caso2.producto"></asp:SqlDataSource>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Agregar" ToolTip="Click para agregar el producto" />
                </td>
            </tr>
        </table>
    </form>
    </body>
</html>
