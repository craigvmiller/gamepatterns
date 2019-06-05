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
        Func<Rectangle, bool> CheckCollision { get; set; }
        void CheckMovement(MovementMessage message);
    }

    public class CollideModule : ICollideModule
    {
        public CollisionType CollisionType { get; private set; }
        public Rectangle HitBox { get; private set; }
        public Action<CollisionMessage> OnCollision { get; set; }
        public Func<Rectangle, bool> CheckCollision { get; set; }

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
                message.Cancel = CheckCollision.Invoke(new Rectangle((int)message.Position.X, (int)message.Position.Y, HitBox.Width, HitBox.Height));
            }
        }
    }
}
