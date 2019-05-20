using GamePatterns.Modules;
using Microsoft.Xna.Framework;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        bool Has<T>() where T : class, IGameObjectModule;
        T Get<T>() where T : class, IGameObjectModule;
        void Update(GameTime gameTime);
    }
}
