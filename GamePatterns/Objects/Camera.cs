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
            _offset = position;

            Target = position;
            Speed = 1;
        }

        public void Update(GameTime gameTime)
        {
            if (Target.X > _offset.X)
            {
                _offset.X += Speed;
            }
            else
            {
                _offset.X -= Speed;
            }

            if (Target.Y > _offset.Y)
            {
                _offset.Y += Speed;
            }
            else
            {
                _offset.Y -= Speed;
            }
        }

        public void Follow(IGameObject follow)
        {
            if (follow.Has<IPositionComponent>())
            {
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
