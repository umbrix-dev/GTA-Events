using GTA.Math;
using GTA.Native;
using System;

namespace GTA.Events
{
    public class NearbyExplosionEvent
    {
        /// <summary>
        /// The explosion type to filter for. When set to null it won't apply any filter.
        /// </summary>
        public ExplosionType? Type = null;

        /// <summary>
        /// The position of the area where the radius should be applied. 
        /// Will use players position if set to null.
        /// </summary>
        public Vector3? Position = null;

        /// <summary>
        /// The radius of the area where the explosion will be detected.
        /// </summary>
        public float Radius = 100f;

        public event Action Connect;

        internal void Invoke()
        {
            Connect?.Invoke();
        }

        internal void OnTick()
        {
            var type = Type.HasValue ? (int)Type.Value : -1;
            Vector3 position = Position ?? Game.Player.Character.Position;

            bool isExplosionInArea = Function.Call<bool>(Hash.IS_EXPLOSION_IN_AREA, type,
                position.X - Radius, position.Y - Radius, position.Z - Radius,
                position.X + Radius, position.Y + Radius, position.Z + Radius
            );

            if (isExplosionInArea)
            {
                Invoke();
            }
        }
    }
}