using System.Collections.Generic;
using GamePatterns.Commands;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GamePatterns.States
{
    public class ExploringState : IGameState
    {
        private ICollisionHandler _collisionHandler;
        private IEnumerable<IGameObject> _objects;
        private IGameObjectFactory _factory;
        private ICamera _camera;

        public bool Completed { get; set; }

        public ExploringState(GraphicsDeviceManager graphicsDevice, ContentManager content, ICollisionHandler collisionHandler, IGameObjectFactory factory)
        {
            _collisionHandler = collisionHandler;
            _factory = factory;
            
            SpriteMap characterSpriteMap = new SpriteMap(content.Load<Texture2D>("character"));
            characterSpriteMap.Load(0);
            var character = _factory.GetPlayerCharacter(characterSpriteMap, new Vector2(0, 0), new Rectangle(0, 0, 32, 32), CollisionType.Wall);

            _camera = new Camera(new Vector3(graphicsDevice.PreferredBackBufferWidth / 2, graphicsDevice.PreferredBackBufferHeight / 2, 0));
            _camera.Follow(character);

            SpriteMap worldSpriteMap = new SpriteMap(content.Load<Texture2D>("world"));
            worldSpriteMap.Load(1);
            var world = _factory.GetWorld(worldSpriteMap, new Vector2(0, 0));
            var wall = _factory.GetProp(worldSpriteMap, new Vector2(400, 0), new Rectangle(0, 0, 32, 32), CollisionType.Wall);

            var objects = new List<IGameObject>();
            objects.Add(world);
            objects.Add(wall);
            objects.Add(character);
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
            foreach (IGameObject obj in _objects)
            {
                obj.Update(gameTime);
            }
            _collisionHandler.FixCollisions(_objects);
            _camera.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _camera.Offset);
            foreach (IGameObject obj in _objects)
            {
                spriteBatch.Draw(obj);
            }
            spriteBatch.End();
        }
    }
}
