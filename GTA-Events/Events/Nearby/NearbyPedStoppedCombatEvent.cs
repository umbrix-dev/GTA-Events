using GTA.Events.Core;
using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedStoppedCombatEvent : NearbyPedEventBase
    {
        public event Action<Ped> Connect;

        private readonly PedStateTracker<bool> tracker = new PedStateTracker<bool>();

        internal void Invoke(Ped ped)
        {
            Connect?.Invoke(ped);
        }

        internal override void OnPed(Ped ped)
        {
            tracker.TryGetLast(ped, out bool wasInCombat);
            bool isInCombat = ped.IsInCombat;

            if (wasInCombat && !isInCombat)
            {
                Invoke(ped);
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