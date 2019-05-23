﻿using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Modules
{
    public interface IGraphicModule : IGameObjectModule
    {
        EventHandler<PositionEventArgs> RequestPosition { get; set; }
        Rectangle Bounds { get; }
        void Draw(SpriteBatch spriteBatch);
    }

    public class GraphicModule : IGraphicModule
    {
        private SpriteMap _spriteMap;
        private List<Sprite> _currentSprites;
        private Vector2 _position;
        private Color _baseColor;

        public Rectangle Bounds { get; private set; }
        public EventHandler<PositionEventArgs> RequestPosition { get; set; }

        public GraphicModule(SpriteMap spriteMap)
        {
            _spriteMap = spriteMap;
            _currentSprites = new List<Sprite>();
            _currentSprites.Add(_spriteMap.Sprites.First());
            _baseColor = Color.White;
        }

        private void Recalculate()
        {
            if (RequestPosition != null)
            {
                PositionEventArgs args = new PositionEventArgs(_position);
                RequestPosition.Invoke(this, args);
                _position = args.Position;
            }

            Rectangle bounds = new Rectangle();
            foreach (Sprite sprite in _currentSprites)
            {
                Rectangle shape = new Rectangle((int)sprite.Offset.X, (int)sprite.Offset.Y, sprite.Rectangle.Width, sprite.Rectangle.Height);
                if (shape.Left < bounds.Left)
                {
                    bounds.X = shape.X;
                }

                if (shape.Right > bounds.Right)
                {
                    bounds.Width = shape.Width;
                }

                if (shape.Top < bounds.Top)
                {
                    bounds.Y = shape.Y;
                }

                if (shape.Bottom > bounds.Bottom)
                {
                    bounds.Height = shape.Height;
                }
            }
            bounds.X += (int)_position.X;
            bounds.Y += (int)_position.Y;
            Bounds = bounds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Recalculate();

            foreach (Sprite sprite in _currentSprites)
            {
                spriteBatch.Draw(_spriteMap.Texture, _position + sprite.Offset, sprite.Rectangle, _baseColor);
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}