using GTA;
using GTA.Math;

namespace GTA.Events
{
    /// <summary>
    /// The base class for all events that have to get nearby peds.
    /// </summary>
    public abstract class NearbyPedEventBase : EventBase
    {
        private Vector3? _position = null;
        private float _radius = 30f;

        /// <summary>
        /// The position used to check for nearby peds. If null, it will use the player's position.
        /// </summary>
        public Vector3? Position
        {
            get => _position;
            set
            {
                NearbyPedContext.Deregister(OnPed, _position, _radius);
                _position = value;
                NearbyPedContext.Register(OnPed, _position, _radius);
            }
        }

        /// <summary>
        /// The radius used to check for nearby peds.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set
            {
                NearbyPedContext.Deregister(OnPed, _position, _radius);
                _radius = value;
                NearbyPedContext.Register(OnPed, _position, _radius);
            }
        }

        protected NearbyPedEventBase()
        {
            NearbyPedContext.Register(OnPed, _position, _radius);
        }

        internal abstract void OnPed(Ped ped);

        internal override void OnTick() { }
    }
}