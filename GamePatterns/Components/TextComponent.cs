using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GamePatterns.Components
{
    public interface ITextComponent : IGameObjectComponent
    {
        IList<GameText> Strings { get; set; }
        SpriteFont Font { get; }
        Color Color { get; set; }
    }

    public class TextComponent : ITextComponent
    {
        public IList<GameText> Strings { get; set; }
        public SpriteFont Font { get; private set; }
        public Color Color { get; set; }

        public TextComponent(SpriteFont font, Color color)
        {
            Font = font;
            Color = color;
            Strings = new List<GameText>();
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
