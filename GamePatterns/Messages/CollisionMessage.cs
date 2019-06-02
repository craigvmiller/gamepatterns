using GamePatterns.Objects;

namespace GamePatterns.Messages
{
    public class CollisionMessage : IGameMessage
    {
        public CollisionType CollisionType { get; set; }

        public CollisionMessage(CollisionType type)
        {
            CollisionType = type;
        }
    }
}
