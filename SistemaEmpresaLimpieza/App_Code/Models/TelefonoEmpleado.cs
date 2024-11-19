using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.Models
{
    public class TelefonoEmpleado
    {
        public int ID_Telefono { get; set; }
        public int ID_Empleado { get; set; }
        public string NumeroTelefono { get; set; }
    }
}