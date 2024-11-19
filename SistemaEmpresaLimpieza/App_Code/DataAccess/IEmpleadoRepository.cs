using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using SistemaEmpresaLimpieza.Interfaces;
using SistemaEmpresaLimpieza.Models;

namespace SistemaEmpresaLimpieza.App_Code.DataAccess
{
    public class IEmpleadoRepository
    {
        public class EmpleadoRepository : IEmpleadoRepository
        {
            private readonly string connectionString;

            public EmpleadoRepository()
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            }

            public List<Empleado> ObtenerEmpleados()
            {
                var empleados = new List<Empleado>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Empleados";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empleados.Add(new Empleado
                            {
                                ID_Empleado = Convert.ToInt32(reader["ID_Empleado"]),
                                Nombre = reader["Nombre"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"])
                            });
                        }
                    }
                }

                return empleados;
            }

            public Empleado ObtenerEmpleadoPorId(int id)
            {
                Empleado empleado = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Empleados WHERE ID_Empleado = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleado = new Empleado
                            {
                                ID_Empleado = Convert.ToInt32(reader["ID_Empleado"]),
                                Nombre = reader["Nombre"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"])
                            };
                        }
                    }
                }

                return empleado;
            }

            public void AgregarEmpleado(Empleado empleado)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Empleados (Nombre, Fecha_Nacimiento) VALUES (@Nombre, @FechaNacimiento)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public void ActualizarEmpleado(Empleado empleado)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Empleados SET Nombre = @Nombre, Fecha_Nacimiento = @FechaNacimiento WHERE ID_Empleado = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", empleado.ID_Empleado);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public void EliminarEmpleado(int id)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Empleados WHERE ID_Empleado = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
