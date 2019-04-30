using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.States
{
    public class StateManager
    {
        private Stack<IGameState> _stack;
        public StateManager()
        {
            _stack = new Stack<IGameState>();
        }

        public void Update(GameTime gameTime)
        {
            if (_stack.Count > 0)
            {
                var current = _stack.Peek();
                current.Update(gameTime);
                if (current.Completed)
                    _stack.Pop();
            }
        }
    }
}
