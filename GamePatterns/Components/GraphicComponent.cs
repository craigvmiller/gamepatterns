using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Components
{
    public interface IGraphicComponent : IGameObjectComponent
    {
        IList<Sprite> Sprites { get; set; }
        Texture2D Texture { get; }
        Color BaseColor { get; set; }
    }

    public class GraphicComponent : IGraphicComponent
    {
        SpriteMap _spriteMap;

        public IList<Sprite> Sprites { get; set; }
        public Texture2D Texture { get => _spriteMap.Texture; }
        public Color BaseColor { get; set; }

        public GraphicComponent(SpriteMap spriteMap, Color color)
        {
            _spriteMap = spriteMap;

            BaseColor = color;
            Sprites = new List<Sprite>();
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
