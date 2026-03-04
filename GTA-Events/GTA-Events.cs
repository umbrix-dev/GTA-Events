using System.Collections.Generic;


namespace GTA.Events
{
    public static class Events
    {
        public static NearbyPedEnteredCoverEvent NearbyPedEnteredCover { get; } = new NearbyPedEnteredCoverEvent();
        public static NearbyPedEnteredVehicleEvent NearbyPedEnteredVehicle { get; } = new NearbyPedEnteredVehicleEvent();
        public static NearbyPedLeftVehicleEvent NearbyPedLeftVehicle { get; } = new NearbyPedLeftVehicleEvent();
        public static NearbyPedFleeingEvent NearbyPedFleeing { get; } = new NearbyPedFleeingEvent();
        public static NearbyPedStartedCombatEvent NearbyPedStartedCombat { get; } = new NearbyPedStartedCombatEvent();
        public static NearbyPedStoppedCombatEvent NearbyPedStoppedCombat { get; } = new NearbyPedStoppedCombatEvent();
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();
        public static PlayerWantedLevelChangedEvent PlayerWantedLevelChanged { get; } = new PlayerWantedLevelChangedEvent();
        public static PlayerWeaponChangedEvent PlayerWeaponChanged { get; } = new PlayerWeaponChangedEvent();
        public static PlayerStartedAimingEvent PlayerStartedAiming { get; } = new PlayerStartedAimingEvent();
        public static PlayerStoppedAimingEvent PlayerStoppedAiming { get; } = new PlayerStoppedAimingEvent();
        public static PlayerAimingAtEvent PlayerAimingAt { get; } = new PlayerAimingAtEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static PlayerVehicleDamagedEvent PlayerVehicleDamaged { get; } = new PlayerVehicleDamagedEvent();
        public static PlayerTookDamageEvent PlayerTookDamage { get; } = new PlayerTookDamageEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
        public static PlayerRevivedEvent PlayerRevived { get; } = new PlayerRevivedEvent();
        public static NearbyVehicleDestroyedEvent NearbyVehicleDestroyed { get; } = new NearbyVehicleDestroyedEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();

        private static readonly List<EventBase> events = new List<EventBase> {
            NearbyPedEnteredCover,
            NearbyPedEnteredVehicle,
            NearbyPedLeftVehicle,
            NearbyPedFleeing,
            NearbyPedStartedCombat,
            NearbyPedStoppedCombat,
            NearbyPedKilled,

            PlayerWantedLevelChanged,
            PlayerWeaponChanged,
            PlayerStartedAiming,
            PlayerStoppedAiming,
            PlayerAimingAt,
            PlayerEnteredVehicle,
            PlayerLeftVehicle,
            PlayerVehicleDamaged,
            PlayerTookDamage,
            PlayerDied,
            PlayerRevived,

            NearbyVehicleDestroyed,
            NearbyExplosion
        };

        public static void OnTick()
        {
            NearbyPedContext.OnTick();

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