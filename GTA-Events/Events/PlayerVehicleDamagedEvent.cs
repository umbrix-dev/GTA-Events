using System;

namespace GTA.Events
{
    public class PlayerVehicleDamagedEvent : EventBase
    {
        public event Action<Vehicle> Connect;

        internal void Invoke(Vehicle vehicle)
        {
            Connect?.Invoke(vehicle);
        }

        private int? lastVehicleHealth = null;

        internal override void OnTick()
        {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
            if (currentVehicle == null)
            {
                return;
            }

            if (lastVehicleHealth != null && currentVehicle.Health != lastVehicleHealth)
            {
                Invoke(currentVehicle);    
            }

            lastVehicleHealth = currentVehicle.Health;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}