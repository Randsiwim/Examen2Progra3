<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DireccionesEmpleado.aspx.cs" Inherits="SistemaEmpresaLimpieza.DireccionesEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Gestión de Direcciones de Empleados</h2>
            
            <!-- Formulario para agregar o actualizar direcciones -->
            <asp:Label ID="lblIDEmpleado" runat="server" Text="ID Empleado:"></asp:Label>
            <asp:TextBox ID="txtIDEmpleado" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="false" />
            <br /><br />

            <!-- Tabla para mostrar las direcciones -->
            <asp:GridView ID="gvDirecciones" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvDirecciones_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID_Dirección" HeaderText="ID Dirección" ReadOnly="True" />
                    <asp:BoundField DataField="ID_Empleado" HeaderText="ID Empleado" />
                    <asp:BoundField DataField="Dirección" HeaderText="Dirección" />
                    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
