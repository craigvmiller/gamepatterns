using GamePatterns.Commands;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.States
{
    public interface IGameState
    {
        IEnumerable<IGameObject> Objects { get; set; }
        bool Completed { get; set; }

        void Wake();
        void Sleep();
        void Update(GameTime gameTime);
        void HandleInputCommands(IEnumerable<IGameCommand> commands);
    }
}
