using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
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

        public void Update(GameTime gameTime)
        {
            foreach (IGameObjectModule module in Modules)
            {
                module.Update(gameTime);
            }
        }

        public bool Has<T>() where T : class, IGameObjectModule
        {
            return Modules.Any(m => m.GetType() == typeof(T));
        }

        public T Get<T>() where T : class, IGameObjectModule
        {
            return (T)Modules.SingleOrDefault(m => m.GetType() == typeof(T));
        }
    }
}
