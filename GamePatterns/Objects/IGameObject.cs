using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        IEnumerable<IGameObjectModule> Modules { get; set; }
        void Update(GameTime gameTime);
    }
}
