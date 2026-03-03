
using GTA.Math;
using System;
using System.Collections.Generic;

namespace GTA.Events
{
    public class NearbyVehicleDestroyedEvent : EventBase
    {
        /// <summary>
        /// The position used to check for nearby vehicles. If null, it will use the player's position.
        /// </summary>
        public Vector3? Position { get; set; } = null;

        /// <summary>
        /// The radius used to check for nearby vehicles.
        /// </summary>
        public float Radius { get; set; } = 30f;

        public event Action<Vehicle> Connect;

        internal void Invoke(Vehicle vehicle)
        {
            Connect?.Invoke(vehicle);
        }

        private readonly Dictionary<int, bool> vehicleDestroyed = new Dictionary<int, bool>();
        private float cleanupTimer = 0.0f;

        internal override void OnTick()
        {
            Vehicle[] nearbyVehicles = World.GetNearbyVehicles(Position ?? Game.Player.Character.Position, Radius);

            cleanupTimer += Game.LastFrameTime;
            if (cleanupTimer > 30.0f)
            {
                cleanupTimer = 0.0f;

                HashSet<int> nearbyVehicleHandles = new HashSet<int>();
                foreach (Vehicle vehicle in nearbyVehicles)
                {
                    nearbyVehicleHandles.Add(vehicle.Handle);
                }

                List<int> vehicleHandlesNotNearby = new List<int>();

                foreach (int handle in vehicleDestroyed.Keys)
                {
                    if (!nearbyVehicleHandles.Contains(handle))
                    {
                        vehicleHandlesNotNearby.Add(handle);
                    }
                }

                foreach (int handle in vehicleHandlesNotNearby)
                {
                    vehicleDestroyed.Remove(handle);
                }
            }

            foreach (Vehicle vehicle in nearbyVehicles)
            {
                vehicleDestroyed.TryGetValue(vehicle.Handle, out bool wasDestroyed);
                
                bool isDestroyed = vehicle.IsConsideredDestroyed;
                if (!wasDestroyed && isDestroyed)
                {
                    Invoke(vehicle);
                }

                vehicleDestroyed[vehicle.Handle] = isDestroyed;
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}