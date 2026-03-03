using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;


namespace GTA.Events
{
    public static class Events
    {
        public static NearbyPedKilledEvent NearbyPedKilled { get; } = new NearbyPedKilledEvent();
        public static PlayerEnteredVehicleEvent PlayerEnteredVehicle { get; } = new PlayerEnteredVehicleEvent();
        public static PlayerLeftVehicleEvent PlayerLeftVehicle { get; } = new PlayerLeftVehicleEvent();
        public static NearbyExplosionEvent NearbyExplosion { get; } = new NearbyExplosionEvent();
        public static PlayerDiedEvent PlayerDied { get; } = new PlayerDiedEvent();
    
        public static void OnTick()
        {
            if (NearbyPedKilled != null)
            {
                NearbyPedKilled.OnTick();
            }

            if (PlayerEnteredVehicle != null)
            {
                PlayerEnteredVehicle.OnTick();
            }

            if (PlayerLeftVehicle != null)
            {
                PlayerLeftVehicle.OnTick();
            }

            if (NearbyExplosion != null)
            {
                NearbyExplosion.OnTick();
            }

            if (PlayerDied != null)
            {
                PlayerDied.OnTick();
            }
        }
    }

    public class NearbyPedKilledEvent
    {
        /// <summary>
        /// The position used to check for nearby peds. If null, it will use the player's position.
        /// </summary>
        public Vector3? Position { get; set; } = null;

        /// <summary>
        /// The radius used to check for nearby peds.
        /// </summary>
        public float Radius { get; set; } = 30f;

        public event Action<Ped, Entity> Connect;

        internal void Invoke(Ped ped, Entity entity)
        {
            Connect?.Invoke(ped, entity);
        }

        private readonly HashSet<int> deadPedHandles = new HashSet<int>();

        internal void OnTick()
        {
            foreach (Ped ped in World.GetNearbyPeds(Position ?? Game.Player.Character.Position, Radius))
            {
                if (ped.IsDead && !deadPedHandles.Contains(ped.Handle))
                {
                    Invoke(ped, ped.Killer);
                    deadPedHandles.Add(ped.Handle);
                }
            }
        }
    }
    
    public class PlayerEnteredVehicleEvent
    {
        public event Action<Vehicle> Connect;

        internal void Invoke(Vehicle vehicle)
        {
            Connect?.Invoke(vehicle);
        }

        private Vehicle lastVehicle = null;

        internal void OnTick()
        {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
            
            if (lastVehicle == null && currentVehicle != null)
            {
                Invoke(currentVehicle);
            }

            lastVehicle = currentVehicle;
        }
    }

    public class PlayerLeftVehicleEvent
    {
        public event Action<Vehicle> Connect;

        internal void Invoke(Vehicle vehicle)
        {
            Connect?.Invoke(vehicle);
        }

        private Vehicle lastVehicle = null;

        internal void OnTick()
        {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;

            if (lastVehicle != null && currentVehicle == null)
            {
                Invoke(currentVehicle);
            }

            lastVehicle = currentVehicle;
        }
    }

    public class NearbyExplosionEvent
    {
        /// <summary>
        /// The explosion type to filter for. When set to null it won't apply any filter.
        /// </summary>
        public ExplosionType? Type = null;

        /// <summary>
        /// The position of the area where the radius should be applied. 
        /// Will use players position if set to null.
        /// </summary>
        public Vector3? Position = null;

        /// <summary>
        /// The radius of the area where the explosion will be detected.
        /// </summary>
        public float Radius = 100f;

        public event Action Connect;

        internal void Invoke()
        {
            Connect?.Invoke();
        }

        internal void OnTick()
        {
            var type = Type.HasValue ? (int)Type.Value : -1;
            Vector3 position = Position ?? Game.Player.Character.Position;

            bool isExplosionInArea = Function.Call<bool>(Hash.IS_EXPLOSION_IN_AREA, type,
                position.X - Radius, position.Y - Radius, position.Z - Radius,
                position.X + Radius, position.Y + Radius, position.Z + Radius
            );

            if (isExplosionInArea)
            {
                Invoke();
            }
        }
    }

    public class PlayerDiedEvent
    {
        public event Action<Entity> Connect;

        internal void Invoke(Entity entity)
        {
            Connect?.Invoke(entity);
        }

        private bool alreadyDead = false;

        internal void OnTick()
        {
            if (Game.Player.Character.IsDead && !alreadyDead)
            {
                Invoke(Game.Player.Character.Killer);
                alreadyDead = true;
            }
            else if (!Game.Player.Character.IsDead && alreadyDead)
            {
                alreadyDead = false;
            }
        }
    }
}