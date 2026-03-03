using GTA;
using GTA.Events;
using GTA.UI;
using System;

public class PlayerEvents : Script
{
    public PlayerEvents()
    {
        Tick += OnTick;

        Events.PlayerEnteredVehicle.Connect += OnPlayerEnteredVehicle;
        Events.PlayerLeftVehicle.Connect += OnPlayerLeftVehicle;
        Events.PlayerDied.Connect += OnPlayerDied;
        Events.PlayerRevived.Connect += OnPlayerRevived;
        Events.PlayerWantedLevelChanged.Connect += OnPlayerWantedLevelChanged;
        Events.PlayerWeaponChanged.Connect += OnPlayerWeaponChanged;
    }

    private void OnPlayerEnteredVehicle(Vehicle vehicle)
    {
        Notification.PostTicker("Player just entered a vehicle.", true);
    }

    private void OnPlayerLeftVehicle(Vehicle vehicle)
    {
        Notification.PostTicker("Player just left a vehicle.", true);
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

    private void OnPlayerWeaponChanged(WeaponHash weaponHash)
    {
        Notification.PostTicker($"Weapon changed to: {weaponHash}", true);
    }

    private void OnTick(object sender, EventArgs e)
    {
        Events.OnTick();
    }
}