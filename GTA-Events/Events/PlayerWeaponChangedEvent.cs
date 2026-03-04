using System;

namespace GTA.Events
{
    public class PlayerWeaponChangedEvent : EventBase
    {
        public event Action<Weapon, WeaponHash> Connect;

        internal void Invoke(Weapon weapon, WeaponHash weaponHash)
        {
            Connect?.Invoke(weapon, weaponHash);
        }

        private Weapon lastWeapon = Game.Player.Character.Weapons.Current;

        internal override void OnTick()
        {
            Weapon currentWeapon = Game.Player.Character.Weapons.Current;
            if (currentWeapon != lastWeapon)
            {
                Invoke(currentWeapon, currentWeapon.Hash);
            }

            lastWeapon = currentWeapon;
        }

        internal override bool HasSubscribers => Connect != null;
    }
}