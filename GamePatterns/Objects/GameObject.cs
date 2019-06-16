using GamePatterns.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        bool Has<T>() where T : class, IGameObjectComponent;
        T Get<T>() where T : class, IGameObjectComponent;
        void Update(GameTime gameTime);
    }

    public class GameObject : IGameObject
    {
        protected IEnumerable<IGameObjectComponent> Components;

        public GameObject()
        {
            Components = new List<IGameObjectComponent>();
        }

        public GameObject(IEnumerable<IGameObjectComponent> components)
        {
            Components = components;
        }

        public GameObject(params IGameObjectComponent[] components)
        {
            Components = components;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (IGameObjectComponent component in Components)
            {
                component.Update(gameTime);
            }
        }

        public bool Has<T>() where T : class, IGameObjectComponent
        {
            return Components.Any(m => m as T != null);
        }

        public T Get<T>() where T : class, IGameObjectComponent
        {
            return (T)Components.SingleOrDefault(m => m as T != null);
        }
    }
}
