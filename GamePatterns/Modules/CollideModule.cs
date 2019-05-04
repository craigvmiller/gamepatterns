using GamePatterns.Events;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public class CollideModule : IGameObjectModule
    {
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set; }

        public EventHandler<CollisionEventArgs> OnCollisionStart { get; set; }
        public EventHandler<CollisionEventArgs> OnCollisionEnd { get; set; }

        public void Update(GameTime gameTime)
        {
        }
    }
}
