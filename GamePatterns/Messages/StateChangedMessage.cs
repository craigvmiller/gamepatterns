using System;

namespace GamePatterns.Messages
{
    public class StateChangedMessage : IGameMessage
    {
        public Type StateType { get; set; }
        public StateChangedMessage(Type stateType)
        {
            StateType = stateType;
        }
    }
}
