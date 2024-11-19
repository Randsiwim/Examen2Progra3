using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.Interfaces
{
    public interface IDireccionEmpleadoRepository
    {
        List<DireccionEmpleado> ObtenerDireccionesPorEmpleado(int idEmpleado);
        void AgregarDireccion(DireccionEmpleado direccion);
        void ActualizarDireccion(DireccionEmpleado direccion);
        void EliminarDireccion(int idDireccion);
    }
}