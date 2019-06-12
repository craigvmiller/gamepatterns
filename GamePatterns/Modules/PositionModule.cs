using GamePatterns.Messages;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface IPositionModule : IGameObjectModule
    {
        Vector2 Position { get; set; }
        Vector2 PreviousPosition { get; set; }
        Action<PositionMessage> OnPositionChanged { get; set; }
        void PositionRequested(PositionMessage message);
        void Move(MovementMessage message);
        void Reposition(Vector2 position);
    }

    public class PositionModule : IPositionModule
    {
        private Vector2 _previousPosition;
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                if (OnPositionChanged != null)
                {
                    OnPositionChanged.Invoke(new PositionMessage(_position));
                }
            }
        }
        public Vector2 PreviousPosition { get => _previousPosition; set => _previousPosition = value; }
        public Action<PositionMessage> OnPositionChanged { get; set; }

        public PositionModule()
        {
        }

        public PositionModule(Vector2 initialPos)
        {
            Position = initialPos;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Move(MovementMessage message)
        {
            PreviousPosition = Position;
            Position = message.Position;
        }

        public void PositionRequested(PositionMessage message)
        {
            message.Position = Position;
        }

        public void Reposition(Vector2 position)
        {
            PreviousPosition = Position;
            Position = position;
        }
    }
}
