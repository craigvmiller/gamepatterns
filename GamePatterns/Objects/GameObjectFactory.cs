using GamePatterns.Modules;
using Microsoft.Xna.Framework;

namespace GamePatterns.Objects
{
    public interface IGameObjectFactory
    {
    }

    public class GameObjectFactory : IGameObjectFactory
    {
        public IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos)
        {
            var collide = new CollideModule();
            var graphics = new GraphicModule(spriteMap);
            var movement = new MovementModule();
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.OnRequestPosition;

            movement.BeforeMove += collide.BeforeMove;
            movement.RequestPosition += position.OnRequestPosition;
            movement.OnMove += position.OnMove;
            
            return new GameObject(collide, graphics, movement, position);
        }

        public IGameObject GetDecoration(SpriteMap spriteMap, Vector2 initialPos)
        {
            var graphics = new GraphicModule(spriteMap);
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.OnRequestPosition;

            return new GameObject(graphics, position);
        }

        public IGameObject GetProp(SpriteMap spriteMap, Vector2 initialPos)
        {
            var collide = new CollideModule();
            var graphics = new GraphicModule(spriteMap);
            var position = new PositionModule(initialPos);

            graphics.RequestPosition += position.OnRequestPosition;

            return new GameObject(collide, graphics, position);
        }
    }
}
