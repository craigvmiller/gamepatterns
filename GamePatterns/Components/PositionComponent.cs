using GamePatterns.Messages;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Components
{
    public interface IPositionComponent : IGameObjectComponent
    {
        Vector2 Position { get; set; }
        Vector2 PreviousPosition { get; }
        Action<PositionMessage> OnPositionChanged { get; set; }
    }

    public class PositionComponent : IPositionComponent
    {
        private Vector2 _previousPosition;
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _previousPosition = _position;
                _position = value;
                if (OnPositionChanged != null)
                {
                    OnPositionChanged.Invoke(new PositionMessage(_position));
                }
            }
        }
        public Vector2 PreviousPosition { get => _previousPosition; }
        public Action<PositionMessage> OnPositionChanged { get; set; }

        public PositionComponent()
        {
        }

        public PositionComponent(Vector2 initialPos)
        {
            Position = initialPos;
            _previousPosition = initialPos;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
