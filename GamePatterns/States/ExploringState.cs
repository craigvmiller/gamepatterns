using System.Collections.Generic;
using GamePatterns.Commands;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                new Tile(1, contentStore.Get<Texture2D>("world"), new Vector2(100, 100)),
                new Player(0, contentStore.Get<Texture2D>("player"), new Vector2(10, 10))
            };
        }

        public void HandleInputCommands(IEnumerable<IGameCommand> commands)
        {
            foreach (IGameObject obj in Objects)
            {
                foreach (IGameCommand command in commands)
                {
                    command.Execute(obj);
                }
            }
        }

        public void Sleep()
        {
        }

        public void Update(GameTime gameTime)
        {
            CollisionDetector.CheckForCollisions(Objects);

            foreach (IGameObject obj in Objects)
            {
                obj.Update(gameTime);
            }
        }

        public void Wake()
        {
        }
    }
}
