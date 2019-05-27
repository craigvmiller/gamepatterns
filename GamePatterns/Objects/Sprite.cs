using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public struct Sprite
    {
        public int Id { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Offset { get; set; }
    }

    public struct Animation
    {
        public int Id { get; set; }
        public IEnumerable<AnimationFrame> Frames { get; set; }
    }

    public struct AnimationFrame
    {
        public Sprite Sprite { get; set; }
        public int Length { get; set; }
        public int Sequence { get; set; }
    }
}
