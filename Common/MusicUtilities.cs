using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common
{
    public class MusicUtilities
    {
        public static DateTime? CalamityMusicEvent()
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamitymod))
            {
                Type musicEventType = calamitymod.GetType().Assembly.GetType("CalamityMod.Systems.MusicEventSystem");

                if (musicEventType != null)
                {
                    PropertyInfo trackStartProperty = musicEventType.GetProperty("TrackStart", BindingFlags.Static | BindingFlags.Public);
                    DateTime? trackStartValue = trackStartProperty.GetValue(null) as DateTime?;

                    return trackStartValue;
                }
            }

            return null;
        }

        public static bool CultistsAngered()
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && npc.type == NPCID.CultistTablet && npc.localAI[0] == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool InFrontOfWall(params ushort[] wallTypes)
        {
            foreach (int wallType in wallTypes)
            {
                Player player = Main.player[Main.myPlayer];

                Tile tile = Framing.GetTileSafely((int)(player.Center.X / 16), (int)(player.Center.Y / 16));

                return tile.WallType == wallType;
            }

            return false;
        }

        public static bool NPCNearby(params int[] npcTypes)
        {
            foreach (int npcType in npcTypes)
            {
                double angerFactor = CultistsAngered() ? 2 : 8; // If they're mad, divide range by 2; if tolerant, by 8.
                int npcIndex = NPC.FindFirstNPC(npcType);

                if (npcIndex < 0 || npcIndex >= Main.maxNPCs || !Main.npc[npcIndex].active)
                {
                    continue;
                }

                NPC npc = Main.npc[npcIndex];

                foreach (Player player in Main.player)
                {
                    if (player.active)
                    {
                        if (npcType == NPCID.CultistArcherBlue || npcType == NPCID.CultistTablet || npcType == NPCID.CultistDevote ?
                            npc.Distance(player.Center) <= MusicFlags.BossMusicTileRange / angerFactor :
                            npc.Distance(player.Center) <= MusicFlags.BossMusicTileRange)
                            return true;
                    }
                }
            }

            return false;
        }

        public static bool WorldHeightMeasurement(Player player, out int playerY)
        {
            Point point = player.Center.ToTileCoordinates();

            int y = Main.maxTilesY;

            playerY = point.Y;

            int surfaceHeight = (int)Main.worldSurface / 2 + 90;

            if (MusicFlags.RemixSeed)
            {
                return playerY < surfaceHeight;
            }

            return playerY >= surfaceHeight && playerY <= Main.UnderworldLayer;
        }
    }
}
