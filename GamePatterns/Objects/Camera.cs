using GamePatterns.Modules;
using Microsoft.Xna.Framework;

namespace GamePatterns.Objects
{
    public interface ICamera
    {
        Matrix GetOffset(IGameObject follow);
        Matrix GetOffset(IGameObject follow, int speed);
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
            _offset = new Vector3(0, 0, 0);
        }

        public Matrix GetOffset(IGameObject follow) => GetOffset(follow, _speed);

        public Matrix GetOffset(IGameObject follow, int speed)
        {
            if (follow.Has<GraphicModule>())
            {
                var module = follow.Get<GraphicModule>();
                var currentBounds = new Rectangle((int)_offset.X, (int)_offset.Y, _bounds.Width, _bounds.Height);
                if (module.Bounds.Left < currentBounds.Left)
                {
                    _offset.X -= _speed;
                }

                if (module.Bounds.Right > currentBounds.Right)
                {
                    _offset.X += _speed;
                }

                if (module.Bounds.Top < currentBounds.Top)
                {
                    _offset.Y -= _speed;
                }

                if (module.Bounds.Bottom > currentBounds.Bottom)
                {
                    _offset.Y += _speed;
                }
            }

            var m = Matrix.CreateTranslation(_offset);
            return Matrix.Invert(m);
        }
    }
}
