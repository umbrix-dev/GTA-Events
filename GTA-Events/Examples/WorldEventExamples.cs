using GTA;
using GTA.Events;
using GTA.UI;
using System;

public class WorldEvents : Script
{
    public WorldEvents()
    {
        Tick += OnTick;

        // Events.NearbyVehicleDestroyed.Connect += OnNearbyVehicleDestroyed;
        // Events.NearbyExplosion.Connect += OnNearbyExplosion;
    }

    private void OnNearbyVehicleDestroyed(Vehicle vehicle)
    {
        Notification.PostTicker("A nearby vehicle was destroyed.", true);
    }

    private void OnNearbyExplosion()
    {
        Notification.PostTicker("An explosion occurred nearby.", true);
    }

    private void OnTick(object sender, EventArgs e)
    {
        Events.OnTick();
    }
}