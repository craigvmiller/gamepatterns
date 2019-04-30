using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public class SpriteMap
    {
        public Texture2D Texture { get; set; }
        public IEnumerable<Sprite> Sprites { get; set; }
    }
}
