using SFML.System;

namespace AngraEngine
{
    public static class Vector2fExtensions
    {
        public static float Length(this Vector2f v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static Vector2f Normalize(this Vector2f v)
        {
            float length = v.Length();
            if (length != 0)
            {
                v.X /= length;
                v.Y /= length;
            }
            return v;
        }
    }
}
