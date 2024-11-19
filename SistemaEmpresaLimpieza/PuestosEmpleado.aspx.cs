using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEmpresaLimpieza
{
    public partial class PuestosEmpleado : System.Web.UI.Page
    {
        private readonly PuestoEmpleadoService _puestoEmpleadoService = new PuestoEmpleadoService(new DataAccess.PuestoEmpleadoRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPuestos();
            }
        }

        private void CargarPuestos()
        {
            gvPuestos.DataSource = _puestoEmpleadoService.ObtenerPuestos();
            gvPuestos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var puesto = new PuestoEmpleado
            {
                ID_Empleado = int.Parse(txtIDEmpleado.Text),
                Puesto = txtPuesto.Text,
                AniosTrabajados = int.Parse(txtAnios.Text)
            };

            _puestoEmpleadoService.AgregarPuesto(puesto);
            LimpiarCampos();
            CargarPuestos();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var puesto = new PuestoEmpleado
            {
                ID_Puesto = int.Parse(ViewState["ID_Puesto"].ToString()),
                ID_Empleado = int.Parse(txtIDEmpleado.Text),
                Puesto = txtPuesto.Text,
                AniosTrabajados = int.Parse(txtAnios.Text)
            };

            _puestoEmpleadoService.ActualizarPuesto(puesto);
            LimpiarCampos();
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = true;
            CargarPuestos();
        }

        protected void gvPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPuestos.SelectedRow;

            ViewState["ID_Puesto"] = row.Cells[0].Text;
            txtIDEmpleado.Text = row.Cells[1].Text;
            txtPuesto.Text = row.Cells[2].Text;
            txtAnios.Text = row.Cells[3].Text;

            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        protected void gvPuestos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPuesto = Convert.ToInt32(gvPuestos.DataKeys[e.RowIndex].Value);
            _puestoEmpleadoService.EliminarPuesto(idPuesto);
            CargarPuestos();
        }

        private void LimpiarCampos()
        {
            txtIDEmpleado.Text = string.Empty;
            txtPuesto.Text = string.Empty;
            txtAnios.Text = string.Empty;
        }
    }
}