using GTA.Math;
using System.Collections.Generic;
using static System.Windows.Forms.AxHost;

namespace GTA.Events.Core
{
    internal class PedStateTracker<T>
    {
        private readonly Dictionary<int, T> state = new Dictionary<int, T>();
        private float cleanupTimer = 0.0f;

        internal bool TryGetLast(Ped ped, out T last)
            => state.TryGetValue(ped.Handle, out last);

        internal void Set(Ped ped, T value)
            => state[ped.Handle] = value;

        internal void Cleanup(float deltaTime, Vector3? position, float radius)
        {
            cleanupTimer += deltaTime;
            if (cleanupTimer < 30.0f)
            {
                return;
            }
            cleanupTimer = 0.0f;

            Ped[] nearbyPeds = World.GetNearbyPeds(
                position ?? Game.Player.Character.Position, radius);

            HashSet<int> nearbyHandles = new HashSet<int>();
            foreach (Ped ped in nearbyPeds)
                nearbyHandles.Add(ped.Handle);

            List<int> toRemove = new List<int>();
            foreach (int handle in state.Keys)
                if (!nearbyHandles.Contains(handle)) toRemove.Add(handle);

            foreach (int handle in toRemove)
                state.Remove(handle);
        }
    }
}