using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaEmpresaLimpieza.App_Code.DataAccess;
using SistemaEmpresaLimpieza.App_Code.Models;
using SistemaEmpresaLimpieza.DataAccess;
using SistemaEmpresaLimpieza.Models;

namespace SistemaEmpresaLimpieza.App_Code.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool ValidarCredenciales(string nombreUsuario, string clave)
        {
            Usuario usuario = _usuarioRepository.ObtenerUsuario(nombreUsuario);

            if (usuario == null)
                return false;

            // Aquí se puede agregar la lógica de encriptación para comparar claves
            return usuario.Clave == clave;
        }
    }
}
