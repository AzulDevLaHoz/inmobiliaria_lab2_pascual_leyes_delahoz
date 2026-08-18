using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;

public class RepositorioInquilino
{
    private string connectionString = "DATOS DE LA CONEXION"; // Faltan los datos de la conexion RepoBase

    public List<Inquilino> ObtenerTodos()
    {
        var lista = new List<Inquilino>();

        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM inquilinos", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Inquilino
                {
                    IdInquilino = Convert.ToInt32(reader["IdInquilino"]),
                    Nombre = reader["Nombre"].ToString() ?? "",
                    Apellido = reader["Apellido"].ToString() ?? "",
                    Telefono = reader["Telefono"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? ""
                });
            }
        }
        return lista;
    }
    public int Baja(int id)
    {
        int res = -1;

        using (var conn = new MySqlConnection(connectionString))
        {
            string sql = "DELETE FROM inquilinos WHERE IdInquilino = @id";

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                res = cmd.ExecuteNonQuery();
            }
        }

        return res;
    }

    public int Alta(Inquilino i)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            string sql = "INSERT INTO inquilinos (Nombre, Apellido, Telefono, Email) VALUES (@n, @a, @t, @e)";
            var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@n", i.Nombre);
            cmd.Parameters.AddWithValue("@a", i.Apellido);
            cmd.Parameters.AddWithValue("@t", i.Telefono);
            cmd.Parameters.AddWithValue("@e", i.Email);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }

    public int ModificarInquilino(Inquilino i)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            string sql = @"UPDATE inquilinos 
                           SET Nombre = @n, 
                               Apellido = @a, 
                               Telefono = @t, 
                               Email = @e 
                           WHERE IdInquilino = @id;";

            var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", i.IdInquilino);
            cmd.Parameters.AddWithValue("@n", i.Nombre);
            cmd.Parameters.AddWithValue("@a", i.Apellido);
            cmd.Parameters.AddWithValue("@t", i.Telefono);
            cmd.Parameters.AddWithValue("@e", i.Email);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}