using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SistemaEmpresaLimpieza.Models;
using SistemaEmpresaLimpieza.App_Code.Models;

namespace SistemaEmpresaLimpieza.App_Code.DataAccess
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Usuarios WHERE Usuario = @Usuario";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", nombreUsuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        ID_Usuario = (int)reader["ID_Usuario"],
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString()
                    };
                }
            }

            return usuario;
        }
    }
}
