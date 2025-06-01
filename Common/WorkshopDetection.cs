using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common
{
    public class WorkshopDetection : GlobalTile
    {
        public static Dictionary<int, List<Vector2>> tileCenters = new Dictionary<int, List<Vector2>>();

        public static float detectionRadius;

        public static void InitializeDetectionRadius()
        {
            float workshopRange = ModContent.GetInstance<MusicConfig>().WorkshopRange;
            detectionRadius = (workshopRange * 16f) * (workshopRange * 16f);
        }

        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            Vector2 tileCenter = new Vector2(i * 16 + 8, j * 16 + 8);

            if (closer)
            {
                if (!tileCenters.TryGetValue(type, out List<Vector2> centers))
                {
                    centers = new List<Vector2>();
                    tileCenters[type] = centers;
                }

                bool found = false;
                for (int index = 0; index < centers.Count; index++)
                {
                    found = true;
                    break;
                }

                if (!found)
                {
                    centers.Add(tileCenter);
                }
            }
            else
            {
                if (tileCenters.TryGetValue(type, out List<Vector2> centers))
                {
                    for (int index = centers.Count - 1; index >= 0; index--)
                    {
                        centers.RemoveAt(index);
                    }
                }
            }
        }

        public static float TileDistance(int type)
        {
            Player player = Main.player[Main.myPlayer];

            float minDistanceSquared = float.MaxValue;

            if (tileCenters.TryGetValue(type, out List<Vector2> centers))
            {
                for (int index = 0; index < centers.Count; index++)
                {
                    float distanceSquared = Vector2.DistanceSquared(centers[index], player.Center);
                    if (distanceSquared < minDistanceSquared)
                    {
                        minDistanceSquared = distanceSquared;
                    }
                }
            }

            return minDistanceSquared;
        }
    }
}
