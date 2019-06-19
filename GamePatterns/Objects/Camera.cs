using GamePatterns.Messages;
using GamePatterns.Components;
using Microsoft.Xna.Framework;

namespace GamePatterns.Objects
{
    public interface ICamera : IGameObject
    {
        Matrix Offset { get; }
        Vector3 Target { get; set; }
        int Speed { get; set; }
        void Follow(IGameObject obj);
    }

    public class Camera : ICamera
    {
        private Vector3 _offset;
        private Vector3 _position;

        public Matrix Offset
        {
            get
            {
                var result = Matrix.CreateTranslation(_offset);
                return Matrix.Invert(result);
            }
        }
        public int Speed { get; set; }
        public Vector3 Target { get; set; }

        public Camera(Vector3 position)
        {
            _position = position;
            Speed = 2;
        }

        public void Update(GameTime gameTime)
        {
            if (Target.X > _offset.X + _position.X)
            {
                _offset.X += Speed;
            }
            else if (Target.X < _offset.X + _position.X)
            {
                _offset.X -= Speed;
            }

            if (Target.Y > _offset.Y + _position.Y)
            {
                _offset.Y += Speed;
            }
            else if (Target.Y < _offset.Y + _position.Y)
            {
                _offset.Y -= Speed;
            }
        }

        public void Follow(IGameObject follow)
        {
            if (follow.Has<IPositionComponent>())
            {
                Target = new Vector3(follow.Get<IPositionComponent>().Position, 0);
                follow.Get<IPositionComponent>().OnPositionChanged += (PositionMessage p) => Target = new Vector3(p.Position, 0);
            }
        }

        bool IGameObject.Has<T>()
        {
            throw new System.NotImplementedException();
        }

        T IGameObject.Get<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
