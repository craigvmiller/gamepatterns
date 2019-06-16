using GamePatterns.Components;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;

namespace GamePatterns.Commands
{
    public class MoveCommand : IGameCommand
    {
        private Direction _direction;
        private Vector2 _movementVector;

        public MoveCommand(Direction direction, Vector2 movementVector)
        {
            _direction = direction;
            _movementVector = movementVector;
        }

        public void Execute(IGameObject gameObject)
        {
            IPositionComponent position = gameObject.Get<IPositionComponent>();
            IMovementComponent movement = gameObject.Get<IMovementComponent>();

            if (position != null && movement != null)
            {
                position.Position += _movementVector * movement.MovementSpeed;
            }
        }
    }
}
