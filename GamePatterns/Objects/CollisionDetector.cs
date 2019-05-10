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
            IEnumerable<IGameObject> collideObjects = objects.Where(o => o.HasModule<CollideModule>());
            foreach (IGameObject a in collideObjects)
            {
                CollideModule moduleA = a.GetModule<CollideModule>();
                Rectangle rectA = new Rectangle(
                    (int)moduleA.Position.X, (int)moduleA.Position.Y,
                    moduleA.HitBox.Width, moduleA.HitBox.Height);

                foreach (IGameObject b in collideObjects.Where(o => o != a))
                {
                    CollideModule moduleB = b.GetModule<CollideModule>();
                    Rectangle rectB = new Rectangle(
                        (int)moduleB.Position.X, (int)moduleB.Position.Y,
                        moduleB.HitBox.Width, moduleB.HitBox.Height);

                    if (HasCollision(rectA, rectB))
                    {
                        if (moduleA.OnCollision != null)
                        {
                            moduleA.OnCollision.Invoke(moduleB, new Events.CollisionEventArgs(moduleB.CollisionType));
                        }

                        if (moduleB.OnCollision != null)
                        {
                            moduleB.OnCollision.Invoke(moduleA, new Events.CollisionEventArgs(moduleA.CollisionType));
                        }
                    }
                }
            }
        }
    }
}
