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
        Events.NearbyPedEnteredVehicle.Connect += OnNearbyPedEnteredVehicle;
        // Events.NearbyPedKilled.Connect += OnNearbyPedKilled;
        // Events.PlayerEnteredVehicle.Connect += OnPlayerEnteredVehicle;
        // Events.PlayerLeftVehicle.Connect += OnPlayerLeftVehicle;
        // Events.PlayerDied.Connect += OnPlayerDied;
        // Events.NearbyExplosion.Connect += OnNearbyExplosion;
    }

    private void OnNearbyPedEnteredVehicle(Ped ped, Vehicle vehicle)
    {
        Notify("A nearby ped has entered a vehicle.");
    }

    private void OnNearbyPedKilled(Ped ped, Entity entity)
    {
        Notify("A nearby ped has been killed.");
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
