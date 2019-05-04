using GamePatterns.Modules;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System.Linq;

namespace GamePatterns.Commands
{
    public interface IGameCommand
    {
        void Execute(IGameObject gameObject);
    }

    public class SubmitCommand : IGameCommand
    {
        public void Execute(IGameObject gameObject)
        {
            if (gameObject.Modules.Any(m => m is InteractModule))
            {

            }
        }
    }

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
            var module = gameObject.Modules.SingleOrDefault(m => m is MovementModule) as MovementModule;
            if (module != null)
            {
                module.Move(_direction, _movementVector);
            }
        }
    }
}
