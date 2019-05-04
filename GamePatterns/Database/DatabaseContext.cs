using System.Data.SQLite;

namespace GamePatterns.Database
{
    public class DatabaseContext
    {
        private const string _connectionString = @"Data Source=gamepatterns.sqlite;Version=3;";
        private SQLiteConnection _connection;

        public DatabaseContext()
        {
            _connection = new SQLiteConnection(_connectionString);
        }
    }
}
