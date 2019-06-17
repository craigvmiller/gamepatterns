using GamePatterns.Messages;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ninject;
using PubSub.Extension;
using System.Collections.Generic;

namespace GamePatterns.States
{
    public class StateManager
    {
        private Stack<IGameState> _stack;
        private InputHelper _input;
        private ContentManager _content;
        private IKernel _kernel;

        public StateManager(IKernel kernel, ContentManager content)
        {
            _kernel = kernel;
            _stack = new Stack<IGameState>();
            _input = new InputHelper();
            _content = content;

            this.Subscribe<StateChangedMessage>(m =>
            {
                var state = (IGameState)_kernel.Get(m.StateType);
                Push(state);
            });
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if (_stack.Count > 0)
            {
                var current = _stack.Peek();
                current.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (_stack.Count > 0)
            {
                var current = _stack.Peek();
                current.HandleInputCommands(_input.HandleInput());
                current.Update(gameTime);

                if (current.Completed)
                {
                    current.Sleep();
                    _stack.Pop();
                }
            }
        }

        public void Push(IGameState state)
        {
            if (_stack.Count > 0)
            {
                _stack.Peek().Sleep();
            }
            state.Wake();
            _stack.Push(state);
        }
    }
}
