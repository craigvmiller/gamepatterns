using Microsoft.Xna.Framework;

namespace GamePatterns.States
{
    public interface IGameState
    {
        bool Completed { get; set; }

        void Wake();
        void Sleep();
        void Update(GameTime gameTime);
    }
}
