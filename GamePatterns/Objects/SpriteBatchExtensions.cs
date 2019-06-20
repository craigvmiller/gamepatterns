using GamePatterns.Components;
using Microsoft.Xna.Framework.Graphics;

namespace GamePatterns.Objects
{
    public static class SpriteBatchExtensions
    {
        public static void Draw(this SpriteBatch spriteBatch, IGameObject gameObject)
        {
            if (gameObject.Has<IPositionComponent>())
            {
                IPositionComponent position = gameObject.Get<IPositionComponent>();

                if (gameObject.Has<IGraphicComponent>())
                {
                    IGraphicComponent graphic = gameObject.Get<IGraphicComponent>();

                    foreach (Sprite sprite in graphic.Sprites)
                    {
                        spriteBatch.Draw(graphic.Texture, position.Position + sprite.Offset, sprite.Rectangle, graphic.BaseColor);
                    }
                }

                if (gameObject.Has<ITextComponent>())
                {
                    ITextComponent text = gameObject.Get<ITextComponent>();

                    foreach (GameText @string in text.Strings)
                    {
                        spriteBatch.DrawString(text.Font, @string.String, position.Position + @string.Offset, @string.Color);
                    }
                }
            }
        }
    }
}
