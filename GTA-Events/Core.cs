
namespace GTA.Events
{
    public static class Core
    {
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
    
        public static void OnTick()
        {
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

            if (NearbyExplosion != null)
            {
                NearbyExplosion.OnTick();
            }

            if (PlayerDied != null)
            {
                PlayerDied.OnTick();
            }
        }
    }
}