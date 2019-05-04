using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GamePatterns.Modules
{
    public class GraphicsModule : IGameObjectModule
    {
        public SpriteMap SpriteMap { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle CurrentSprite { get; set; }
        public Color BaseColor { get; set; }

        public EventHandler<DrawEventArgs> OnDraw { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteMap.Texture, Position, CurrentSprite, BaseColor);
            if (OnDraw != null) OnDraw.Invoke(this, new DrawEventArgs());
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
