<%@ Page Language="C#"  EnableEventValidation="false" CodeBehind="Registro_Producto.aspx.cs" Inherits="Proyecto_Final.Registro_Producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 98%;
            height: 207px;
        }

        .auto-style2 {
            width: 175px;
        }

        .auto-style3 {
            width: 175px;
            height: 9px;
        }

        .auto-style5 {
        }

        .auto-style6 {
            height: 9px;
        }

        .auto-style9 {
            width: 175px;
            height: 26px;
        }

        .auto-style10 {
            height: 26px;
        }

        .auto-style12 {
        }

        .auto-style13 {
            width: 290px;
        }

        .auto-style14 {
            width: 227px;
        }

       table.registrarPlanta{
            
        }
    </style>
</head>
<body style="height: 397px; width: 526px">

    <script type='text/javascript'>
          function Forzar() {
               __doPostBack('', '');
       }
</script>

    <form id="form1" runat="server">

        
       


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="height: 632px; width: 573px">
            Registro de productos<br />
            <br />
            Para realizar el registro de un producto por favor ingrese la información que se le solicita a continuación.<br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Nombre del producto:</td>
                    <td class="auto-style5" colspan="2">
                        <asp:TextBox ID="nombre" runat="server" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Código del producto:</td>
                    <td class="auto-style5" colspan="2">
                        <asp:TextBox ID="codigo" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Costo Unitario:</td>
                    <td class="auto-style5" colspan="2">
                        <asp:TextBox ID="costo" runat="server" Width="222px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Precio de venta:</td>
                    <td class="auto-style6" colspan="2">
                        <asp:TextBox ID="precio" runat="server" Height="16px" Style="margin-top: 0px" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Descripción del producto:</td>
                    <td class="auto-style5" colspan="2">
                        <asp:TextBox ID="Descripcion" runat="server" Height="16px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Envio:</td>
                    <td class="auto-style10" colspan="2">
                        <asp:TextBox ID="envio" runat="server" Width="223px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Cantidad:</td>
                    <td class="auto-style5" colspan="2">
                        <asp:TextBox ID="cantidad" runat="server" Width="222px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Planta:</td>
                    <td class="auto-style14">
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOMBRE" DataValueField="NOMBRE" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="29px" Width="177px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        
                       <asp:ImageButton ID="ImageButton1" runat="server" Height="62px"  ImageUrl="~/Content/20150608054705293_easyicon_net_256.png" Width="62px" OnClick="ImageButton1_Click" />
                    
                    
                                
                                </td>
                </tr>
            </table>

            <br />
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table id="registrarPlanta" runat="server" class="registrarPlanta" visible="false">
                        <tr>
                            <td class="auto-style12" colspan="2">Ingrese los siguientes Datos para ingresar la planta&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Nombre de la Planta:</td>
                            <td>
                                <asp:TextBox ID="nombrePlanta" runat="server" Width="243px" Height="18px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Código de la Planta:</td>
                            <td>
                                <asp:TextBox ID="codigoPlanta" runat="server" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Código ZIP</td>
                            <td>
                                <asp:TextBox ID="codigoZIP" runat="server" Width="241px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Región</td>
                            <td>
                                <asp:TextBox ID="region" runat="server" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">País</td>
                            <td>
                                <asp:DropDownList ID="listaPaises" runat="server" Height="18px" Width="246px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLAzureConnection %>" SelectCommand="SELECT NOMBRE FROM CC.PLANTA "></asp:SqlDataSource>
                            </td>
                            <td>



                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insertar Planta" />





                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cancelar" Width="87px" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />

                </Triggers>

            </asp:UpdatePanel>
            &nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar Producto" Width="153px" style="margin-bottom: 0px" />
            <br />

        </div>
    </form>
    <p>
&nbsp;</p>
</body>
</html>

