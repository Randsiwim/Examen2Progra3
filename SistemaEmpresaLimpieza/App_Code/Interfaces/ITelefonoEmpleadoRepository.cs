using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.Interfaces
{
    public class ITelefonoEmpleadoRepository
    {
        List<TelefonoEmpleado> ObtenerTelefonosPorEmpleado(int idEmpleado);
        void AgregarTelefono(TelefonoEmpleado telefono);
        void ActualizarTelefono(TelefonoEmpleado telefono);
        void EliminarTelefono(int idTelefono);
    }
}