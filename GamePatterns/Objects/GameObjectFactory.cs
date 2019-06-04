using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using PubSub.Extension;

namespace GamePatterns.Objects
{
    public interface IGameObjectFactory
    {
        IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetWorld(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetDecoration(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetProp(SpriteMap spriteMap, Vector2 initialPos);
    }

    public class GameObjectFactory : IGameObjectFactory
    {
        public IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos)
        {
            var collide = new CollideModule();
            var equipment = new EquipmentModule();
            var graphics = new GraphicModule(spriteMap) { DrawIndex = 1 };
            var movement = new MovementModule();
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.PositionRequested;

            movement.BeforeMove += collide.CheckMovement;
            movement.RequestPosition += position.PositionRequested;
            movement.OnMove += position.Move;
            
            return new GameObject(collide, equipment, graphics, movement, position);
        }

        public IGameObject GetWorld(SpriteMap spriteMap, Vector2 initialPos)
        {
            var position = new PositionModule(initialPos);
            var graphics = new GraphicModule(spriteMap);

            graphics.RequestPosition += position.PositionRequested;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    graphics.CurrentSprites.Add(new Sprite() { Offset = new Vector2(j * 32, i * 32), Rectangle = new Rectangle(0, 0, 32, 32) });
                }
            }

            return new GameObject(graphics, position);
        }

        public IGameObject GetDecoration(SpriteMap spriteMap, Vector2 initialPos)
        {
            var graphics = new GraphicModule(spriteMap);
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.PositionRequested;

            return new GameObject(graphics, position);
        }

        public IGameObject GetProp(SpriteMap spriteMap, Vector2 initialPos)
        {
            var collide = new CollideModule();
            var graphics = new GraphicModule(spriteMap);
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.PositionRequested;

            return new GameObject(collide, graphics, position);
        }
    }
}
