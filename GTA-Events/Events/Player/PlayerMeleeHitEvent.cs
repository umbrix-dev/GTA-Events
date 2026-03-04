using System;

namespace GTA.Events
{
    public class PlayerMeleeHitEvent : EventBase
    {
        public event Action<Ped> Connect;

        internal void Invoke(Ped ped)
        {
            Connect?.Invoke(ped);
        }

        private int lastTargetHealth = 0;

        internal override void OnTick()
        {
            Ped meleeTarget = Game.Player.Character.MeleeTarget;
            if (meleeTarget == null)
            {
                lastTargetHealth = 0;
                return;
            }

            int currentHealth = meleeTarget.Health;
            if (lastTargetHealth > 0 && currentHealth < lastTargetHealth)
            {
                Invoke(meleeTarget);
            }

            lastTargetHealth = currentHealth;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}