using GamePatterns.Messages;
using GamePatterns.Modules;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ninject;
using PubSub.Extension;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.States
{
    public class StateManager
    {
        private Stack<IGameState> _stack;
        private InputHelper _input;
        private IKernel _kernel;

        public StateManager(IKernel kernel)
        {
            _stack = new Stack<IGameState>();
            _input = new InputHelper();
            _kernel = kernel;
            this.Subscribe<StateChangedMessage>(m =>
            {
                var state = _kernel.Get(m.StateType) as IGameState;
                Push(state);
            });
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if (_stack.Count > 0)
            {
                spriteBatch.Begin();
                var current = _stack.Peek();
                foreach (var obj in current.Objects)
                {
                    var graphics = obj.Modules.SingleOrDefault(m => m is GraphicsModule) as GraphicsModule;
                    if (graphics != null)
                    {
                        graphics.Draw(spriteBatch);
                    }
                }
                spriteBatch.End();
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
