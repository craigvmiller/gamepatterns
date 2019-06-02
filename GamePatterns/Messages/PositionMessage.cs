using Microsoft.Xna.Framework;

namespace GamePatterns.Messages
{
    public class PositionMessage : IGameMessage
    {
        public Vector2 Position { get; set; }

        public PositionMessage()
        {
        }

        public PositionMessage(Vector2 position)
        {
            Position = position;
        }
    }
}
