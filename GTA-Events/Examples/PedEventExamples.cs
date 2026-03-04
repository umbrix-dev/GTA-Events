using GTA;
using GTA.Events;
using GTA.UI;
using System;

public class PedEvents : Script
{
    public PedEvents()
    {
        Tick += OnTick;

        // Events.NearbyPedEnteredVehicle.Connect += OnNearbyPedEnteredVehicle;
        // Events.NearbyPedLeftVehicle.Connect += OnNearbyPedLeftVehicle;
        // Events.NearbyPedFleeing.Connect += OnNearbyPedFleeing;
        // Events.NearbyPedStartedCombat.Connect += OnNearbyPedStartedCombat;
        // Events.NearbyPedKilled.Connect += OnNearbyPedKilled;
    }

    private void OnNearbyPedEnteredVehicle(Ped ped, Vehicle vehicle)
    {
        Notification.PostTicker("A nearby ped has entered a vehicle.", true);
    }

    private void OnNearbyPedLeftVehicle(Ped ped, Vehicle vehicle)
    {
        Notification.PostTicker("A nearby ped has left their vehicle.", true);
    }

    private void OnNearbyPedFleeing(Ped ped)
    {
        Notification.PostTicker("A nearby ped is fleeing.", true);
    }

    private void OnNearbyPedStartedCombat(Ped ped, Entity entity)
    {
        Notification.PostTicker("A nearby ped has started combat.", true);
    }

    private void OnNearbyPedKilled(Ped ped, Entity entity)
    {
        Notification.PostTicker("A nearby ped has been killed.", true);
    }

    private void OnTick(object sender, EventArgs e)
    {
        Events.OnTick();
    }
}