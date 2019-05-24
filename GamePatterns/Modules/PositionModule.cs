using GamePatterns.Events;
using Microsoft.Xna.Framework;
using System;

namespace GamePatterns.Modules
{
    public interface IPositionModule : IGameObjectModule
    {
        EventHandler<PositionEventArgs> OnPositionChanged { get; set; }
        void OnMove(object sender, PositionEventArgs e);
        void OnRequestPosition(object sender, PositionEventArgs e);
    }

    public class PositionModule : IPositionModule
    {
        public Vector2 Position { get; private set; }
        public EventHandler<PositionEventArgs> OnPositionChanged { get; set; }

        public PositionModule()
        {
        }

        public PositionModule(Vector2 initialPos)
        {
            Position = initialPos;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void OnMove(object sender, PositionEventArgs e)
        {
            Position = e.Position;
            if (OnPositionChanged != null) OnPositionChanged.Invoke(this, new PositionEventArgs(Position));
        }

        public void OnRequestPosition(object sender, PositionEventArgs e)
        {
            e.Position = Position;
        }
    }
}
