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

        private float? lastVehicleHealth = null;

        internal override void OnTick()
        {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
            if (currentVehicle == null)
            {
                return;
            }

            if (lastVehicleHealth != null && currentVehicle.HealthFloat != lastVehicleHealth)
            {
                Invoke(currentVehicle);    
            }

            lastVehicleHealth = currentVehicle.HealthFloat;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}