using System.Collections.Generic;
using System.Linq;
using GamePatterns.Commands;
using GamePatterns.Modules;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GamePatterns.States
{
    public class ExploringState : IGameState
    {
        private IEnumerable<IGameObject> _objects;

        public bool Completed { get; set; }

        public ExploringState(ContentManager content)
        {
            GameObjectFactory factory = new GameObjectFactory();
            SpriteMap characterSpriteMap = new SpriteMap(0, content.Load<Texture2D>("character"));
            SpriteMap worldSpriteMap = new SpriteMap(1, content.Load<Texture2D>("world"));

            _objects = new List<IGameObject>()
            {
                factory.GetCharacter(characterSpriteMap, new Vector2(100, 100)),
                factory.GetCharacter(worldSpriteMap, new Vector2(200, 200)),
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
            foreach (IGameObject obj in _objects.Where(o => o.Has<GraphicModule>()))
            {
                var graphics = obj.Get<GraphicModule>();
                graphics.Draw(spriteBatch);
            }
        }
    }
}
