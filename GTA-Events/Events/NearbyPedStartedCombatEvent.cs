using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedStartedCombatEvent : NearbyPedEventBase
    {
        public event Action<Ped, Entity> Connect;

        internal void Invoke(Ped ped, Entity entity)
        {
            Connect?.Invoke(ped, entity);
        }

        private readonly Dictionary<int, bool> pedInCombat = new Dictionary<int, bool>();
        private float cleanupTimer = 0.0f;

        internal override void OnPed(Ped ped)
        {
            bool isInCombat = ped.IsInCombat;
            pedInCombat.TryGetValue(ped.Handle, out bool wasInCombat);

            if (!wasInCombat && isInCombat)
            {
                Invoke(ped, ped.CombatTarget);
            }

            pedInCombat[ped.Handle] = isInCombat;
        }

        internal override void OnTick()
        {
            cleanupTimer += Game.LastFrameTime;
            if (cleanupTimer > 30.0f)
            {
                cleanupTimer = 0.0f;
                Ped[] nearbyPeds = World.GetNearbyPeds(
                    Position ?? Game.Player.Character.Position, Radius
                );

                HashSet<int> nearbyHandles = new HashSet<int>();
                foreach (Ped ped in nearbyPeds)
                    nearbyHandles.Add(ped.Handle);

                List<int> toRemove = new List<int>();
                foreach (int handle in pedInCombat.Keys)
                    if (!nearbyHandles.Contains(handle)) toRemove.Add(handle);

                foreach (int handle in toRemove)
                    pedInCombat.Remove(handle);
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}