using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public class Sprite
    {
        public int Id { get; set; }
        public Rectangle Rectangle { get; set; }
    }

    public class Animation
    {
        public int Id { get; set; }
        public IEnumerable<AnimationFrame> Frames { get; set; }
    }

    public class AnimationFrame : Sprite
    {
        public int Length { get; set; }
        public int Sequence { get; set; }
    }
}
