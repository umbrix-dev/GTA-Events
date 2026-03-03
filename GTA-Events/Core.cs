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
        public static PlayerWeaponChangedEvent PlayerWeaponChanged { get; } = new PlayerWeaponChangedEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
        public static PlayerRevivedEvent PlayerRevived { get; } = new PlayerRevivedEvent();
        public static NearbyVehicleDestroyedEvent NearbyVehicleDestroyed { get; } = new NearbyVehicleDestroyedEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();

        private static readonly List<EventBase> events = new List<EventBase> {
            NearbyPedEnteredVehicle,
            NearbyPedLeftVehicle,
            NearbyPedFleeing,
            NearbyPedKilled,
            PlayerWantedLevelChanged,
            PlayerWeaponChanged,
            PlayerEnteredVehicle,
            PlayerLeftVehicle,
            PlayerDied,
            PlayerRevived,
            NearbyVehicleDestroyed,
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