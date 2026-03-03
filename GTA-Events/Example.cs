using GTA;
using GTA.Events;
using GTA.UI;
using System;

public class Example : Script
{
    public Example()
    {
        Tick += OnTick;

        SetupEvents();
    }
    
    private void SetupEvents()
    {
        // Events.NearbyPedEnteredVehicle.Connect += OnNearbyPedEnteredVehicle;
        // Events.NearbyPedLeftVehicle.Connect += OnNearbyPedLeftVehicle;
        // Events.NearbyPedFleeing.Connect += OnNearbyPedFleeing;
        // Events.NearbyPedKilled.Connect += OnNearbyPedKilled;
        // Events.PlayerWantedLevelChanged.Connect += OnPlayerWantedLevelChanged;
        // Events.PlayerWeaponChanged.Connect += OnPlayerWeaponChanged;
        // Events.PlayerEnteredVehicle.Connect += OnPlayerEnteredVehicle;
        // Events.PlayerLeftVehicle.Connect += OnPlayerLeftVehicle;
        // Events.PlayerDied.Connect += OnPlayerDied;
        // Events.PlayerRevived.Connect += OnPlayerRevived;
        // Events.NearbyVehicleDestroyed.Connect += OnNearbyVehicleDestroyed;
        // Events.NearbyExplosion.Connect += OnNearbyExplosion;
    }

    private void OnNearbyPedEnteredVehicle(Ped ped, Vehicle vehicle)
    {
        Notify("A nearby ped has entered a vehicle.");
    }

    private void OnNearbyPedLeftVehicle(Ped ped, Vehicle vehicle)
    {
        Notify("A nearby ped has left their vehicle.");
    }

    private void OnNearbyPedFleeing(Ped ped)
    {
        Notify("A nearby ped is fleeing.");
    }

    private void OnNearbyPedKilled(Ped ped, Entity entity)
    {
        Notify("A nearby ped has been killed.");
    }

    private void OnPlayerWantedLevelChanged(int wantedLevel)
    {
        Notify($"The players wanted level has changed to: {wantedLevel}");
    }

    private void OnPlayerWeaponChanged(WeaponHash weaponHash)
    {
        Notify($"The players current weapon has changed to: {weaponHash.ToString()}");
    }

    private void OnPlayerEnteredVehicle(Vehicle vehicle)
    {
        Notify("Player just entered a vehicle");
    }

    private void OnPlayerLeftVehicle(Vehicle vehicle)
    {
        Notify("Player just left a vehicle.");
    }

    private void OnPlayerDied(Entity entity)
    {
        Notify("Player has died.");
    }

    private void OnPlayerRevived()
    {
        Notify("Player has been revived.");
    }

    private void OnNearbyVehicleDestroyed(Vehicle vehicle)
    {
        Notify($"Nearby vehicle just got destroyed.");
    }

    private void OnNearbyExplosion()
    {
        Notify("An explosion has occured nearby.");
    }

    private void Notify(string message, bool important = true)
    {
        Notification.PostTicker(message, important);
    }

    private void OnTick(object sender, EventArgs e)
    {
        Events.OnTick();
    }
}
