using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEmpresaLimpieza
{
    public partial class DireccionesEmpleado : System.Web.UI.Page
    {
        private readonly DireccionEmpleadoService _direccionEmpleadoService = new DireccionEmpleadoService(new DataAccess.DireccionEmpleadoRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDirecciones();
            }
        }

        private void CargarDirecciones()
        {
            gvDirecciones.DataSource = _direccionEmpleadoService.ObtenerDirecciones();
            gvDirecciones.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var direccion = new DireccionEmpleado
            {
                ID_Empleado = int.Parse(txtIDEmpleado.Text),
                Direccion = txtDireccion.Text
            };

            _direccionEmpleadoService.AgregarDireccion(direccion);
            LimpiarCampos();
            CargarDirecciones();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var direccion = new DireccionEmpleado
            {
                ID_Direccion = int.Parse(ViewState["ID_Direccion"].ToString()),
                ID_Empleado = int.Parse(txtIDEmpleado.Text),
                Direccion = txtDireccion.Text
            };

            _direccionEmpleadoService.ActualizarDireccion(direccion);
            LimpiarCampos();
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = true;
            CargarDirecciones();
        }

        protected void gvDirecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDirecciones.SelectedRow;

            ViewState["ID_Direccion"] = row.Cells[0].Text;
            txtIDEmpleado.Text = row.Cells[1].Text;
            txtDireccion.Text = row.Cells[2].Text;

            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        protected void gvDirecciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idDireccion = Convert.ToInt32(gvDirecciones.DataKeys[e.RowIndex].Value);
            _direccionEmpleadoService.EliminarDireccion(idDireccion);
            CargarDirecciones();
        }

        private void LimpiarCampos()
        {
            txtIDEmpleado.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }
    }
}