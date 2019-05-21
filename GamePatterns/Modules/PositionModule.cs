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
        private Vector2 _position;

        public EventHandler<PositionEventArgs> OnPositionChanged { get; set; }

        public void Update(GameTime gameTime)
        {
        }

        public void OnMove(object sender, PositionEventArgs e)
        {
            _position = e.Position;
            if (OnPositionChanged != null) OnPositionChanged.Invoke(this, new PositionEventArgs(_position));
        }

        public void OnRequestPosition(object sender, PositionEventArgs e)
        {
            e.Position = _position;
        }
    }
}
