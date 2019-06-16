﻿using System.Collections.Generic;
using GamePatterns.Commands;
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
            
            SpriteMap characterSpriteMap = new SpriteMap(content.Load<Texture2D>("character"));
            characterSpriteMap.Load(0);
            var character = _factory.GetCharacter(characterSpriteMap, new Vector2(100, 100), new Rectangle(100, 100, 32, 32), CollisionType.Wall);

            _camera = new Camera(new Rectangle(100, 100, 600, 300), 2);
            _camera.Follow(character);

            SpriteMap worldSpriteMap = new SpriteMap(content.Load<Texture2D>("world"));
            worldSpriteMap.Load(1);
            var world = _factory.GetWorld(worldSpriteMap, new Vector2(0, 0));
            var wall = _factory.GetProp(worldSpriteMap, new Vector2(-100, -100), new Rectangle(-100, -100, 32, 32), CollisionType.Wall);

            var objects = new List<IGameObject>();
            objects.Add(character);
            objects.Add(world);
            objects.Add(wall);
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _camera.GetOffset());
            foreach (IGameObject obj in _objects)
            {
                spriteBatch.Draw(obj);
            }
            spriteBatch.End();
        }
    }
}
