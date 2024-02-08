using System.Data.SQLite;
using tl2_tp10_2023_Kumbhal.Models;

public interface ILogueoRepository{
    public bool Login(string nombre, string contrasenia);
}
namespace tl2_tp10_2023_Kumbhal.Repositories{
    public class LogueoRepository : ILogueoRepository{
        private string? cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        public bool Login (string nombre, string contrasenia){
            var query = $"SELECT * FROM Usuario WHERE nombre = @nombre, contrasenia = @contrasenia;";
            Usuario usuario = new Usuario();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                var command = new SQLiteCommand(query,connection);
                connection.Open();
                command.Parameters.Add(new SQLiteParameter("@nombre", nombre));
                command.Parameters.Add(new SQLiteParameter("@contrasenia", contrasenia));
                connection.Close();
            }
            return true;
        }
    }
}