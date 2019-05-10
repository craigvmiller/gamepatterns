using GamePatterns.Objects;
using System;

namespace GamePatterns.Events
{
    public class CollisionEventArgs : EventArgs
    {
        public CollisionType CollisionType { get; set; }

        public CollisionEventArgs(CollisionType type)
        {
            CollisionType = type;
        }
    }
}
