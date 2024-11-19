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
    public class PuestoEmpleadoService
    {
        private readonly IPuestoEmpleadoRepository _puestoEmpleadoRepository;

        public PuestoEmpleadoService(IPuestoEmpleadoRepository puestoEmpleadoRepository)
        {
            _puestoEmpleadoRepository = puestoEmpleadoRepository;
        }

        public List<PuestoEmpleado> ObtenerPuestos(int idEmpleado)
        {
            return _puestoEmpleadoRepository.ObtenerPuestosPorEmpleado(idEmpleado);
        }

        public void AgregarPuesto(PuestoEmpleado puesto)
        {
            _puestoEmpleadoRepository.AgregarPuesto(puesto);
        }

        public void ActualizarPuesto(PuestoEmpleado puesto)
        {
            _puestoEmpleadoRepository.ActualizarPuesto(puesto);
        }

        public void EliminarPuesto(int idPuesto)
        {
            _puestoEmpleadoRepository.EliminarPuesto(idPuesto);
        }
    }
}