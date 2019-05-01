﻿using Microsoft.Xna.Framework;

namespace GamePatterns.Modules
{
    public interface IGameObjectModule
    {
        void Update(GameTime gameTime);
        void HandleInput();
    }
}
