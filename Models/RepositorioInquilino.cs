using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;

public class RepositorioInquilino : RepositorioBase
{
    public RepositorioInquilino(IConfiguration configuration) : base(configuration)
    {
    }

    public List<Inquilino> ObtenerTodos()
    {
        var lista = new List<Inquilino>();

        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Inquilino", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Inquilino
                {
                    IdInquilino = Convert.ToInt32(reader["idInquilino"]),
                    Nombre = reader["nombre"].ToString() ?? "",
                    Apellido = reader["apellido"].ToString() ?? "",
                    Dni = Convert.ToInt32(reader["dni"]),
                    Telefono = reader["telefono"].ToString() ?? "",
                    Email = reader["email"].ToString() ?? ""
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
            string sql = "DELETE FROM Inquilino WHERE IdInquilino = @id";

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
            string sql = "INSERT INTO Inquilino (nombre, apellido, dni, telefono, email) VALUES (@n, @a, @d, @t, @e)";
            using (var cmd = new MySqlCommand(sql, conn))
            {

                cmd.Parameters.AddWithValue("@n", i.Nombre);
                cmd.Parameters.AddWithValue("@a", i.Apellido);
                cmd.Parameters.AddWithValue("@d", i.Dni);
                cmd.Parameters.AddWithValue("@t", i.Telefono);
                cmd.Parameters.AddWithValue("@e", i.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                i.IdInquilino = Convert.ToInt32(cmd.LastInsertedId);
                return i.IdInquilino;
            }
        }
    }

    public int ModificarInquilino(Inquilino i)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            string sql = @"UPDATE Inquilino 
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