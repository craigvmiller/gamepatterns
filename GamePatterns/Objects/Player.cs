using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class Player : GameObject
    {
        public Player()
        {
        }

        public Player(int spriteMapId, Texture2D texture, Vector2 initialPosition)
        {
            var position = new PositionModule();

            var movement = new MovementModule()
            {
                Position = initialPosition
            };

            var spriteMap = new SpriteMap(spriteMapId, texture);
            var rect = spriteMap.Sprites.FirstOrDefault().Rectangle;
            var graphics = new GraphicsModule()
            {
                BaseColor = Color.White,
                CurrentSprite = rect,
                Layer = GraphicsLayer.Player,
                Position = initialPosition,
                SpriteMap = spriteMap
            };

            var collide = new CollideModule()
            {
                HitBox = rect,
                Position = initialPosition,
                CollisionType = CollisionType.Wall
            };

            movement.OnMove += graphics.OnPositionChanged;
            movement.OnRevert += graphics.OnPositionChanged;
            movement.OnMove += collide.OnPositionChanged;
            movement.OnRevert += collide.OnPositionChanged;

            collide.OnCollision += movement.OnCollision;

            Modules = new List<IGameObjectModule>() { collide, graphics, movement };
        }
    }
}
