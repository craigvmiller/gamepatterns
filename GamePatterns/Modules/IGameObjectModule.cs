using Microsoft.Xna.Framework;

namespace GamePatterns.Modules
{
    public interface IGameObjectModule
    {
        void Update(GameTime gameTime);
        void HandleInput();
    }

    public class MovementModule : IGameObjectModule
    {
        public void HandleInput()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
