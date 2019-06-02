using GamePatterns.Messages;
using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
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

        public static void CheckForCollisions(IEnumerable<IGameObject> objects)
        {
            IEnumerable<IGameObject> collideObjects = objects.Where(o => o.Has<CollideModule>());
            foreach (IGameObject a in collideObjects)
            {
                CollideModule moduleA = a.Get<CollideModule>();
                foreach (IGameObject b in collideObjects.Where(o => o != a))
                {
                    CollideModule moduleB = b.Get<CollideModule>();
                    if (HasCollision(moduleA.HitBox, moduleB.HitBox))
                    {
                        if (moduleA.OnCollision != null)
                        {
                            moduleA.OnCollision.Invoke(new CollisionMessage(moduleB.CollisionType));
                        }

                        if (moduleB.OnCollision != null)
                        {
                            moduleB.OnCollision.Invoke(new CollisionMessage(moduleA.CollisionType));
                        }
                    }
                }
            }
        }
    }
}
