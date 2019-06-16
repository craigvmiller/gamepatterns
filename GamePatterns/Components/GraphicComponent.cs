using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Components
{
    public interface IGraphicComponent : IGameObjectComponent
    {
        IList<Sprite> Sprites { get; }
        Texture2D Texture { get; }
        Color BaseColor { get; }
    }

    public class GraphicComponent : IGraphicComponent
    {
        SpriteMap _spriteMap;

        public IList<Sprite> Sprites { get; private set; }
        public Texture2D Texture { get => _spriteMap.Texture; }
        public Color BaseColor { get; private set; }

        public GraphicComponent(SpriteMap spriteMap, Color color)
        {
            _spriteMap = spriteMap;

            BaseColor = color;
            Sprites = new List<Sprite>() { spriteMap.Sprites.First() };
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
