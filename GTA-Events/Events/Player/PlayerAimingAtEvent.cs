using GTA.Native;
using System;

namespace GTA.Events
{
    public class PlayerAimingAtEvent : EventBase
    {
        /// <summary>
        /// The entity to filter for. Fires for any entity if null.
        /// </summary>
        public Entity Target { get; set; } = null;

        public event Action<Entity> Connect;

        internal void Invoke(Entity entity)
        {
            Connect?.Invoke(entity);
        }

        internal override void OnTick()
        {
            if (!Game.Player.Character.IsAiming
                && !Game.Player.Character.IsAimingFromCover)
            {
                return;
            }

            OutputArgument pointerEntity = new OutputArgument();
            bool isAimingAtEntity = Function.Call<bool>(
                Hash.GET_ENTITY_PLAYER_IS_FREE_AIMING_AT,
                Game.Player, pointerEntity);

            if (!isAimingAtEntity)
            {
                return;
            }

            Entity targetEntity = pointerEntity.GetResult<Entity>();
            if (Target != null && Target != targetEntity)
            {
                return;
            }

            Invoke(targetEntity);
        }

        internal override bool HasSubscribers => Connect != null;
    }
}