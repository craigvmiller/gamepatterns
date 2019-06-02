using Microsoft.Xna.Framework;

namespace GamePatterns.Messages
{
    public class MovementMessage : IGameMessage
    {
        public Vector2 Position { get; set; }
        public bool Cancel { get; set; }

        public MovementMessage(Vector2 position)
        {
            Position = position;
        }
    }
}
