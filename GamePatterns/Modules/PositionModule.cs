using Microsoft.Xna.Framework;

namespace GamePatterns.Modules
{
    public class PositionModule : IGameObjectModule
    {
        public Vector2 Position { get; set; }

        public void Update(GameTime gameTime)
        {
        }
    }
}
