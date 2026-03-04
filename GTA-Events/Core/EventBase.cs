
/// <summary>
/// The base class for all events.
/// </summary>
public abstract class EventBase
{
    // Invoke() is not defined here because every class can
    // have different parameters which means fighting
    // against the type system constantly

    internal abstract bool HasSubscribers { get; }
    internal abstract void OnTick();
}