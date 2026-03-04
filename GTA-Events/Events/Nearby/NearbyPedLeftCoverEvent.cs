using GTA.Events.Core;
using System;

namespace GTA.Events
{
    public class NearbyPedLeftCoverEvent : NearbyPedEventBase
    {
        public event Action<Ped> Connect;

        private readonly PedStateTracker<bool> tracker = new PedStateTracker<bool>();

        internal void Invoke(Ped ped)
        {
            Connect?.Invoke(ped);
        }

        internal override void OnPed(Ped ped)
        {
            tracker.TryGetLast(ped, out bool alreadyInCover);
            bool currentlyInCover = ped.IsInCover;

            if (alreadyInCover && !currentlyInCover)
            {
                Invoke(ped);
            }

            tracker.Set(ped, currentlyInCover);
        }

        internal override void OnTick()
        {
            tracker.Cleanup(Game.LastFrameTime, Position, Radius);
        }

        internal override bool HasSubscribers => Connect != null;
    }
}