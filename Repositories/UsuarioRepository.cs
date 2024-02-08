using System.Data.SQLite;
using tl2_tp10_2023_Kumbhal.Models;

public interface IUsuarioRepository{
    public void Create (Usuario usuario);
    public void Update(int id, Usuario usuarioModificar);
    public List<Usuario> GetAll();
    public Usuario GetById(int id);
    public void Remove (int id);
}

namespace tl2_tp10_2023_Kumbhal.Repositories{
    public class  UsuarioRepository : IUsuarioRepository{
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        public void Create(Usuario usuario){
            var query = $"INSERT INTO Usuario (nombre_de_usuario, contrasenia, rol_usuario) VALUES (@nombre, @contrasenia, @rol);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre", usuario.NombreDeUsuario));
                command.Parameters.Add(new SQLiteParameter("@contrasenia", usuario.Contrasenia));
                command.Parameters.Add(new SQLiteParameter("@rol", 2));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(int id, Usuario usuarioModificar){
            var query = $"UPDATE Usuario SET nombre_de_usuario = @nombre, contrasenia = @contrasenia, rol_usuario = @rol WHERE id = @idUsuario;";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre", usuarioModificar.NombreDeUsuario));
                command.Parameters.Add(new SQLiteParameter("@idUsuario", id));
                command.Parameters.Add(new SQLiteParameter("@contrasenia", usuarioModificar.Contrasenia));
                command.Parameters.Add(new SQLiteParameter("@rol",(int)usuarioModificar.RolUsuario));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Usuario> GetAll(){
            var query = $"SELECT * FROM Usuario;";
            List<Usuario> listaUsuarios = new List<Usuario>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(reader["id"]);
                            usuario.Contrasenia = reader["contrasenia"].ToString();
                            usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                            usuario.RolUsuario = (Roles)Convert.ToInt32(reader["rol_usuario"]);
                        listaUsuarios.Add(usuario);
                    }
                connection.Close();
                }
            }
            return listaUsuarios;
        }
        public Usuario GetById(int id){
            var query = $"SELECT * FROM Usuario WHERE id = @id;";
            Usuario usuario = new Usuario();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                        usuario.Contrasenia = reader["contrasenia"].ToString();
                        usuario.RolUsuario = (Roles)Convert.ToInt32(reader["rol_usuario"]);
                    }
                }
                connection.Close();
            }
            return usuario;
        }
        public void Remove (int id){
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                var query = $"DELETE FROM Usuario WHERE id = @idUsuario;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", id));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}