using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface IMovementModule : IGameObjectModule
    {
        EventHandler<PositionEventArgs> BeforeMove { get; set; }
        EventHandler<PositionEventArgs> OnMove { get; set; }
    }

    public class MovementModule : IGameObjectModule
    {
        private Vector2 _position;
        private int _speed;

        public EventHandler<PositionEventArgs> OnMove { get; set; }
        public EventHandler<PositionEventArgs> BeforeMove { get; set; }
        public EventHandler<PositionEventArgs> RequestPosition { get; set; }

        public MovementModule()
        {
            _speed = 2;
        }

        public void Move(Direction direction, Vector2 movementVector)
        {
            PositionEventArgs args = new PositionEventArgs(_position);
            if (RequestPosition != null)
            {
                RequestPosition.Invoke(this, args);
                _position = args.Position;
            }

            Vector2 pos = _position + (movementVector * _speed);
            args = new PositionEventArgs(pos);
            if (BeforeMove != null) BeforeMove.Invoke(this, args);

            if (!args.Cancel)
            {
                _position = pos;
                if (OnMove != null) OnMove.Invoke(this, new PositionEventArgs(_position));
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
