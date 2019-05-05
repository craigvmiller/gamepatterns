using System.Collections.Generic;
using GamePatterns.Commands;
using GamePatterns.Modules;
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
            var graphics = new GraphicsModule()
            {
                BaseColor = Color.White,
                Position = new Vector2(0, 0),
                CurrentSprite = new Rectangle(0, 0, 32, 32),
                SpriteMap = new SpriteMap()
                {
                    Texture = contentStore.Get<Texture2D>("player"),
                    Sprites = new Sprite[] { new Sprite() { Rectangle = new Rectangle(0, 0, 32, 32) } }
                }
            };

            var movement = new MovementModule()
            {
                Position = new Vector2(0, 0)
            };

            movement.OnMove += graphics.OnPositionChanged;
            movement.OnRevert += graphics.OnPositionChanged;

            Objects = new List<IGameObject>()
            {
                new BaseGameObject(graphics, movement)
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
