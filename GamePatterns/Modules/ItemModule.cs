using Microsoft.Xna.Framework;

namespace GamePatterns.Components
{
    public interface IItemComponent : IGameObjectComponent
    {
        int Quantity { get; set; }
        int MaxQuantity { get; }
        int Weight { get; }
    }

    public class ItemComponent : IItemComponent
    {
        public int Quantity { get; set; }
        public int MaxQuantity { get; private set; }
        public int Weight { get; private set; }

        public void Update(GameTime gameTime)
        {
        }
    }
}
