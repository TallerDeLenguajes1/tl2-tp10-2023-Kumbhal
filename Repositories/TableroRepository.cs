using System.Data.SQLite;
using tl2_tp10_2023_Kumbhal.Models;

public interface ITableroRepository{
    public void Create(Tablero tableroNuevo);
    public void Update(int id, Tablero tableroModificar);
    public Tablero GetById(int id);
    public List<Tablero> GetAll();
    public List<Tablero> GetAllById(int idUsuario);
    public void Remove(int id);
}
namespace tl2_tp10_2023_Kumbhal.Repositories{
    public class TableroRepository : ITableroRepository{
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        public void Create(Tablero tableroNuevo){
            var query = $"INSERT INTO Tablero (id_usuario_propietario,nombre,descripcion) VALUES (@usuarioPropietario, @nombre, @descripcion);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                connection.Open();
                var command = new SQLiteCommand(query,connection);
                command.Parameters.Add(new SQLiteParameter("@usuarioPropietario", tableroNuevo.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tableroNuevo.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tableroNuevo.Descripcion));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(int id, Tablero tableroModificar){
            var query = $"UPDATE Tablero SET id_usuario_propietario = @usuarioPropietario, nombre = @nombre, descripcion = @descripcion WHERE id = @id;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                connection.Open();
                var command = new SQLiteCommand(query,connection);
                command.Parameters.Add(new SQLiteParameter("@id",id));
                command.Parameters.Add(new SQLiteParameter("@usuarioPropietario", tableroModificar.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tableroModificar.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tableroModificar.Descripcion));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Tablero GetById(int id){
            var query = $"SELECT * FROM Tablero WHERE id = @id;";
            Tablero tablero = new Tablero();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                connection.Open();
                var command = new SQLiteCommand(query,connection);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        tablero.Id = id;
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tablero.Nombre = reader["nombre"].ToString();
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tablero;
        }
        public List<Tablero> GetAll(){
            var query = $"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                SQLiteCommand command = new SQLiteCommand(query,connection);
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tableros;
        }
        public List<Tablero> GetAllById(int idUsuario){
            var query = $"SELECT * FROM Tablero WHERE id_usuario_propietario = @idUsuario;";
            List<Tablero> tableros = new List<Tablero>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tableros;
        }
        public void Remove(int id){
             using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                string query = @"DELETE FROM Tablero WHERE id = @id;";
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
        }
    }
}
}