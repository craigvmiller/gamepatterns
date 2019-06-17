using GamePatterns.Components;
using Microsoft.Xna.Framework;
using System.Linq;

namespace GamePatterns.Objects
{
    public interface IGameObjectFactory
    {
        IGameObject GetPlayerCharacter(SpriteMap spriteMap, Vector2 initialPos, Rectangle hitBox, CollisionType collisionType);
        IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos, Rectangle hitBox, CollisionType collisionType);
        IGameObject GetWorld(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetDecoration(SpriteMap spriteMap, Vector2 initialPos);
        IGameObject GetProp(SpriteMap spriteMap, Vector2 initialPos, Rectangle hitBox, CollisionType collisionType);
    }

    public class GameObjectFactory : IGameObjectFactory
    {
        public IGameObject GetPlayerCharacter(SpriteMap spriteMap, Vector2 initialPos, Rectangle hitBox, CollisionType collisionType)
        {
            var collide = new CollideComponent(hitBox, collisionType);
            var equipment = new EquipmentComponent();
            var graphics = new GraphicComponent(spriteMap, Color.White);
            graphics.Sprites.Add(spriteMap.Sprites.First());
            var movement = new MovementComponent(2);
            var player = new PlayerComponent();
            var position = new PositionComponent(initialPos);
            return new GameObject(collide, equipment, graphics, movement, player, position);
        }

        public IGameObject GetCharacter(SpriteMap spriteMap, Vector2 initialPos, Rectangle hitBox, CollisionType collisionType)
        {
            var collide = new CollideComponent(hitBox, collisionType);
            var equipment = new EquipmentComponent();
            var graphics = new GraphicComponent(spriteMap, Color.White);
            graphics.Sprites.Add(spriteMap.Sprites.First());
            var movement = new MovementComponent(2);
            var position = new PositionComponent(initialPos);
            return new GameObject(collide, equipment, graphics, movement, position);
        }

        public IGameObject GetWorld(SpriteMap spriteMap, Vector2 initialPos)
        {
            var position = new PositionComponent(initialPos);
            var graphics = new GraphicComponent(spriteMap, Color.White);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    graphics.Sprites.Add(new Sprite() { Offset = new Vector2(j * 32, i * 32), Rectangle = new Rectangle(0, 0, 32, 32) });
                }
            }

            return new GameObject(graphics, position);
        }

        public IGameObject GetDecoration(SpriteMap spriteMap, Vector2 initialPos)
        {
            var graphics = new GraphicComponent(spriteMap, Color.White);
            graphics.Sprites.Add(spriteMap.Sprites.First());
            var position = new PositionComponent(initialPos);
            return new GameObject(graphics, position);
        }

        public IGameObject GetProp(SpriteMap spriteMap, Vector2 initialPos, Rectangle hitBox, CollisionType collisionType)
        {
            var collide = new CollideComponent(hitBox, collisionType);
            var graphics = new GraphicComponent(spriteMap, Color.White);
            graphics.Sprites.Add(spriteMap.Sprites.First());
            var position = new PositionComponent(initialPos);
            return new GameObject(collide, graphics, position);
        }
    }
}
