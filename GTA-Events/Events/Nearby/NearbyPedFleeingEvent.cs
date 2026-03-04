using System;

namespace GTA.Events
{
    public class NearbyPedFleeingEvent : NearbyPedEventBase
    {
        public event Action<Ped> Connect;

        internal void Invoke(Ped ped)
        {
            Connect?.Invoke(ped);
        }

        internal override void OnPed(Ped ped)
        {
            if (ped.IsFleeing)
            {
                Invoke(ped);
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}