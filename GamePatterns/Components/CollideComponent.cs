using GamePatterns.Messages;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Components
{
    public interface ICollideComponent : IGameObjectComponent
    {
        CollisionType CollisionType { get; }
        Rectangle HitBox { get; }
        Action<CollisionMessage> OnCollision { get; set; }
    }

    public class CollideComponent : ICollideComponent
    {
        public CollisionType CollisionType { get; private set; }
        public Rectangle HitBox { get; private set; }
        public Action<CollisionMessage> OnCollision { get; set; }

        public CollideComponent(Rectangle hitBox, CollisionType collisionType)
        {
            HitBox = hitBox;
            CollisionType = collisionType;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
