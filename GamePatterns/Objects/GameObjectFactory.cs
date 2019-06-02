using GamePatterns.Modules;
using Microsoft.Xna.Framework;

namespace GamePatterns.Objects
{
    public interface IGameObjectFactory
    {
        IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetDecoration(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetProp(SpriteMap spriteMap, Vector2 initialPos);
    }

    public class GameObjectFactory : IGameObjectFactory
    {
        public IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos)
        {
            var collide = new CollideModule();
            var graphics = new GraphicModule(spriteMap) { DrawIndex = 1 };
            var movement = new MovementModule();
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.PositionRequested;

            movement.BeforeMove += collide.CheckMovement;
            movement.RequestPosition += position.PositionRequested;
            movement.OnMove += position.Move;
            
            return new GameObject(collide, graphics, movement, position);
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
