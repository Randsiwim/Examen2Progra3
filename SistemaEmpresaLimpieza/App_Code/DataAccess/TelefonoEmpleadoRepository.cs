using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SistemaEmpresaLimpieza.Interfaces;
using SistemaEmpresaLimpieza.Models;
using System.Linq;
using System.Web;
using SistemaEmpresaLimpieza.App_Code.Interfaces;

namespace SistemaEmpresaLimpieza.App_Code.DataAccess
{
    public class TelefonoEmpleadoRepository : ITelefonoEmpleadoRepository
    {
        private readonly string connectionString;

        public TelefonoEmpleadoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<TelefonoEmpleado> ObtenerTelefonosPorEmpleado(int idEmpleado)
        {
            var telefonos = new List<TelefonoEmpleado>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TelefonosEmpleado WHERE ID_Empleado = @ID_Empleado";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Empleado", idEmpleado);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        telefonos.Add(new TelefonoEmpleado
                        {
                            ID_Telefono = Convert.ToInt32(reader["ID_Teléfono"]),
                            ID_Empleado = Convert.ToInt32(reader["ID_Empleado"]),
                            NumeroTelefono = reader["Numero_Teléfono"].ToString()
                        });
                    }
                }
            }

            return telefonos;
        }

        public void AgregarTelefono(TelefonoEmpleado telefono)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TelefonosEmpleado (ID_Empleado, Numero_Teléfono) VALUES (@ID_Empleado, @NumeroTelefono)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Empleado", telefono.ID_Empleado);
                cmd.Parameters.AddWithValue("@NumeroTelefono", telefono.NumeroTelefono);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarTelefono(TelefonoEmpleado telefono)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE TelefonosEmpleado SET Numero_Teléfono = @NumeroTelefono WHERE ID_Teléfono = @ID_Telefono";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Telefono", telefono.ID_Telefono);
                cmd.Parameters.AddWithValue("@NumeroTelefono", telefono.NumeroTelefono);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarTelefono(int idTelefono)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TelefonosEmpleado WHERE ID_Teléfono = @ID_Telefono";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Telefono", idTelefono);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
