using GamePatterns.Events;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public class InteractModule : IGameObjectModule
    {
        public EventHandler<InteractEventArgs> OnInteract { get; set; }

        public void Update(GameTime gameTime)
        {
        }
    }
}
