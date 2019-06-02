using GamePatterns.Messages;
using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using PubSub.Extension;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class World : GameObject
    {
        private List<Sprite> _sprites;

        public World(SpriteMap spriteMap)
        {
            _sprites = new List<Sprite>();

            var position = new PositionModule();
            var graphics = new GraphicModule(spriteMap);

            graphics.RequestPosition += position.PositionRequested;
                       
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _sprites.Add(new Sprite() { Offset = new Vector2(j * 32, i * 32), Rectangle = new Rectangle(0, 0, 32, 32) });
                }
            }

            Modules = new List<IGameObjectModule>() { graphics, position };

            this.Subscribe<CameraMovedMessage>(m =>
            {
                var g = Get<GraphicModule>();
                g.CurrentSprites.Clear();
                foreach (var sprite in _sprites)
                {
                    var rect = new Rectangle((int)sprite.Offset.X, (int)sprite.Offset.Y, sprite.Rectangle.Width, sprite.Rectangle.Height);
                    g.CurrentSprites.Add(sprite);
                }
            });
        }
    }
}
