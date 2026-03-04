using System.Collections.Generic;


namespace GTA.Events
{
    public static class Events
    {
        public static NearbyPedEnteredCoverEvent NearbyPedEnteredCover { get; } = new NearbyPedEnteredCoverEvent();
        public static NearbyPedLeftCoverEvent NearbyPedLeftCover { get; } = new NearbyPedLeftCoverEvent();
        public static NearbyPedEnteredVehicleEvent NearbyPedEnteredVehicle { get; } = new NearbyPedEnteredVehicleEvent();
        public static NearbyPedLeftVehicleEvent NearbyPedLeftVehicle { get; } = new NearbyPedLeftVehicleEvent();
        public static NearbyPedFleeingEvent NearbyPedFleeing { get; } = new NearbyPedFleeingEvent();
        public static NearbyPedStartedCombatEvent NearbyPedStartedCombat { get; } = new NearbyPedStartedCombatEvent();
        public static NearbyPedStoppedCombatEvent NearbyPedStoppedCombat { get; } = new NearbyPedStoppedCombatEvent();
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();

        public static PlayerWantedLevelChangedEvent PlayerWantedLevelChanged { get; } = new PlayerWantedLevelChangedEvent();
        public static PlayerWeaponChangedEvent PlayerWeaponChanged { get; } = new PlayerWeaponChangedEvent();
        public static PlayerWeaponFiredEvent PlayerWeaponFired { get; } = new PlayerWeaponFiredEvent();
        public static PlayerStartedAimingEvent PlayerStartedAiming { get; } = new PlayerStartedAimingEvent();
        public static PlayerStoppedAimingEvent PlayerStoppedAiming { get; } = new PlayerStoppedAimingEvent();
        public static PlayerAimingAtEvent PlayerAimingAt { get; } = new PlayerAimingAtEvent();
        public static PlayerMeleeHitEvent PlayerMeleeHit { get; } = new PlayerMeleeHitEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static PlayerVehicleSpeedChangedEvent PlayerVehicleSpeedChanged { get; } = new PlayerVehicleSpeedChangedEvent();
        public static PlayerVehicleDamagedEvent PlayerVehicleDamaged { get; } = new PlayerVehicleDamagedEvent();
        public static PlayerTookDamageEvent PlayerTookDamage { get; } = new PlayerTookDamageEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
        public static PlayerRevivedEvent PlayerRevived { get; } = new PlayerRevivedEvent();

        public static NearbyVehicleDestroyedEvent NearbyVehicleDestroyed { get; } = new NearbyVehicleDestroyedEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();

        private static readonly List<EventBase> events = new List<EventBase> {
            NearbyPedEnteredCover,
            NearbyPedLeftCover,
            NearbyPedEnteredVehicle,
            NearbyPedLeftVehicle,
            NearbyPedFleeing,
            NearbyPedStartedCombat,
            NearbyPedStoppedCombat,
            NearbyPedKilled,

            PlayerWantedLevelChanged,
            PlayerWeaponChanged,
            PlayerWeaponFired,
            PlayerStartedAiming,
            PlayerStoppedAiming,
            PlayerAimingAt,
            PlayerMeleeHit,
            PlayerEnteredVehicle,
            PlayerLeftVehicle,
            PlayerVehicleSpeedChanged,
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