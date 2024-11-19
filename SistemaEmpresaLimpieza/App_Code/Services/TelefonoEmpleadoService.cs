using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaEmpresaLimpieza.App_Code.Interfaces;
using SistemaEmpresaLimpieza.App_Code.Models;
using SistemaEmpresaLimpieza.Interfaces;
using SistemaEmpresaLimpieza.Models;

namespace SistemaEmpresaLimpieza.App_Code.Services
{
    public class TelefonoEmpleadoService
    {
        private readonly ITelefonoEmpleadoRepository _telefonoEmpleadoRepository;

        public TelefonoEmpleadoService(ITelefonoEmpleadoRepository telefonoEmpleadoRepository)
        {
            _telefonoEmpleadoRepository = telefonoEmpleadoRepository;
        }

        public List<TelefonoEmpleado> ObtenerTelefonos(int idEmpleado)
        {
            return _telefonoEmpleadoRepository.ObtenerTelefonosPorEmpleado(idEmpleado);
        }

        public void AgregarTelefono(TelefonoEmpleado telefono)
        {
            _telefonoEmpleadoRepository.AgregarTelefono(telefono);
        }

        public void ActualizarTelefono(TelefonoEmpleado telefono)
        {
            _telefonoEmpleadoRepository.ActualizarTelefono(telefono);
        }

        public void EliminarTelefono(int idTelefono)
        {
            _telefonoEmpleadoRepository.EliminarTelefono(idTelefono);
        }
    }
}
