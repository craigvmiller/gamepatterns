using GamePatterns.Objects;

namespace GamePatterns.Messages
{
    public class GameObjectCreatedMessage : IGameMessage
    {
        public IGameObject CreatedObject { get; set; }

        public GameObjectCreatedMessage(IGameObject obj)
        {
            CreatedObject = obj;
        }
    }
}
