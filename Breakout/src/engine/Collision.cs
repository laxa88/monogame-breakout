using System;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class NoCollisionException : Exception
    {
        public NoCollisionException() : base("") { }
    }

    public class Collision
    {
        // https://github.com/not-fl3/macroquad/blob/6a1a4949084e2358d91a51fc45206c9f8ee31619/src/math/rect.rs#L97-L114
        public static Rectangle? Intersects(Rectangle r1, Rectangle r2)
        {
            int left = Math.Max(r1.X, r2.X);
            int top = Math.Max(r1.Y, r2.Y);
            int right = Math.Min(r1.X + r1.Width, r2.X + r2.Width);
            int bottom = Math.Min(r1.Y + r1.Height, r2.Y + r2.Height);

            if (right < left || bottom < top)
            {
                return null;
            }

            return new Rectangle(left, top, right - left, bottom - top);
        }
    }
}
