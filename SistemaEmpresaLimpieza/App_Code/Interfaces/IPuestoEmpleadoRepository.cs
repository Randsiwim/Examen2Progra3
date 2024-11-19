using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaEmpresaLimpieza.Models;

namespace SistemaEmpresaLimpieza.App_Code.Interfaces
{
    public interface IPuestoEmpleadoRepository
    {
        List<PuestoEmpleado> ObtenerPuestosPorEmpleado(int idEmpleado);
        void AgregarPuesto(PuestoEmpleado puesto);
        void ActualizarPuesto(PuestoEmpleado puesto);
        void EliminarPuesto(int idPuesto);
    }
}