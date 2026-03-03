using GTA;
using GTA.Math;

/// <summary>
/// The base class for all events that have to get nearby peds.
/// </summary>
public abstract class NearbyPedEventBase : EventBase
{
    /// <summary>
    /// The position used to check for nearby peds. If null, it will use the player's position.
    /// </summary>
    public Vector3? Position { get; set; } = null;

    /// <summary>
    /// The radius used to check for nearby peds.
    /// </summary>
    public float Radius { get; set; } = 30f;

    protected Ped[] GetNearbyPeds()
    {
        return World.GetNearbyPeds(Position ?? Game.Player.Character.Position, Radius);
    }
}