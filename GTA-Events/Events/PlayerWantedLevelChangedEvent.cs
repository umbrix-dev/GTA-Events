using System;

namespace GTA.Events
{
    public class PlayerWantedLevelChangedEvent : EventBase
    {
        public event Action<int> Connect;

        internal void Invoke(int wantedLevel)
        {
            Connect?.Invoke(wantedLevel);
        }

        private int lastWantedLevel = Game.Player.Wanted.WantedLevel;

        internal override void OnTick()
        {
            int currentWantedLevel = Game.Player.Wanted.WantedLevel;
            if (currentWantedLevel != lastWantedLevel)
            {
                Invoke(currentWantedLevel);
            }

            lastWantedLevel = currentWantedLevel;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}