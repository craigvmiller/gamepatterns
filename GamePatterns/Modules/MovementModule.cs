using GamePatterns.Commands;
using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public class MovementModule : IGameObjectModule
    {
        private Vector2 _totalMovement;

        public Vector2 Position { get; set; }
        public EventHandler<MovementEventArgs> OnMove { get; set; }
        public EventHandler<MovementEventArgs> OnRevert { get; set; }

        public void Move(Direction direction, Vector2 movementVector)
        {
            Position += movementVector;
            _totalMovement += movementVector;
            if (OnMove != null) OnMove.Invoke(this, new MovementEventArgs(Position));
        }

        public void Update(GameTime gameTime)
        {
            _totalMovement = new Vector2(0, 0);
        }

        public void Revert()
        {
            Position -= _totalMovement;
            _totalMovement = new Vector2(0, 0);
            if (OnRevert != null) OnRevert.Invoke(this, new MovementEventArgs(Position));
        }
    }
}
