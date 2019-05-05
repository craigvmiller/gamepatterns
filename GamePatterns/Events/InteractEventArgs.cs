using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Events
{
    public class InteractEventArgs : EventArgs { }

    public class MovementEventArgs : EventArgs
    {
        public MovementEventArgs(Vector2 position)
        {
            NewPosition = position;
        }

        public Vector2 NewPosition { get; set; }
    }

    public class DrawEventArgs : EventArgs { }

    public class CollisionEventArgs : EventArgs { }
}
