using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace GamePatterns.Database
{
    public class DatabaseContext
    {
        private const string _sqlFile = @"C:\Users\craig\source\repos\GamePatterns\GamePatterns\Database\init.sql";
        private const string _connectionString = @"Data Source=gamepatterns.sqlite;Version=3;";
        private SQLiteConnection _connection;

        public DatabaseContext()
        {
            _connection = new SQLiteConnection(_connectionString);
        }

        public IEnumerable<Sprite> GetSpriteMapSprites(int id)
        {
            _connection.Open();
            string sql = string.Format(
                "select s.id, s.[name], s.x, s.y, s.width, s.height " +
                "from spritemap_sprite s " +
                "join spritemap sm on s.spritemap_id = sm.id where sm.id = {0}", id);
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int spriteId = int.Parse(reader["id"].ToString());
                    int x = int.Parse(reader["x"].ToString());
                    int y = int.Parse(reader["y"].ToString());
                    int width = int.Parse(reader["width"].ToString());
                    int height = int.Parse(reader["height"].ToString());

                    yield return new Sprite()
                    {
                        Id = spriteId,
                        Rectangle = new Rectangle(x, y, width, height)
                    };
                }
            }
            _connection.Close();
        }

        //public IEnumerable<DialogueTree> GetDialogueTree(int id)
        //{
        //    _connection.Open();
        //    string sql = string.Format(
        //        "select id, parent_id, [text], [sequence], requiredresponse_id " +
        //        "from dialogue d " +
        //        "where d.tree_id = {0}", id);
        //    SQLiteCommand cmd = _connection.CreateCommand();
        //    cmd.CommandType = System.Data.CommandType.Text;
        //    cmd.CommandText = sql;
        //    using (SQLiteDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            DialogueElement element = new DialogueElement();
        //        }
        //    }
        //}

        public void Init()
        {
            SQLiteConnection.CreateFile("gamepatterns.sqlite");
            _connection = new SQLiteConnection(_connectionString);
            _connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(_connection);

            using (StreamReader reader = new StreamReader(_sqlFile))
            {
                cmd.CommandText += reader.ReadToEnd();
            }

            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
