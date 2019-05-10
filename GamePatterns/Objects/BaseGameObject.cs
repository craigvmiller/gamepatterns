using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class BaseGameObject : IGameObject
    {
        public IEnumerable<IGameObjectModule> Modules { get; set; }

        public BaseGameObject()
        {
            Modules = new List<IGameObjectModule>();
        }

        public BaseGameObject(IEnumerable<IGameObjectModule> modules)
        {
            Modules = modules;
        }

        public BaseGameObject(params IGameObjectModule[] modules)
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

        public bool HasModule<T>() where T : class, IGameObjectModule
        {
            return Modules.Any(m => m.GetType() == typeof(T));
        }

        public T GetModule<T>() where T : class, IGameObjectModule
        {
            return (T)Modules.SingleOrDefault(m => m.GetType() == typeof(T));
        }
    }
}
