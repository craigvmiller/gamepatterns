using GamePatterns.Messages;
using Microsoft.Xna.Framework;
using PubSub.Extension;
using System;
using System.Collections.Generic;

namespace GamePatterns.States
{
    public class StateManager
    {
        private Stack<IGameState> _stack;
        public StateManager()
        {
            _stack = new Stack<IGameState>();
            this.Subscribe<StateChangedMessage>(m =>
            {
                var state = Activator.CreateInstance(m.StateType) as IGameState;
                state.Wake();
                if (_stack.Count > 0)
                {
                    _stack.Peek().Sleep();
                }
                _stack.Push(state);
            });
        }

        public void Update(GameTime gameTime)
        {
            if (_stack.Count > 0)
            {
                var current = _stack.Peek();
                current.Update(gameTime);
                if (current.Completed)
                {
                    current.Sleep();
                    _stack.Pop();
                }
            }
        }
    }
}
