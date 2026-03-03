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

        internal override void OnTick()
        {
            foreach (Ped ped in GetNearbyPeds())
            {
                if (ped.IsFleeing)
                {
                    Invoke(ped);
                }
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}