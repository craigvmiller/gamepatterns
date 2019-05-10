using GamePatterns.Modules;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System.Linq;

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
            var module = gameObject.GetModule<MovementModule>();
            if (module != null)
            {
                module.Move(_direction, _movementVector);
            }
        }
    }
}
