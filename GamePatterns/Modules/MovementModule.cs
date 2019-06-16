using Microsoft.Xna.Framework;

namespace GamePatterns.Components
{
    public interface IMovementComponent : IGameObjectComponent
    {
        float MovementSpeed { get; }
    }

    public class MovementComponent : IMovementComponent
    {
        public float MovementSpeed { get; private set; }

        public MovementComponent(float speed)
        {
            MovementSpeed = speed;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
