using System.Collections.Generic;


namespace GTA.Events
{
    public static class Events
    {
        public static NearbyPedEnteredVehicleEvent NearbyPedEnteredVehicle { get; } = new NearbyPedEnteredVehicleEvent();
        public static NearbyPedLeftVehicleEvent NearbyPedLeftVehicle { get; } = new NearbyPedLeftVehicleEvent();
        public static NearbyPedFleeingEvent NearbyPedFleeing { get; } = new NearbyPedFleeingEvent();
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();
        public static PlayerWantedLevelChangedEvent PlayerWantedLevelChanged { get; } = new PlayerWantedLevelChangedEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
        public static PlayerRevivedEvent PlayerRevived { get; } = new PlayerRevivedEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();

        private static readonly List<EventBase> events = new List<EventBase> {
            NearbyPedEnteredVehicle,
            NearbyPedLeftVehicle,
            NearbyPedFleeing,
            NearbyPedKilled,
            PlayerWantedLevelChanged,
            PlayerEnteredVehicle,
            PlayerLeftVehicle,
            PlayerDied,
            PlayerRevived,
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