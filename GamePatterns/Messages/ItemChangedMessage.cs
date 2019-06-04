using GamePatterns.Objects;

namespace GamePatterns.Messages
{
    public class ItemChangedMessage : IGameMessage
    {
        public IGameObject ChangedObject { get; set; }

        public ItemChangedMessage(IGameObject obj)
        {
            ChangedObject = obj;
        }
    }
}
