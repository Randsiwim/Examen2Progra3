<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SistemaEmpresaLimpieza.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Bienvenido al Sistema de Gestión</h1>
            <h3>Menú Principal</h3>

            <ul>
                <li><a href="Empleados.aspx">Gestión de Empleados</a></li>
                <li><a href="TelefonosEmpleado.aspx">Gestión de Teléfonos</a></li>
                <li><a href="DireccionesEmpleado.aspx">Gestión de Direcciones</a></li>
                <li><a href="PuestosEmpleado.aspx">Gestión de Puestos</a></li>
            </ul>

            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
        </div>
    </form>
</body>
</html>
