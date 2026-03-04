using GTA.Math;
using System;
using System.Collections.Generic;

namespace GTA.Events
{
    internal static class NearbyPedContext
    {
        private static readonly Dictionary<(Vector3? position, float radius), List<Action<Ped>>> loops
            = new Dictionary<(Vector3? position, float radius), List<Action<Ped>>>();

        internal static void Register(Action<Ped> handler, Vector3? position, float radius)
        {
            var key = (position, radius);
            if (!loops.ContainsKey(key))
            {
                loops[key] = new List<Action<Ped>>();
            }
            loops[key].Add(handler);
        }

        internal static void Deregister(Action<Ped> handler, Vector3? position, float radius)
        {
            var key = (position, radius);
            if (loops.ContainsKey(key))
            {
                loops[key].Remove(handler);
                if (loops[key].Count == 0)
                {
                    loops.Remove(key);
                }
            }
        }

        internal static void OnTick()
        {
            foreach (var loop in loops)
            {
                Vector3 position = loop.Key.position ?? Game.Player.Character.Position;

                foreach (Ped ped in World.GetNearbyPeds(position, loop.Key.radius))
                {
                    if (ped == Game.Player.Character)
                    {
                        continue;
                    }

                    foreach (Action<Ped> handler in loop.Value)
                    {
                        handler(ped);
                    }
                }
            }
        }
    }
}