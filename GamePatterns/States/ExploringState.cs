using System.Collections.Generic;
using System.Linq;
using GamePatterns.Commands;
using GamePatterns.Modules;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePatterns.States
{
    public class ExploringState : IGameState
    {
        private IEnumerable<IGameObject> _objects;

        public bool Completed { get; set; }

        public ExploringState(IContentStore contentStore)
        {
            _objects = new List<IGameObject>()
            {
                new Tile(1, contentStore.Get<Texture2D>("world"), new Vector2(100, 100)),
                new Player(0, contentStore.Get<Texture2D>("player"), new Vector2(10, 10))
            };
        }

        public void HandleInputCommands(IEnumerable<IGameCommand> commands)
        {
            foreach (IGameObject obj in _objects)
            {
                foreach (IGameCommand command in commands)
                {
                    command.Execute(obj);
                }
            }
        }

        public void Wake()
        {
        }

        public void Sleep()
        {
        }

        public void Update(GameTime gameTime)
        {
            CollisionDetector.CheckForCollisions(_objects);

            foreach (IGameObject obj in _objects)
            {
                obj.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in _objects.Where(o => o.Has<GraphicsModule>()))
            {
                var graphics = obj.Get<GraphicsModule>();
                graphics.Draw(spriteBatch);
            }
        }
    }
}
