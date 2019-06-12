using GamePatterns.Messages;
using GamePatterns.Modules;
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
            foreach (IGameObject main in objects.Where(o => o.Has<ICollideModule>() && o.Has<IPositionModule>()))
            {
                Vector2 pos = main.Get<IPositionModule>().Position;
                Rectangle hitBox = main.Get<ICollideModule>().HitBox;
                Rectangle collider = new Rectangle((int)pos.X, (int)pos.Y, hitBox.Width, hitBox.Height);
                foreach (IGameObject other in objects.Where(o => o != main && o.Has<ICollideModule>() && o.Has<IPositionModule>()))
                {
                    Vector2 otherPos = other.Get<IPositionModule>().Position;
                    Rectangle otherHitBox = other.Get<ICollideModule>().HitBox;
                    Rectangle otherCollider = new Rectangle((int)otherPos.X, (int)otherPos.Y, otherHitBox.Width, otherHitBox.Height);
                    if (collider.Intersects(otherCollider))
                    {
                        Vector2 prev = main.Get<IPositionModule>().PreviousPosition;
                        Rectangle previousCollider = new Rectangle((int)prev.X, (int)prev.Y, hitBox.Width, hitBox.Height);
                        if (previousCollider.Intersects(otherCollider))
                        {
                            // calculate new position
                        }
                        else
                        {
                            main.Get<IPositionModule>().Reposition(prev);
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

        public static IEnumerable<ICollideModule> CollidesWith(Vector2 position, ICollideModule main, IEnumerable<ICollideModule> check)
        {
            Rectangle accurateHitBox = new Rectangle((int)position.X, (int)position.Y, main.HitBox.Width, main.HitBox.Height);
            foreach (ICollideModule module in check)
            {
                if (HasCollision(accurateHitBox, module.HitBox))
                {
                    yield return module;
                }
            }
        }

        public static bool HasCollision(IGameObject mainObj, IEnumerable<IGameObject> objects)
        {
            if (!mainObj.Has<ICollideModule>()) return false;
            ICollideModule mainModule = mainObj.Get<ICollideModule>();
            foreach (IGameObject obj in objects.Where(o => o.Has<CollideModule>()))
            {
                ICollideModule collideModule = obj.Get<ICollideModule>();
                if (HasCollision(mainModule.HitBox, collideModule.HitBox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
