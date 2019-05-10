using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public class MovementModule : IGameObjectModule
    {
        private Vector2 _totalMovement;
        private int _baseSpeed;

        public Vector2 Position { get; set; }
        public EventHandler<MovementEventArgs> OnMove { get; set; }
        public EventHandler<MovementEventArgs> OnRevert { get; set; }
        public int Speed { get; set; }

        public MovementModule()
        {
            _baseSpeed = 2;
            Speed = _baseSpeed;
        }

        public void Move(Direction direction, Vector2 movementVector)
        {
            _totalMovement += movementVector * Speed;
            Position += movementVector * Speed;
            if (OnMove != null) OnMove.Invoke(this, new MovementEventArgs(Position));
        }

        public void Update(GameTime gameTime)
        {
            _totalMovement = new Vector2(0, 0);
        }

        public void OnCollision(object sender, CollisionEventArgs e)
        {
            if (e.CollisionType == CollisionType.Wall)
            {
                Position -= _totalMovement;
                _totalMovement = new Vector2(0, 0);
                if (OnRevert != null) OnRevert.Invoke(this, new MovementEventArgs(Position));
            }
        }
    }
}
