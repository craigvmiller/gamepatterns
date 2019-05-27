using Microsoft.Xna.Framework;

namespace GamePatterns.Messages
{
    public class CameraMovedMessage : IGameMessage
    {
        public Rectangle Bounds { get; set; }

        public CameraMovedMessage(Rectangle bounds)
        {
            Bounds = bounds;
        }
    }
}
