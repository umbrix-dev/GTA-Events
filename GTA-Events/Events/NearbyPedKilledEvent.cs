using GTA.Math;
using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedKilledEvent
    {
        /// <summary>
        /// The position used to check for nearby peds. If null, it will use the player's position.
        /// </summary>
        public Vector3? Position { get; set; } = null;

        /// <summary>
        /// The radius used to check for nearby peds.
        /// </summary>
        public float Radius { get; set; } = 30f;

        public event Action<Ped, Entity> Connect;

        internal void Invoke(Ped ped, Entity entity)
        {
            Connect?.Invoke(ped, entity);
        }

        private readonly HashSet<int> deadPedHandles = new HashSet<int>();

        internal void OnTick()
        {
            foreach (Ped ped in World.GetNearbyPeds(Position ?? Game.Player.Character.Position, Radius))
            {
                if (ped.IsDead && !deadPedHandles.Contains(ped.Handle))
                {
                    Invoke(ped, ped.Killer);
                    deadPedHandles.Add(ped.Handle);
                }
            }
        }
    }
}