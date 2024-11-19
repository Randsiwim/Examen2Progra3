<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelefonosEmpleado.aspx.cs" Inherits="MiProyecto.TelefonosEmpleado" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestión de Teléfonos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Gestión de Teléfonos de Empleados</h2>
            
            <!-- Formulario para agregar o actualizar teléfonos -->
            <asp:Label ID="lblIDEmpleado" runat="server" Text="ID Empleado:"></asp:Label>
            <asp:TextBox ID="txtIDEmpleado" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNumeroTelefono" runat="server" Text="Número de Teléfono:"></asp:Label>
            <asp:TextBox ID="txtNumeroTelefono" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="false" />
            <br /><br />

            <!-- Tabla para mostrar los teléfonos -->
            <asp:GridView ID="gvTelefonos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvTelefonos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID_Teléfono" HeaderText="ID Teléfono" ReadOnly="True" />
                    <asp:BoundField DataField="ID_Empleado" HeaderText="ID Empleado" />
                    <asp:BoundField DataField="Numero_Teléfono" HeaderText="Número de Teléfono" />
                    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
