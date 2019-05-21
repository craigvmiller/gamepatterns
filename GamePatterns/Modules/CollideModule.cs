using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface ICollideModule : IGameObjectModule
    {
        EventHandler<CollisionEventArgs> OnCollision { get; set; }
        void BeforeMove(object sender, PositionEventArgs e);
    }

    public class CollideModule : ICollideModule
    {
        public CollisionType CollisionType { get; private set; }
        public Rectangle HitBox { get; private set; }
        public EventHandler<CollisionEventArgs> OnCollision { get; set; }

        public void Update(GameTime gameTime)
        {
        }

        public void BeforeMove(object sender, PositionEventArgs e)
        {
            if (false) // this has collision
            {
                e.Cancel = true;
            }
        }
    }
}
