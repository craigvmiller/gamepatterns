using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class Tile : BaseGameObject
    {
        public Tile()
        {
        }

        public Tile(int spriteMapId, Texture2D texture, Vector2 initialPosition)
        {
            var spriteMap = new SpriteMap(spriteMapId, texture);
            var rect = spriteMap.Sprites.FirstOrDefault().Rectangle;
            var graphics = new GraphicsModule()
            {
                BaseColor = Color.White,
                CurrentSprite = rect,
                Layer = GraphicsLayer.Background,
                Position = initialPosition,
                SpriteMap = spriteMap
            };

            var collide = new CollideModule()
            {
                CollisionType = CollisionType.Wall,
                HitBox = rect,
                Position = initialPosition
            };

            Modules = new List<IGameObjectModule>() { graphics, collide };
        }
    }
}
