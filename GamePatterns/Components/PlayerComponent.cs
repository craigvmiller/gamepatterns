using Microsoft.Xna.Framework;

namespace GamePatterns.Components
{
    public interface IPlayerComponent : IGameObjectComponent
    {
    }

    public class PlayerComponent : IPlayerComponent
    {
        public void Update(GameTime gameTime)
        {
        }
    }
}
