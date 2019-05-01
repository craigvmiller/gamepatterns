using GamePatterns.Modules;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public interface IGameObject
    {
        IEnumerable<IGameObjectModule> Modules { get; set; }
    }

    public class Player : IGameObject
    {
        public SpriteMap SpriteMap { get; set; }
        public IEnumerable<IGameObjectModule> Modules { get; set; }

        public Player()
        {
            Modules = new List<IGameObjectModule>();
        }
    }
}
