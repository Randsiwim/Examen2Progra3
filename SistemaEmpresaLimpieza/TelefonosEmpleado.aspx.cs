using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaEmpresaLimpieza.Services;
using SistemaEmpresaLimpieza.Models;
using MiProyecto;

namespace SistemaEmpresaLimpieza
{
    public partial class TelefonosEmpleado : System.Web.UI.Page
    {
        private readonly TelefonoEmpleadoService _telefonoEmpleadoService = new TelefonoEmpleadoService(new DataAccess.TelefonoEmpleadoRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTelefonos();
            }
        }

        private void CargarTelefonos()
        {
            gvTelefonos.DataSource = _telefonoEmpleadoService.ObtenerTelefonos();
            gvTelefonos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var telefono = new TelefonoEmpleado
            {
                ID_Empleado = int.Parse(txtIDEmpleado.Text),
                NumeroTelefono = txtNumeroTelefono.Text
            };

            _telefonoEmpleadoService.AgregarTelefono(telefono);
            LimpiarCampos();
            CargarTelefonos();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var telefono = new TelefonoEmpleado
            {
                ID_Telefono = int.Parse(ViewState["ID_Telefono"].ToString()),
                ID_Empleado = int.Parse(txtIDEmpleado.Text),
                NumeroTelefono = txtNumeroTelefono.Text
            };

            _telefonoEmpleadoService.ActualizarTelefono(telefono);
            LimpiarCampos();
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = true;
            CargarTelefonos();
        }

        protected void gvTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTelefonos.SelectedRow;

            ViewState["ID_Telefono"] = row.Cells[0].Text;
            txtIDEmpleado.Text = row.Cells[1].Text;
            txtNumeroTelefono.Text = row.Cells[2].Text;

            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        protected void gvTelefonos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idTelefono = Convert.ToInt32(gvTelefonos.DataKeys[e.RowIndex].Value);
            _telefonoEmpleadoService.EliminarTelefono(idTelefono);
            CargarTelefonos();
        }

        private void LimpiarCampos()
        {
            txtIDEmpleado.Text = string.Empty;
            txtNumeroTelefono.Text = string.Empty;
        }
    }
}