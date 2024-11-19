<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PuestosEmpleado.aspx.cs" Inherits="SistemaEmpresaLimpieza.PuestosEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Gestión de Puestos de Empleados</h2>
            
            <!-- Formulario para agregar o actualizar puestos -->
            <asp:Label ID="lblIDEmpleado" runat="server" Text="ID Empleado:"></asp:Label>
            <asp:TextBox ID="txtIDEmpleado" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPuesto" runat="server" Text="Puesto:"></asp:Label>
            <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAnios" runat="server" Text="Años Trabajados:"></asp:Label>
            <asp:TextBox ID="txtAnios" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="false" />
            <br /><br />

            <!-- Tabla para mostrar los puestos -->
            <asp:GridView ID="gvPuestos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPuestos_SelectedIndexChanged" OnRowDeleting="gvPuestos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID_Puesto" HeaderText="ID Puesto" ReadOnly="True" />
                    <asp:BoundField DataField="ID_Empleado" HeaderText="ID Empleado" />
                    <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                    <asp:BoundField DataField="AniosTrabajados" HeaderText="Años Trabajados" />
                    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
