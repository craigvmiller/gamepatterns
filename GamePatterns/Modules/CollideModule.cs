using GamePatterns.Events;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public class CollideModule : IGameObjectModule
    {
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set; }
        public CollisionType CollisionType { get; set; }

        public EventHandler<CollisionEventArgs> OnCollision { get; set; }

        public void Update(GameTime gameTime)
        {
        }

        public void OnPositionChanged(object sender, MovementEventArgs e)
        {
            Position = e.NewPosition;
        }
    }
}
