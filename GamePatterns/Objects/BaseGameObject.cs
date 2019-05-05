using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
    }
}
