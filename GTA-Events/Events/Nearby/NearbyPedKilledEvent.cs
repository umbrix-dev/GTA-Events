using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedKilledEvent : NearbyPedEventBase
    {
        public event Action<Ped, Entity> Connect;

        internal void Invoke(Ped ped, Entity entity)
        {
            Connect?.Invoke(ped, entity);
        }

        private readonly HashSet<int> deadPedHandles = new HashSet<int>();

        internal override void OnPed(Ped ped)
        {
            if (ped.IsDead && !deadPedHandles.Contains(ped.Handle))
            {
                Invoke(ped, ped.Killer);
                deadPedHandles.Add(ped.Handle);
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}