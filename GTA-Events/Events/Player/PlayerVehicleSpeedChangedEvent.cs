using System;

namespace GTA.Events
{
    public class PlayerVehicleSpeedChangedEvent : EventBase
    {
        public event Action<float> Connect;

        internal void Invoke(float speed)
        {
            Connect?.Invoke(speed);
        }

        private float? lastVehicleSpeed = null;

        internal override void OnTick()
        {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
            if (currentVehicle == null)
            {
                return;
            }

            float currentVehicleSpeed = currentVehicle.Speed;
            if (lastVehicleSpeed != null && currentVehicleSpeed != lastVehicleSpeed)
            {
                Invoke(currentVehicleSpeed);
            }

            lastVehicleSpeed = currentVehicleSpeed;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}