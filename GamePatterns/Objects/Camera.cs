using GamePatterns.Messages;
using GamePatterns.Components;
using Microsoft.Xna.Framework;
using PubSub.Extension;

namespace GamePatterns.Objects
{
    public interface ICamera
    {
        void Follow(IGameObject follow);
        Matrix GetOffset();
    }

    public class Camera : ICamera
    {
        private Rectangle _bounds;
        private Vector3 _offset;
        private int _speed;

        public Camera() : this(new Rectangle(0, 0, 0, 0), 1) { }

        public Camera(Rectangle bounds) : this(bounds, 1) { }

        public Camera(Rectangle bounds, int speed)
        {
            _bounds = bounds;
            _speed = speed;
            _offset = new Vector3(bounds.X, bounds.Y, 0);
        }
        
        public Matrix GetOffset()
        {
            var m = Matrix.CreateTranslation(_offset);
            return Matrix.Invert(m);
        }

        public void Follow(IGameObject follow)
        {
            if (follow.Has<IPositionComponent>())
            {
                //follow.Get<IPositionComponent>().OnPositionChanged += (PositionMessage p) => _offset = new Vector3(p.Position, 0);
            }
        }
    }
}
