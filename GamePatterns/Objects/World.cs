using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePatterns.Objects
{
    public class World
    {
        public IEnumerable<IGameObject> Objects { get; set; }
    }
}
