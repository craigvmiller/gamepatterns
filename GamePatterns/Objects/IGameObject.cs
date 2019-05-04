using GamePatterns.Modules;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        IEnumerable<IGameObjectModule> Modules { get; set; }
    }
}
