using GamePatterns.Messages;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface IMovementModule : IGameObjectModule
    {
        Action<MovementMessage> BeforeMove { get; set; }
        Action<MovementMessage> OnMove { get; set; }
    }

    public class MovementModule : IGameObjectModule
    {
        private Vector2 _position;
        private int _speed;

        public Action<MovementMessage> OnMove { get; set; }
        public Action<MovementMessage> BeforeMove { get; set; }
        public Action<PositionMessage> RequestPosition { get; set; }

        public MovementModule()
        {
            _speed = 2;
        }

        public void Move(Direction direction, Vector2 movementVector)
        {
            if (RequestPosition != null)
            {
                PositionMessage p = new PositionMessage(_position);
                RequestPosition.Invoke(p);
                _position = p.Position;
            }

            Vector2 pos = _position + (movementVector * _speed);
            MovementMessage m = new MovementMessage(pos);
            if (BeforeMove != null) BeforeMove.Invoke(m);

            if (!m.Cancel)
            {
                _position = pos;
                if (OnMove != null) OnMove.Invoke(m);
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
