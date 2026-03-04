using GTA;
using GTA.Events;
using GTA.UI;
using System;

public class PlayerEvents : Script
{
    public PlayerEvents()
    {
        Tick += OnTick;

        // Events.PlayerRagdolled.Connect += OnPlayerRagdolled;
        // Events.PlayerRecoveredFromRagdoll.Connect += OnPlayerRecoveredFromRagdoll;
        // Events.PlayerEnteredVehicle.Connect += OnPlayerEnteredVehicle;
        // Events.PlayerLeftVehicle.Connect += OnPlayerLeftVehicle;
        // Events.PlayerVehicleSpeedChanged.Connect += OnPlayerVehicleSpeedChanged;
        // Events.PlayerVehicleDamaged.Connect += OnPlayerVehicleDamaged;
        // Events.PlayerTookDamage.Connect += OnPlayerTookDamage;
        // Events.PlayerDied.Connect += OnPlayerDied;
        // Events.PlayerRevived.Connect += OnPlayerRevived;
        // Events.PlayerWantedLevelChanged.Connect += OnPlayerWantedLevelChanged;
        // Events.PlayerWeaponChanged.Connect += OnPlayerWeaponChanged;
        // Events.PlayerWeaponFired.Connect += OnPlayerWeaponFired;
        // Events.PlayerStartedAiming.Connect += OnPlayerStartedAiming;
        // Events.PlayerStoppedAiming.Connect += OnPlayerStoppedAiming;
        // Events.PlayerAimingAt.Connect += OnPlayerAimingAt;
        // Events.PlayerMeleeHit.Connect += OnPlayerMeleeHit;
        // Events.PlayerEnteredWater.Connect += OnPlayerEnteredWater;
        // Events.PlayerLeftWater.Connect += OnPlayerLeftWater;
    }

    private void OnPlayerRagdolled()
    {
        Notification.PostTicker("Player just ragdolled.", true);
    }

    private void OnPlayerRecoveredFromRagdoll()
    {
        Notification.PostTicker("Player recovered from ragdoll.", true);
    }

    private void OnPlayerEnteredVehicle(Vehicle vehicle)
    {
        Notification.PostTicker("Player just entered a vehicle.", true);
    }

    private void OnPlayerLeftVehicle(Vehicle vehicle)
    {
        Notification.PostTicker("Player just left a vehicle.", true);
    }

    private void OnPlayerVehicleSpeedChanged(float speed)
    {
        Notification.PostTicker($"Player's vehicle speed has changed: {speed}", true);
    }
    private void OnPlayerVehicleDamaged(Vehicle vehicle)
    {
        Notification.PostTicker("Player's vehicle just got damaged.", true);
    }

    private void OnPlayerTookDamage(int amount)
    {
        Notification.PostTicker($"Player took: {amount} damage.", true);
    }

    private void OnPlayerDied(Entity entity)
    {
        Notification.PostTicker("Player has died.", true);
    }

    private void OnPlayerRevived()
    {
        Notification.PostTicker("Player has been revived.", true);
    }

    private void OnPlayerWantedLevelChanged(int wantedLevel)
    {
        Notification.PostTicker($"Wanted level changed to: {wantedLevel}", true);
    }

    private void OnPlayerWeaponChanged(Weapon weapon, WeaponHash weaponHash)
    {
        Notification.PostTicker($"Weapon changed to: {weaponHash}", true);
    }

    private void OnPlayerWeaponFired(Weapon weapon, WeaponHash weaponHash)
    {
        Notification.PostTicker($"Weapon fired: {weaponHash}", true);
    }

    private void OnPlayerStartedAiming()
    {
        Notification.PostTicker("Player started aiming.", true);
    }

    private void OnPlayerStoppedAiming()
    {
        Notification.PostTicker("Player stopped aiming.", true);
    }

    private void OnPlayerAimingAt(Entity entity)
    {
        Notification.PostTicker("Player is aiming at an entity.", true);
    }

    private void OnPlayerMeleeHit(Ped ped)
    {
        Notification.PostTicker("Player hit an ped using melee.", true);
    }

    private void OnPlayerEnteredWater()
    {
        Notification.PostTicker("Player entered water.", true);
    }

    private void OnPlayerLeftWater()
    {
        Notification.PostTicker("Player left water.", true);
    }

    private void OnTick(object sender, EventArgs e)
    {
        Events.OnTick();
    }
}