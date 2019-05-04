using System;
using System.Collections.Generic;
using GamePatterns.Commands;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;

namespace GamePatterns.States
{
    public class ExploringState : IGameState
    {
        public IEnumerable<IGameObject> Objects { get; set; }
        public bool Completed { get; set; }

        public ExploringState(IContentStore contentStore)
        {
            Objects = new List<IGameObject>()
            {
                new Player()
            };
        }

        public void HandleInputCommands(IEnumerable<IGameCommand> commands)
        {
        }

        public void Sleep()
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Wake()
        {
        }
    }
}
