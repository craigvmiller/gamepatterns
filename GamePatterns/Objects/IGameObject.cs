using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        IEnumerable<IGameObjectModule> Modules { get; set; }
        bool HasModule<T>() where T : class, IGameObjectModule;
        T GetModule<T>() where T : class, IGameObjectModule;
        void Update(GameTime gameTime);
    }
}
