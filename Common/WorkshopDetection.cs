using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common
{
    public class WorkshopDetection : GlobalTile
    {
        internal static Dictionary<int, List<Vector2>> tileCenters = [];

        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            Vector2 tileCenter = new(i * 16 + 8, j * 16 + 8);

            if (closer)
            {
                if (!tileCenters.TryGetValue(type, out List<Vector2> centers))
                {
                    centers = [];
                    tileCenters[type] = centers;
                }
                centers.Add(tileCenter);
            }
            else
            {
                tileCenters.Clear();
            }
        }

        public static float TileDistance(params int[] tileTypes)
        {
            Player player = Main.player[Main.myPlayer];
            float closestDistance = float.MaxValue;

            foreach (int type in tileTypes)
            {
                if (tileCenters.TryGetValue(type, out List<Vector2> centers))
                {
                    foreach (Vector2 center in centers)
                    {
                        float distance = Vector2.DistanceSquared(center, player.Center);

                        if (distance <= closestDistance)
                        {
                            closestDistance = distance;
                        }
                    }
                }
            }

            return closestDistance;
        }

        public static float TileDistance(List<int> list, params int[] tileTypes)
        {
            return TileDistance(list.Concat(tileTypes).ToArray());
        }
    }
}
