using System;

namespace GTA.Events
{
    public class PlayerRecoveredFromRagdollEvent : EventBase
    {
        public event Action Connect;

        internal void Invoke()
        {
            Connect?.Invoke();
        }

        private bool wasRagdolled = Game.Player.Character.IsRagdoll;

        internal override void OnTick()
        {
            bool currentlyRagdolled = Game.Player.Character.IsRagdoll;
            if (!currentlyRagdolled && wasRagdolled)
            {
                Invoke();
            }

            wasRagdolled = currentlyRagdolled;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}