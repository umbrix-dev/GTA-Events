
using System;

namespace GTA.Events
{
    public class PlayerRevivedEvent : EventBase
    {
        public event Action Connect;

        internal void Invoke()
        {
            Connect?.Invoke();
        }

        private bool wasDead = false;

        internal override void OnTick()
        {
            if (Game.Player.IsAlive && wasDead)
            {
                Invoke();
                wasDead = false;
            }
            else if (Game.Player.IsDead)
            {
                wasDead = true;
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}