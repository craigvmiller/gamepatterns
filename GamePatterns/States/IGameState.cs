using GamePatterns.Commands;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GamePatterns.States
{
    public interface IGameState
    {
        bool Completed { get; set; }

        void Wake();
        void Sleep();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void HandleInputCommands(IEnumerable<IGameCommand> commands);
    }
}
