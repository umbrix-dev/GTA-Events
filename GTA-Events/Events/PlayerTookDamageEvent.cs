using System;

namespace GTA.Events
{
    public class PlayerTookDamageEvent : EventBase
    {
        public event Action<int> Connect;

        internal void Invoke(int damage)
        {
            Connect?.Invoke(damage);
        }

        private int lastPlayerHealth = Game.Player.Character.Health;

        internal override void OnTick()
        {
            int currentPlayerHealth = Game.Player.Character.Health;
            if (currentPlayerHealth < lastPlayerHealth)
            {
                int damage = lastPlayerHealth - currentPlayerHealth;
                Invoke(damage);
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}