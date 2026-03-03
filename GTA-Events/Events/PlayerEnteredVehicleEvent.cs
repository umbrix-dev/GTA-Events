using System;

namespace GTA.Events
{
    public class PlayerEnteredVehicleEvent : EventBase
    {
        public event Action<Vehicle> Connect;

        internal void Invoke(Vehicle vehicle)
        {
            Connect?.Invoke(vehicle);
        }

        private Vehicle lastVehicle = null;

        internal override void OnTick()
        {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;

            if (lastVehicle == null && currentVehicle != null)
            {
                Invoke(currentVehicle);
            }

            lastVehicle = currentVehicle;
        }
    }
}