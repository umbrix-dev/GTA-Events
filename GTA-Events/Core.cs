
using System.CodeDom;
using System.Collections.Generic;

namespace GTA.Events
{
    public static class Events
    {
        public static NearbyPedEnteredVehicleEvent NearbyPedEnteredVehicle { get; } = new NearbyPedEnteredVehicleEvent();
        public static NearbyPedLeftVehicleEvent NearbyPedLeftVehicle { get; } = new NearbyPedLeftVehicleEvent();
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();

        private static readonly List<EventBase> events = new List<EventBase> {
            NearbyPedEnteredVehicle,
            NearbyPedLeftVehicle,
            NearbyPedKilled,
            PlayerEnteredVehicle,
            PlayerLeftVehicle,
            PlayerDied,
            NearbyExplosion
        };

        public static void OnTick()
        {
            foreach (EventBase e in events)
            {
                if (e.HasSubscribers)
                {
                    e.OnTick();
                }
            }
        }
    }
}