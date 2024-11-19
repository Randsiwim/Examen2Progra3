using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.Models
{
    public class PuestoEmpleado
    {
        public int ID_Puesto { get; set; }
        public int ID_Empleado { get; set; }
        public string Puesto { get; set; }
        public int AniosTrabajados { get; set; }
    }
}