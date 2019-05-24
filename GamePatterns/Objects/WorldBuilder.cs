using GamePatterns.Modules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class WorldBuilder
    {
        private SpriteMap _spriteMap;
        private IGameObjectFactory _factory;
        private List<IGameObject> _objects;

        public WorldBuilder(SpriteMap spriteMap)
        {
            _spriteMap = spriteMap;

            _factory = new GameObjectFactory();
            _objects = new List<IGameObject>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    _objects.Add(_factory.GetDecoration(_spriteMap, new Vector2(i * 32, j * 32)));
                }
            }
        }

        public IEnumerable<IGameObject> GetObjects()
        {
            return _objects;
        }

        public IEnumerable<IGameObject> GetObjects(Rectangle container)
        {
            return _objects.Where(o =>
            {
                var rect = o.Get<GraphicModule>().Bounds;
                return CollisionDetector.HasCollision(container, rect);
            });
        }
    }
}
