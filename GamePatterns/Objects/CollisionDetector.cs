using GamePatterns.Messages;
using GamePatterns.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public interface ICollisionHandler
    {
        void FixCollisions(IEnumerable<IGameObject> objects);
    }

    public class CollisionHandler : ICollisionHandler
    {
        public void FixCollisions(IEnumerable<IGameObject> objects)
        {
            foreach (IGameObject main in objects.Where(o => o.Has<ICollideComponent>() && o.Has<IPositionComponent>()))
            {
                Vector2 pos = main.Get<IPositionComponent>().Position;
                Rectangle hitBox = main.Get<ICollideComponent>().HitBox;
                Rectangle collider = new Rectangle((int)pos.X, (int)pos.Y, hitBox.Width, hitBox.Height);
                foreach (IGameObject other in objects.Where(o => o != main && o.Has<ICollideComponent>() && o.Has<IPositionComponent>()))
                {
                    Vector2 otherPos = other.Get<IPositionComponent>().Position;
                    Rectangle otherHitBox = other.Get<ICollideComponent>().HitBox;
                    Rectangle otherCollider = new Rectangle((int)otherPos.X, (int)otherPos.Y, otherHitBox.Width, otherHitBox.Height);
                    if (collider.Intersects(otherCollider))
                    {
                        Vector2 prev = main.Get<IPositionComponent>().PreviousPosition;
                        Rectangle previousCollider = new Rectangle((int)prev.X, (int)prev.Y, hitBox.Width, hitBox.Height);
                        if (previousCollider.Intersects(otherCollider))
                        {
                            // calculate new position
                        }
                        else
                        {
                            main.Get<IPositionComponent>().Position = prev;
                        }
                    }
                }
            }
        }
    }

    public static class CollisionDetector
    {
        public static bool HasCollision(Rectangle a, Rectangle b)
        {
            return
                ((b.Left >= a.Left && b.Left <= a.Right)
                || (b.Right >= a.Left && b.Right <= a.Right))
                &&
                ((b.Top >= a.Top && b.Top <= a.Bottom)
                || (b.Bottom >= a.Top && b.Top <= a.Bottom));
        }

        public static IEnumerable<ICollideComponent> CollidesWith(Vector2 position, ICollideComponent main, IEnumerable<ICollideComponent> check)
        {
            Rectangle accurateHitBox = new Rectangle((int)position.X, (int)position.Y, main.HitBox.Width, main.HitBox.Height);
            foreach (ICollideComponent collide in check)
            {
                if (HasCollision(accurateHitBox, collide.HitBox))
                {
                    yield return collide;
                }
            }
        }

        public static bool HasCollision(IGameObject mainObj, IEnumerable<IGameObject> objects)
        {
            if (!mainObj.Has<ICollideComponent>()) return false;
            ICollideComponent mainCollide = mainObj.Get<ICollideComponent>();
            foreach (IGameObject obj in objects.Where(o => o.Has<CollideComponent>()))
            {
                ICollideComponent objCollide = obj.Get<ICollideComponent>();
                if (HasCollision(mainCollide.HitBox, objCollide.HitBox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
