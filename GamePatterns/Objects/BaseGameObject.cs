using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class BaseGameObject : IGameObject
    {
        public IEnumerable<IGameObjectModule> Modules { get; set; }

        public BaseGameObject()
        {
            Modules = new List<IGameObjectModule>();
        }

        public BaseGameObject(IEnumerable<IGameObjectModule> modules)
        {
            Modules = modules;
        }

        public BaseGameObject(params IGameObjectModule[] modules)
        {
            Modules = modules;
        }

        public void Update(GameTime gameTime)
        {
            foreach (IGameObjectModule module in Modules)
            {
                module.Update(gameTime);
            }
        }
    }

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
            Modules = new List<IGameObjectModule>() { graphics };
        }
    }

    public class Player : BaseGameObject
    {
        public Player()
        {
        }

        public Player(int spriteMapId, Texture2D texture, Vector2 initialPosition)
        {
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

            movement.OnMove += graphics.OnPositionChanged;
            movement.OnRevert += graphics.OnPositionChanged;

            Modules = new List<IGameObjectModule>() { graphics, movement };
        }
    }
}
