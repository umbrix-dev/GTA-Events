using System;

namespace GTA.Events
{
    public class PlayerWeaponFiredEvent : EventBase
    {
        public event Action<Weapon, WeaponHash> Connect;

        internal void Invoke(Weapon weapon, WeaponHash weaponHash) 
        {
            Connect?.Invoke(weapon, weaponHash);
        }

        internal override void OnTick()
        {
            if (Game.Player.Character.IsShooting)
            {
                Weapon currentWeapon = Game.Player.Character.Weapons.Current;
                WeaponHash currentWeaponHash = currentWeapon.Hash;

                Invoke(currentWeapon, currentWeaponHash);
            }
        }

        internal override bool HasSubscribers => Connect != null;
    }
}