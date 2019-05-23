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
        private IGameObjectFactory _factory;
        private ICamera _camera;

        public bool Completed { get; set; }

        public ExploringState(ContentManager content)
        {
            _factory = new GameObjectFactory();
            _camera = new Camera(new Rectangle(300, 200, 200, 200), 2);

            SpriteMap characterSpriteMap = new SpriteMap(0, content.Load<Texture2D>("character"));
            SpriteMap worldSpriteMap = new SpriteMap(1, content.Load<Texture2D>("world"));

            _objects = new List<IGameObject>()
            {
                _factory.GetDecoration(worldSpriteMap, new Vector2(200, 200)),
                _factory.GetCharacter(characterSpriteMap, new Vector2(100, 100)),
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
            var player = _objects.SingleOrDefault(o => o.Has<MovementModule>());
            spriteBatch.Begin(transformMatrix: _camera.GetOffset(player));
            foreach (IGameObject obj in _objects.Where(o => o.Has<GraphicModule>()))
            {
                var graphics = obj.Get<GraphicModule>();
                graphics.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
