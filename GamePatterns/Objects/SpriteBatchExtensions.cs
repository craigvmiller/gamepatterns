using GamePatterns.Components;
using Microsoft.Xna.Framework.Graphics;

namespace GamePatterns.Objects
{
    public static class SpriteBatchExtensions
    {
        public static void Draw(this SpriteBatch spriteBatch, IGameObject gameObject)
        {
            if (gameObject.Has<IPositionComponent>() && gameObject.Has<IGraphicComponent>())
            {
                IPositionComponent position = gameObject.Get<IPositionComponent>();
                IGraphicComponent graphic = gameObject.Get<IGraphicComponent>();

                foreach (Sprite sprite in graphic.Sprites)
                {
                    spriteBatch.Draw(graphic.Texture, position.Position + sprite.Offset, sprite.Rectangle, graphic.BaseColor);
                }
            }
        }
    }
}
