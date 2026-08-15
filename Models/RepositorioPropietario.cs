using System; 
using System.Data; 
using MySql.Data.MySqlClient;  


namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;

public class RepositorioPropietario
{
    private string connectionString = "DATOS DE LA CONEXION";//faltan

  
    public List<Propietario> ObtenerTodos()
    {
        var lista = new List<Propietario>();

        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM propietarios", conn);
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

    public int Alta(Propietario p)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            string sql = "INSERT INTO propietario (Nombre, Apellido, Telefono, Email) VALUES (@n, @a, @t, @e)";
            var cmd = new MySqlCommand(sql, conn);
            
            cmd.Parameters.AddWithValue("@n", p.Nombre);
            cmd.Parameters.AddWithValue("@a", p.Apellido);
            cmd.Parameters.AddWithValue("@t", p.Telefono);
            cmd.Parameters.AddWithValue("@e", p.Email);

            conn.Open();
            return cmd.ExecuteNonQuery(); 
        }
    }

    public int ModificarPropietario(Propietario p)
{
    using (var conn = new MySqlConnection(connectionString))
    {
        string sql = @"UPDATE Propietario 
                       SET Nombre = @n, 
                           Apellido = @a, 
                           Telefono = @t, 
                           Email = @e 
                       WHERE IdPropietario = @id;";

        var cmd = new MySqlCommand(sql, conn);
        
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