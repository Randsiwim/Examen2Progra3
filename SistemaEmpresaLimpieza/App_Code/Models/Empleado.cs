using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.Models
{
    public class Empleado
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}