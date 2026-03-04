using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedEnteredVehicleEvent : NearbyPedEventBase
    {
        public event Action<Ped, Vehicle> Connect;

        internal void Invoke(Ped ped, Vehicle vehicle)
        {
            Connect?.Invoke(ped, vehicle);
        }

        private readonly Dictionary<int, Vehicle> pedLastVehicle = new Dictionary<int, Vehicle>();
        private float cleanupTimer = 0.0f;

        internal override void OnPed(Ped ped)
        {
            Vehicle currentVehicle = ped.CurrentVehicle;
            pedLastVehicle.TryGetValue(ped.Handle, out Vehicle lastVehicle);

            if (lastVehicle == null && currentVehicle != null)
            {
                Invoke(ped, currentVehicle);
            }

            pedLastVehicle[ped.Handle] = currentVehicle;
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
                foreach (int handle in pedLastVehicle.Keys)
                    if (!nearbyHandles.Contains(handle)) toRemove.Add(handle);

                foreach (int handle in toRemove)
                    pedLastVehicle.Remove(handle);
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}