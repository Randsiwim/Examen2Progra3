using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.Models
{
    public class DireccionEmpleado
    {
        public int ID_Direccion { get; set; }
        public int ID_Empleado { get; set; }
        public string Direccion { get; set; }
    }
}