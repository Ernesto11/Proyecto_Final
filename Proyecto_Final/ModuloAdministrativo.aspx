<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuloAdministrativo.aspx.cs" Inherits="Proyecto_Final.ModuloAdministrativo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modulo Administrativo</title>


    <style type="text/css">
        .auto-style1 {
            height: 516px;
            width: 443px;
        }

        .auto-style2 {
            width: 206px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Modulo Administrativo
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Insertar Cliente</p>
        <p>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <!---------------------------funciones mostrar y ocultar-------------------------->
             <script type="text/javascript">
                 function mostrarInsertar() {
                     document.getElementById('seccionInsertarCliente').style.display = 'block';
                 
                 }
                 </script>

            <!----------------------------------------Tabla de Insertar Cliente------------------------------------->
            <div id="seccionInsertarCliente" class="seccionInsertar">
               


            <br />

        <table class="auto-style1" id="registroCliente" runat="server" translate="no">
            <tr>
                <td class="auto-style2">Nombre:</td>
                <td translate="yes">
                    <asp:TextBox ID="nombre" runat="server" Height="16px" Width="124px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Apellido:</td>
                <td translate="yes">
                    <asp:TextBox ID="apellido" runat="server" Height="16px" Width="123px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Nombre de usuario:</td>
                <td translate="yes">
                    <asp:TextBox ID="n_usuario" runat="server" Height="16px" Width="125px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Fecha de nacimiento:</td>
                <td translate="yes">
                    <asp:TextBox ID="fecha" runat="server" ReadOnly="True"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="36px" ImageUrl="~/Content/calendario_icono.png" Width="35px" OnClick="ImageButton1_Click1" ToolTip="Click para seleccionar una fecha" />

                    <br />

                    <br />
                    <asp:Label ID="Año" runat="server" Text="Año:" Visible="False"></asp:Label>
                    <!-----------------------------DropDownList selector de año------------------------------------>
                    &nbsp;<asp:DropDownList ID="añoSelect" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="añoSelect_SelectedIndexChanged">
                        <asp:ListItem>1910</asp:ListItem>
                        <asp:ListItem>1911</asp:ListItem>
                        <asp:ListItem>1912</asp:ListItem>
                        <asp:ListItem>1913</asp:ListItem>
                        <asp:ListItem>1914</asp:ListItem>
                        <asp:ListItem>1915</asp:ListItem>
                        <asp:ListItem>1916</asp:ListItem>
                        <asp:ListItem>1917</asp:ListItem>
                        <asp:ListItem>1918</asp:ListItem>
                        <asp:ListItem>1919</asp:ListItem>
                        <asp:ListItem>1920</asp:ListItem>
                        <asp:ListItem>1921</asp:ListItem>
                        <asp:ListItem>1922</asp:ListItem>
                        <asp:ListItem>1923</asp:ListItem>
                        <asp:ListItem>1924</asp:ListItem>
                        <asp:ListItem>1925</asp:ListItem>
                        <asp:ListItem>1926</asp:ListItem>
                        <asp:ListItem>1927</asp:ListItem>
                        <asp:ListItem>1928</asp:ListItem>
                        <asp:ListItem>1929</asp:ListItem>
                        <asp:ListItem>1930</asp:ListItem>
                        <asp:ListItem>1931</asp:ListItem>
                        <asp:ListItem>1932</asp:ListItem>
                        <asp:ListItem>1933</asp:ListItem>
                        <asp:ListItem>1934</asp:ListItem>
                        <asp:ListItem>1935</asp:ListItem>
                        <asp:ListItem>1936</asp:ListItem>
                        <asp:ListItem>1937</asp:ListItem>
                        <asp:ListItem>1938</asp:ListItem>
                        <asp:ListItem>1939</asp:ListItem>
                        <asp:ListItem>1940</asp:ListItem>
                        <asp:ListItem>1941</asp:ListItem>
                        <asp:ListItem>1942</asp:ListItem>
                        <asp:ListItem>1943</asp:ListItem>
                        <asp:ListItem>1944</asp:ListItem>
                        <asp:ListItem>1945</asp:ListItem>
                        <asp:ListItem>1946</asp:ListItem>
                        <asp:ListItem>1947</asp:ListItem>
                        <asp:ListItem>1948</asp:ListItem>
                        <asp:ListItem>1949</asp:ListItem>
                        <asp:ListItem>1950</asp:ListItem>
                        <asp:ListItem>1951</asp:ListItem>
                        <asp:ListItem>1952</asp:ListItem>
                        <asp:ListItem>1953</asp:ListItem>
                        <asp:ListItem>1954</asp:ListItem>
                        <asp:ListItem>1955</asp:ListItem>
                        <asp:ListItem>1956</asp:ListItem>
                        <asp:ListItem>1957</asp:ListItem>
                        <asp:ListItem>1958</asp:ListItem>
                        <asp:ListItem>1959</asp:ListItem>
                        <asp:ListItem>1960</asp:ListItem>
                        <asp:ListItem>1961</asp:ListItem>
                        <asp:ListItem>1962</asp:ListItem>
                        <asp:ListItem>1963</asp:ListItem>
                        <asp:ListItem>1964</asp:ListItem>
                        <asp:ListItem>1965</asp:ListItem>
                        <asp:ListItem>1966</asp:ListItem>
                        <asp:ListItem>1967</asp:ListItem>
                        <asp:ListItem>1968</asp:ListItem>
                        <asp:ListItem>1969</asp:ListItem>
                        <asp:ListItem>1970</asp:ListItem>
                        <asp:ListItem>1971</asp:ListItem>
                        <asp:ListItem>1972</asp:ListItem>
                        <asp:ListItem>1973</asp:ListItem>
                        <asp:ListItem>1974</asp:ListItem>
                        <asp:ListItem>1975</asp:ListItem>
                        <asp:ListItem>1976</asp:ListItem>
                        <asp:ListItem>1977</asp:ListItem>
                        <asp:ListItem>1978</asp:ListItem>
                        <asp:ListItem>1979</asp:ListItem>
                        <asp:ListItem>1980</asp:ListItem>
                        <asp:ListItem>1981</asp:ListItem>
                        <asp:ListItem>1982</asp:ListItem>
                        <asp:ListItem>1983</asp:ListItem>
                        <asp:ListItem>1984</asp:ListItem>
                        <asp:ListItem>1985</asp:ListItem>
                        <asp:ListItem>1986</asp:ListItem>
                        <asp:ListItem>1987</asp:ListItem>
                        <asp:ListItem>1988</asp:ListItem>
                        <asp:ListItem>1989</asp:ListItem>
                        <asp:ListItem>1990</asp:ListItem>
                        <asp:ListItem>1991</asp:ListItem>
                        <asp:ListItem>1992</asp:ListItem>
                        <asp:ListItem>1993</asp:ListItem>
                        <asp:ListItem>1994</asp:ListItem>
                        <asp:ListItem>1995</asp:ListItem>
                        <asp:ListItem>1996</asp:ListItem>
                        <asp:ListItem>1997</asp:ListItem>
                        <asp:ListItem>1998</asp:ListItem>
                        <asp:ListItem>1999</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem>2001</asp:ListItem>
                        <asp:ListItem>2002</asp:ListItem>
                        <asp:ListItem>2003</asp:ListItem>
                        <asp:ListItem>2004</asp:ListItem>
                        <asp:ListItem>2005</asp:ListItem>
                        <asp:ListItem>2006</asp:ListItem>
                        <asp:ListItem>2007</asp:ListItem>
                        <asp:ListItem>2008</asp:ListItem>
                        <asp:ListItem>2009</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Mes" runat="server" Text="Mes:" Visible="False"></asp:Label>
                    <!-----------------------------DropDownList selector de mes------------------------------------>
                    &nbsp;<asp:DropDownList ID="mesSelector" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="mesSelector_SelectedIndexChanged">
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Setiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>

                    <br />
                    <!-----------------------------------------------------------------Calendario para seleccion de fecha-------------->
                    <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="182px" NextPrevFormat="ShortMonth" Visible="False" Width="300px" OnSelectionChanged="Calendar_SelectionChanged" BorderStyle="Solid" CellSpacing="1">


                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">Cédula:</td>
                <td translate="yes">
                    <asp:TextBox ID="cedula" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Género:</td>
                <td translate="yes">
                    <asp:DropDownList ID="genero" runat="server">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Teléfono:</td>
                <td translate="yes">
                    <asp:TextBox ID="telefono" runat="server" Width="118px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Dirección: </td>
                <td translate="yes">
                    <asp:TextBox ID="direccion" runat="server" Height="62px" Width="292px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td translate="yes">
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Insertar" />
                </td>
            </tr>
        </table>
        </p>
       </div>  
         
    </form>

</body>
</html>
