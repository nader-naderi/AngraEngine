using SFML.System;

namespace AngraEngine
{
    public interface IPhysical
    {
        /// <summary>
        /// جاذبه
        /// </summary>
        float Gravity { get; set; } 
        /// <summary>
        /// اصطکاک
        /// </summary>
        float Friction { get; set; }
        /// <summary>
        /// تکانه
        /// </summary>
        Vector2f Velocity { get; set; } 
    }
}
