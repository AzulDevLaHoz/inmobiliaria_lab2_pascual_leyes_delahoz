using System;
using System.Data;
using Microsoft.AspNetCore.Routing.Internal;
using MySql.Data.MySqlClient;


namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{

    public class RepositorioPropietario : RepositorioBase, IRepositorioPropietario
    {
        public RepositorioPropietario(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(Propietario p)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO propietario (Nombre, Apellido, Telefono, Email) VALUES (@n, @a, @t, @e)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", p.Nombre);
                    cmd.Parameters.AddWithValue("@a", p.Apellido);
                    cmd.Parameters.AddWithValue("@t", p.Telefono);
                    cmd.Parameters.AddWithValue("@e", p.Email);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    p.IdPropietario = Convert.ToInt32(cmd.LastInsertedId);
                    return p.IdPropietario;
                }
            }
        }

        public int Baja(int id)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                string sql = "DELETE FROM propietarios WHERE IdPropietario = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    res = cmd.ExecuteNonQuery();
                }
            }
            return res;
        }

        public int Modificar(Propietario p)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                string sql = @"UPDATE Propietario 
                    SET Nombre = @n, 
                    Apellido = @a, 
                    Telefono = @t, 
                    Email = @e 
                    WHERE IdPropietario = @id;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.IdPropietario);
                    cmd.Parameters.AddWithValue("@n", p.Nombre);
                    cmd.Parameters.AddWithValue("@a", p.Apellido);
                    cmd.Parameters.AddWithValue("@t", p.Telefono);
                    cmd.Parameters.AddWithValue("@e", p.Email);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Propietario> ObtenerTodos()
        {
            var lista = new List<Propietario>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM propietarios";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new Propietario
                        {
                            IdPropietario = Convert.ToInt32(reader["IdPropietario"]),
                            Nombre = reader["Nombre"].ToString() ?? "",
                            Apellido = reader["Apellido"].ToString() ?? "",
                            Telefono = reader["Telefono"].ToString() ?? "",
                            Email = reader["Email"].ToString() ?? ""
                        });
                    }
                }
                return lista;
            }
        }

        public IList<Propietario> ObtenerLista(int pagNro = 1, int tamPagina = 10)
        {
            IList<Propietario> res = new List<Propietario>();


            int offset = (pagNro - 1) * tamPagina;

            using (var conn = new MySqlConnection(connectionString))
            {

                string sql = @"
            SELECT IdPropietario, Nombre, Apellido, Telefono, Email
            FROM Propietarios
            ORDER BY IdPropietario
            LIMIT @tamPagina OFFSET @offset;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tamPagina", tamPagina);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Propietario p = new Propietario
                            {
                                IdPropietario = Convert.ToInt32(reader[nameof(Propietario.IdPropietario)]),
                                Nombre = reader[nameof(Propietario.Nombre)]?.ToString() ?? "",
                                Apellido = reader[nameof(Propietario.Apellido)]?.ToString() ?? "",
                                //Dni = reader.GetString(nameof(Propietario.Dni)), AGREGAR DNI??? 
                                Telefono = reader[nameof(Propietario.Telefono)]?.ToString() ?? "",
                                Email = reader[nameof(Propietario.Email)]?.ToString() ?? ""
                            };
                            res.Add(p);
                        }
                    }
                }
            }
            return res;
        }

        public Propietario? ObtenerPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IList<Propietario> BuscarPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public int ObtenerCantidad => throw new NotImplementedException();

        public Propietario? ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}