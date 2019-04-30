using System.Data.SQLite;

namespace GamePatterns.Database
{
    public class DatabaseContext
    {
        private const string connectionString = @"Data Source=gamepatterns.sqlite;Version=3;";
        private SQLiteConnection connection;

        public DatabaseContext()
        {
            connection = new SQLiteConnection(connectionString);
        }
    }
}
