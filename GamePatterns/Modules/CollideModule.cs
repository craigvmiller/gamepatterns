using GamePatterns.Messages;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface ICollideModule : IGameObjectModule
    {
        CollisionType CollisionType { get; }
        Rectangle HitBox { get; }
        Action<CollisionMessage> OnCollision { get; set; }
        Func<Vector2, ICollideModule, CollisionType> CheckCollision { get; set; }
        void CheckMovement(MovementMessage message);
    }

    public class CollideModule : ICollideModule
    {
        public CollisionType CollisionType { get; private set; }
        public Rectangle HitBox { get; private set; }
        public Action<CollisionMessage> OnCollision { get; set; }
        public Func<Vector2, ICollideModule, CollisionType> CheckCollision { get; set; }

        public CollideModule(Rectangle hitBox, CollisionType collisionType)
        {
            HitBox = hitBox;
            CollisionType = collisionType;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void CheckMovement(MovementMessage message)
        {
            if (CheckCollision != null)
            {
                var type = CheckCollision.Invoke(message.Position, this);
                if (type == CollisionType.Wall)
                    message.Cancel = true;
            }
        }
    }
}
