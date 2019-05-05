using GamePatterns.Database;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public class SpriteMap
    {
        public int Id { get; set; }
        public Texture2D Texture { get; set; }
        public IEnumerable<Sprite> Sprites { get; set; }

        public SpriteMap()
        {
        }

        public SpriteMap(int id, Texture2D texture)
        {
            Id = id;
            Texture = texture;

            var db = new DatabaseContext();
            Sprites = db.GetSpriteMapSprites(Id);
        }
    }
}
