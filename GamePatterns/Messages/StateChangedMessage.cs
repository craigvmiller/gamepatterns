using GamePatterns.States;
using System;

namespace GamePatterns.Messages
{
    public class StateChangedMessage
    {
        public Type StateType { get; set; }
        public StateChangedMessage(Type stateType)
        {
            StateType = stateType;
        }
    }
}
