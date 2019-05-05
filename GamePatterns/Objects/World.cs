using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public class World
    {
        public IEnumerable<IGameObject> Objects { get; set; }
    }
}
