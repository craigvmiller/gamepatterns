using Microsoft.Xna.Framework;

namespace GamePatterns.Modules
{
    public interface IItemModule : IGameObjectModule
    {
        int Quantity { get; set; }
        int MaxQuantity { get; set; }
        int Weight { get; set; }
    }

    public class ItemModule : IItemModule
    {
        public int Quantity { get; set; }
        public int MaxQuantity { get; set; }
        public int Weight { get; set; }

        public void Update(GameTime gameTime)
        {
        }
    }
}
