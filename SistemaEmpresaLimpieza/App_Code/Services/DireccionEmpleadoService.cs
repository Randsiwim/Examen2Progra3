using System.Collections.Generic;
using SistemaEmpresaLimpieza.App_Code.Interfaces;
using SistemaEmpresaLimpieza.App_Code.Models;
using SistemaEmpresaLimpieza.Interfaces;
using SistemaEmpresaLimpieza.Models;

namespace SistemaEmpresaLimpieza.App_Code.Services
{
    public class DireccionEmpleadoService
    {
        private readonly IDireccionEmpleadoRepository _direccionEmpleadoRepository;

        public DireccionEmpleadoService(IDireccionEmpleadoRepository direccionEmpleadoRepository)
        {
            _direccionEmpleadoRepository = direccionEmpleadoRepository;
        }

        public List<DireccionEmpleado> ObtenerDirecciones(int idEmpleado)
        {
            return _direccionEmpleadoRepository.ObtenerDireccionesPorEmpleado(idEmpleado);
        }

        public void AgregarDireccion(DireccionEmpleado direccion)
        {
            _direccionEmpleadoRepository.AgregarDireccion(direccion);
        }

        public void ActualizarDireccion(DireccionEmpleado direccion)
        {
            _direccionEmpleadoRepository.ActualizarDireccion(direccion);
        }

        public void EliminarDireccion(int idDireccion)
        {
            _direccionEmpleadoRepository.EliminarDireccion(idDireccion);
        }
    }
}
