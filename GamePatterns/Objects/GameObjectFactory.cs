using GamePatterns.Modules;

namespace GamePatterns.Objects
{
    public interface IGameObjectFactory
    {
    }

    public class GameObjectFactory : IGameObjectFactory
    {
        public IGameObject GetCharacter(SpriteMap spriteMap)
        {
            var collide = new CollideModule();
            var graphics = new GraphicModule(spriteMap);
            var movement = new MovementModule();
            var position = new PositionModule();

            graphics.RequestPosition += position.OnRequestPosition;

            movement.BeforeMove += collide.BeforeMove;
            movement.RequestPosition += position.OnRequestPosition;
            movement.OnMove += position.OnMove;
            
            return new GameObject(collide, graphics, movement, position);
        }
    }
}
