using GTA.Events.Core;
using System;

namespace GTA.Events
{
    public class NearbyPedStartedCombatEvent : NearbyPedEventBase
    {
        public event Action<Ped, Entity> Connect;

        private readonly PedStateTracker<bool> tracker = new PedStateTracker<bool>();

        internal void Invoke(Ped ped, Entity entity)
        {
            Connect?.Invoke(ped, entity);
        }

        internal override void OnPed(Ped ped)
        {
            tracker.TryGetLast(ped, out bool wasInCombat);
            bool isInCombat = ped.IsInCombat;

            if (!wasInCombat && isInCombat)
            {
                Invoke(ped, ped.CombatTarget);
            }

            tracker.Set(ped, isInCombat);
        }

        internal override void OnTick()
        {
            tracker.Cleanup(Game.LastFrameTime, Position, Radius);
        }

        internal override bool HasSubscribers => Connect != null;
    }
}