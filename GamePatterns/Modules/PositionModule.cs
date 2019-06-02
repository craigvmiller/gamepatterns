using GamePatterns.Messages;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface IPositionModule : IGameObjectModule
    {
        Action<PositionMessage> OnPositionChanged { get; set; }
        void PositionRequested(PositionMessage message);
        void Move(MovementMessage message);
    }

    public class PositionModule : IPositionModule
    {
        public Vector2 Position { get; private set; }
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
            Position = message.Position;
            if (OnPositionChanged != null) OnPositionChanged.Invoke(new PositionMessage(Position));
        }

        public void PositionRequested(PositionMessage message)
        {
            message.Position = Position;
        }
    }
}
