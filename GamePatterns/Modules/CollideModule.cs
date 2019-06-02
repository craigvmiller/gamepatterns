using GamePatterns.Messages;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface ICollideModule : IGameObjectModule
    {
        Action<CollisionMessage> OnCollision { get; set; }
        void CheckMovement(MovementMessage message);
    }

    public class CollideModule : ICollideModule
    {
        public CollisionType CollisionType { get; private set; }
        public Rectangle HitBox { get; private set; }
        public Action<CollisionMessage> OnCollision { get; set; }
        
        public void Update(GameTime gameTime)
        {
        }

        public void CheckMovement(MovementMessage message)
        {
            message.Cancel = false;
        }
    }
}
