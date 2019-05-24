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

        private WorldBuilder _world;

        public bool Completed { get; set; }

        public ExploringState(ContentManager content)
        {
            _factory = new GameObjectFactory();
            _camera = new Camera(new Rectangle(300, 200, 200, 200), 2);

            SpriteMap characterSpriteMap = new SpriteMap(content.Load<Texture2D>("character"));
            characterSpriteMap.Load(0);
            SpriteMap worldSpriteMap = new SpriteMap(content.Load<Texture2D>("world"));
            worldSpriteMap.Load(1);

            _world = new WorldBuilder(worldSpriteMap);

            var objects = new List<IGameObject>();
            objects.Add(_factory.GetCharacter(characterSpriteMap, new Vector2(100, 100)));
            objects.AddRange(_world.GetObjects());
            _objects = objects;
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
            foreach (IGameObject obj in _objects.Where(o => o.Has<GraphicModule>()).OrderBy(o => o.Get<GraphicModule>().DrawIndex))
            {
                var graphics = obj.Get<GraphicModule>();
                graphics.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
