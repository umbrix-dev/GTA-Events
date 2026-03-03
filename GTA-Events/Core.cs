
namespace GTA.Events
{
    public static class Events
    {
        public static NearbyPedEnteredVehicleEvent NearbyPedEnteredVehicle { get; } = new NearbyPedEnteredVehicleEvent();
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();
    
        public static void OnTick()
        {
            if (NearbyPedEnteredVehicle != null)
            {
                NearbyPedEnteredVehicle.OnTick();
            }

            if (NearbyPedKilled != null)
            {
                NearbyPedKilled.OnTick();
            }

            if (PlayerEnteredVehicle != null)
            {
                PlayerEnteredVehicle.OnTick();
            }

            if (PlayerLeftVehicle != null)
            {
                PlayerLeftVehicle.OnTick();
            }

            if (PlayerDied != null)
            {
                PlayerDied.OnTick();
            }

            if (NearbyExplosion != null)
            {
                NearbyExplosion.OnTick();
            }
        }
    }
}