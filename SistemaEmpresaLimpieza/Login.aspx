<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaEmpresaLimpieza.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <label for="txtUsuario">Usuario:</label>
            <input type="text" id="txtUsuario" runat="server" /><br />
            
            <label for="txtClave">Contraseña:</label>
            <input type="password" id="txtClave" runat="server" /><br />
            
            <button type="submit" runat="server" onserverclick="btnLogin_Click">Ingresar</button>
        </div>
    </form>
</body>
</html>
