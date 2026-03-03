using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyPedLeftVehicleEvent : NearbyPedEventBase
    {
        public event Action<Ped, Vehicle> Connect;

        internal void Invoke(Ped ped, Vehicle vehicle)
        {
            Connect?.Invoke(ped, vehicle);
        }

        private readonly Dictionary<int, Vehicle> pedLastVehicle = new Dictionary<int, Vehicle>();
        private float cleanupTimer = 0.0f;

        internal override void OnTick()
        {
            Ped[] nearbyPeds = GetNearbyPeds();

            cleanupTimer += Game.LastFrameTime;
            if (cleanupTimer > 30.0f)
            {
                cleanupTimer = 0.0f;

                HashSet<int> nearbyPedHandles = new HashSet<int>();
                foreach (Ped ped in nearbyPeds)
                {
                    nearbyPedHandles.Add(ped.Handle);
                }

                List<int> pedHandlesNotNearby = new List<int>();
                
                foreach (int handle in pedLastVehicle.Keys)
                {
                    if (!nearbyPedHandles.Contains(handle))
                    {
                        pedHandlesNotNearby.Add(handle);
                    }
                }
                
                foreach (int handle in pedHandlesNotNearby)
                {
                    pedLastVehicle.Remove(handle);
                }
            }

            foreach (Ped ped in nearbyPeds)
            {
                Vehicle currentVehicle = ped.CurrentVehicle;
                pedLastVehicle.TryGetValue(ped.Handle, out Vehicle lastVehicle);
                
                if (lastVehicle != null && currentVehicle == null)
                {
                    Invoke(ped, currentVehicle);
                }

                pedLastVehicle[ped.Handle] = currentVehicle;
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}