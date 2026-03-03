
using System;

namespace GTA.Events
{
    public class PlayerWeaponChangedEvent : EventBase
    {
        public event Action<WeaponHash> Connect;

        internal void Invoke(WeaponHash weaponHash)
        {
            Connect?.Invoke(weaponHash);
        }

        private Weapon lastWeapon = Game.Player.Character.Weapons.Current;

        internal override void OnTick()
        {
            Weapon currentWeapon = Game.Player.Character.Weapons.Current;
            if (currentWeapon != lastWeapon)
            {
                Invoke(currentWeapon.Hash);
            }

            lastWeapon = currentWeapon;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}