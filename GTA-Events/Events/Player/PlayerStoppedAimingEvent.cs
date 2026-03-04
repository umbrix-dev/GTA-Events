using GTA.Native;
using System;

namespace GTA.Events
{
    public class PlayerStoppedAimingEvent : EventBase
    {
        public event Action Connect;

        internal void Invoke()
        {
            Connect?.Invoke();
        }

        private bool lastAimingStatus = Game.Player.Character.IsAiming 
            || Game.Player.Character.IsAimingFromCover;

        internal override void OnTick()
        {
            bool currentAimingStatus = Game.Player.Character.IsAiming
                || Game.Player.Character.IsAimingFromCover;
            
            if (!currentAimingStatus && lastAimingStatus)
            {
                Invoke();
            }

            lastAimingStatus = currentAimingStatus;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}