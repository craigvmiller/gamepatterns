using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        bool Has<T>() where T : class, IGameObjectModule;
        T Get<T>() where T : class, IGameObjectModule;
        void Update(GameTime gameTime);
    }

    public class GameObject : IGameObject
    {
        protected IEnumerable<IGameObjectModule> Modules;

        public GameObject()
        {
            Modules = new List<IGameObjectModule>();
        }

        public GameObject(IEnumerable<IGameObjectModule> modules)
        {
            Modules = modules;
        }

        public GameObject(params IGameObjectModule[] modules)
        {
            Modules = modules;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (IGameObjectModule module in Modules)
            {
                module.Update(gameTime);
            }
        }

        public bool Has<T>() where T : class, IGameObjectModule
        {
            return Modules.Any(m => m as T != null);
        }

        public T Get<T>() where T : class, IGameObjectModule
        {
            return (T)Modules.SingleOrDefault(m => m as T != null);
        }
    }
}
