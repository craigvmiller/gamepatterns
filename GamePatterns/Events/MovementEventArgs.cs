using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Events
{
    public class MovementEventArgs : EventArgs
    {
        public MovementEventArgs(Vector2 position)
        {
            NewPosition = position;
        }

        public Vector2 NewPosition { get; set; }
    }
}
