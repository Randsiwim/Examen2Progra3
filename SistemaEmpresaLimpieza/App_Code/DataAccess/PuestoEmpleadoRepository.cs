using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using SistemaEmpresaLimpieza.Interfaces;
using SistemaEmpresaLimpieza.Models;

namespace SistemaEmpresaLimpieza.App_Code.DataAccess
{
    public class PuestoEmpleadoRepository : IPuestoEmpleadoRepository
    {
        private readonly string connectionString;

        public PuestoEmpleadoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<PuestoEmpleado> ObtenerPuestosPorEmpleado(int idEmpleado)
        {
            var puestos = new List<PuestoEmpleado>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PuestosEmpleado WHERE ID_Empleado = @ID_Empleado";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Empleado", idEmpleado);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        puestos.Add(new PuestoEmpleado
                        {
                            ID_Puesto = Convert.ToInt32(reader["ID_Puesto"]),
                            ID_Empleado = Convert.ToInt32(reader["ID_Empleado"]),
                            Puesto = reader["Puesto"].ToString(),
                            AniosTrabajados = Convert.ToInt32(reader["Años_Trabajados"])
                        });
                    }
                }
            }

            return puestos;
        }

        public void AgregarPuesto(PuestoEmpleado puesto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PuestosEmpleado (ID_Empleado, Puesto, Años_Trabajados) VALUES (@ID_Empleado, @Puesto, @AniosTrabajados)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Empleado", puesto.ID_Empleado);
                cmd.Parameters.AddWithValue("@Puesto", puesto.Puesto);
                cmd.Parameters.AddWithValue("@AniosTrabajados", puesto.AniosTrabajados);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarPuesto(PuestoEmpleado puesto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE PuestosEmpleado SET Puesto = @Puesto, Años_Trabajados = @AniosTrabajados WHERE ID_Puesto = @ID_Puesto";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Puesto", puesto.ID_Puesto);
                cmd.Parameters.AddWithValue("@Puesto", puesto.Puesto);
                cmd.Parameters.AddWithValue("@AniosTrabajados", puesto.AniosTrabajados);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPuesto(int idPuesto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PuestosEmpleado WHERE ID_Puesto = @ID_Puesto";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID_Puesto", idPuesto);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
