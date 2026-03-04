using System;

namespace GTA.Events
{
    public class PlayerLeftWaterEvent : EventBase
    {
        public event Action Connect;

        internal void Invoke()
        {
            Connect?.Invoke();
        }

        internal override void OnTick()
        {
            if (!Game.Player.Character.IsInWater && Game.Player.Character.WasInWater)
            {
                Invoke();
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}