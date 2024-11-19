using SistemaEmpresaLimpieza.App_Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaEmpresaLimpieza.App_Code.DataAccess
{
    public class DireccionEmpleadoRepository : IDireccionEmpleadoRepository
    {
        private readonly string connectionString;

        public DireccionEmpleadoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<DireccionEmpleado> ObtenerDireccionesPorEmpleado(int idEmpleado)
        {
            var direcciones = new List<DireccionEmpleado>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM DireccionesEmpleado WHERE ID_Empleado = @ID_Empleado";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Empleado", idEmpleado);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        direcciones.Add(new DireccionEmpleado
                        {
                            ID_Direccion = Convert.ToInt32(reader["ID_Dirección"]),
                            ID_Empleado = Convert.ToInt32(reader["ID_Empleado"]),
                            Direccion = reader["Dirección"].ToString()
                        });
                    }
                }
            }

            return direcciones;
        }

        public void AgregarDireccion(DireccionEmpleado direccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DireccionesEmpleado (ID_Empleado, Dirección) VALUES (@ID_Empleado, @Direccion)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Empleado", direccion.ID_Empleado);
                cmd.Parameters.AddWithValue("@Direccion", direccion.Direccion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDireccion(DireccionEmpleado direccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE DireccionesEmpleado SET Dirección = @Direccion WHERE ID_Dirección = @ID_Direccion";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Direccion", direccion.ID_Direccion);
                cmd.Parameters.AddWithValue("@Direccion", direccion.Direccion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarDireccion(int idDireccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM DireccionesEmpleado WHERE ID_Dirección = @ID_Direccion";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Direccion", idDireccion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
