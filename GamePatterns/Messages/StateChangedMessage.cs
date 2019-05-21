using System;

namespace GamePatterns.Messages
{
    public interface IGameMessage
    {
    }

    public class StateChangedMessage : IGameMessage
    {
        public Type StateType { get; set; }
        public StateChangedMessage(Type stateType)
        {
            StateType = stateType;
        }
    }
}
