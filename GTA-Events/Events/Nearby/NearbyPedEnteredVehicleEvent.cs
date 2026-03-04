using GTA.Events.Core;
using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedEnteredVehicleEvent : NearbyPedEventBase
    {
        public event Action<Ped, Vehicle> Connect;

        private readonly PedStateTracker<Vehicle> tracker = new PedStateTracker<Vehicle>();

        internal void Invoke(Ped ped, Vehicle vehicle)
        {
            Connect?.Invoke(ped, vehicle);
        }

        internal override void OnPed(Ped ped)
        {
            tracker.TryGetLast(ped, out Vehicle lastVehicle);
            Vehicle currentVehicle = ped.CurrentVehicle;

            if (lastVehicle == null && currentVehicle != null)
            {
                Invoke(ped, currentVehicle);
            }

            tracker.Set(ped, currentVehicle);
        }

        internal override void OnTick()
        {
            tracker.Cleanup(Game.LastFrameTime, Position, Radius);
        }

        internal override bool HasSubscribers => Connect != null;
    }
}