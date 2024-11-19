using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaEmpresaLimpieza.Services;
using SistemaEmpresaLimpieza.DataAccess;

namespace SistemaEmpresaLimpieza
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UsuarioService _usuarioService = new UsuarioService(new UsuarioRepository("tu_conexion"));

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string clave = txtClave.Text;

            if (_usuarioService.ValidarCredenciales(usuario, clave))
            {
                Session["Usuario"] = usuario; // Almacena el usuario en la sesión
                Response.Redirect("Menu.aspx");
            }
            else
            {
                lblMensaje.Text = "Credenciales inválidas. Inténtelo de nuevo.";
            }
        }
    }
}

