using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Events
{
    public class PositionEventArgs : EventArgs
    {
        public PositionEventArgs(Vector2 position)
        {
            Position = position;
        }

        public Vector2 Position { get; set; }
        public bool Cancel { get; set; }
    }
}
