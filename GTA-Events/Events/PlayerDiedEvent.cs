using System;

namespace GTA.Events
{
    public class PlayerDiedEvent
    {
        public event Action<Entity> Connect;

        internal void Invoke(Entity entity)
        {
            Connect?.Invoke(entity);
        }

        private bool alreadyDead = false;

        internal void OnTick()
        {
            if (Game.Player.Character.IsDead && !alreadyDead)
            {
                Invoke(Game.Player.Character.Killer);
                alreadyDead = true;
            }
            else if (!Game.Player.Character.IsDead && alreadyDead)
            {
                alreadyDead = false;
            }
        }
    }
}