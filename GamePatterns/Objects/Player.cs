using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public interface IObjectState
    {
        void Update(GameTime gameTime);
    }

    public class Player
    {
        public SpriteMap SpriteMap { get; set; }
        public IEnumerable<IGameObjectModule> Modules { get; set; }

        public Player()
        {
            Modules = new List<IGameObjectModule>();
        }
    }
}
