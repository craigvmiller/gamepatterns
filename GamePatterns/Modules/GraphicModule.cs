using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace GamePatterns.Modules
{
    public interface IGraphicModule : IGameObjectModule
    {
        EventHandler<PositionEventArgs> RequestPosition { get; set; }
        void Draw(SpriteBatch spriteBatch);
    }

    public class GraphicModule : IGraphicModule
    {
        private SpriteMap _spriteMap;
        private Rectangle _currentSprite;
        private Vector2 _position;
        private Color _baseColor;

        public EventHandler<PositionEventArgs> RequestPosition { get; set; }

        public GraphicModule()
        {
        }

        public GraphicModule(SpriteMap spriteMap)
        {
            _spriteMap = spriteMap;
            _currentSprite = _spriteMap.Sprites.First().Rectangle;
            _baseColor = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (RequestPosition != null)
            {
                PositionEventArgs args = new PositionEventArgs(_position);
                RequestPosition.Invoke(this, args);
                _position = args.Position;
            }

            spriteBatch.Draw(_spriteMap.Texture, _position, _currentSprite, _baseColor);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
