using Terraria;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.ModCompatibility
{
	public class InfernumCompatibility
    {
        // Infernum music uses music priority higher than what vanilla defines. VCMM needs to account for this to achieve expected behavior between both mods.
        public static int DecideOnMusicPath(string normalPath, string infernumPath)
        {
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernummod);
            var infernumModMusic = ModLoader.TryGetMod("InfernumModeMusic", out Mod infernummusic);

            bool normalPathExists = MusicLoader.MusicExists(UnCalamityModMusic.Instance, "Assets/Music/Bosses/" + normalPath) || MusicLoader.MusicExists(UnCalamityModMusic.Instance, "Assets/Music/Events/" + normalPath);
            bool infernumPathExists;
            bool infernumMusicConfigActive;

            string infernumMusicConfigPath;

            if (infernumModMusic)
            {
                infernumPathExists = MusicLoader.MusicExists(infernummusic, "Sounds/Music/" + infernumPath);
                infernumMusicConfigPath = infernumPath.Contains("MechBosses") ? normalPath : infernumPath;
                infernumMusicConfigActive = infernumPathExists && (bool)infernummusic.Call("Override" + infernumMusicConfigPath + "Theme");
            }
            else
            {
                infernumPathExists = false;
                infernumMusicConfigPath = string.Empty;
                infernumMusicConfigActive = false;
            }

            if (infernumMod)
            {
                if (infernumModMusic && ModContent.GetInstance<MusicConfig>().PrioritizeMusicFromOtherMods && infernumPathExists && infernumMusicConfigActive)
                {
                    if (MusicFlags.InfernumMode)
                    {
                        return -1;
                    }
                    else
                    {
                        return MusicLoader.GetMusicSlot(infernummusic, "Sounds/Music/" + infernumPath);
                    }
                }
                else
                {
                    if (normalPathExists)
                    {
                        return MusicPathing.GetMusicSlot(normalPath);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                if (infernumModMusic && ModContent.GetInstance<MusicConfig>().PrioritizeMusicFromOtherMods && infernumPathExists && infernumMusicConfigActive)
                {
                    return MusicLoader.GetMusicSlot(infernummusic, "Sounds/Music/" + infernumPath);
                }
                else
                {
                    if (normalPathExists)
                    {
                        return MusicPathing.GetMusicSlot(normalPath);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public static SceneEffectPriority DecideOnScenePriority(SceneEffectPriority normalPriority)
        {
            var infernumModMusic = ModLoader.TryGetMod("InfernumModeMusic", out Mod infernummusic);

            if (infernumModMusic && !MusicFlags.BossRush)
            {
                return (SceneEffectPriority)13;
            }
            else
            {
                return normalPriority;
            }
        }
    }

    // Fixes a problem where Infernum forces vanilla Dungeon music to play when Ceaseless Void is passive in the Archives.
    [JITWhenModsEnabled("CalamityMod")]
    public class CeaselessVoid_Passive : ModSceneEffect
    {
        public static int voidBoss => CalamityMod.NPCs.CalamityGlobalNPC.voidBoss;

        public static int ghostBoss => CalamityMod.NPCs.CalamityGlobalNPC.ghostBoss;

        public override int Music => MusicPathing.GetMusicSlot("Dungeon");

        public override SceneEffectPriority Priority
        {
            get
            {
                var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamitymod);
                var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernummod);

                if (calamityMod && infernumMod)
                {
                    if (ghostBoss >= 0 && ghostBoss < Main.npc.Length)
                    {
                        NPC polterghast = Main.npc[ghostBoss];

                        if (polterghast != null)
                        {
                            return SceneEffectPriority.BossLow;
                        }
                    }
                    if (MusicFlags.BossRush)
                    {
                        return SceneEffectPriority.BossLow;
                    }

                    return (SceneEffectPriority)9;
                }

                return SceneEffectPriority.None;
            }
        }

        public override float GetWeight(Player player) => 0.51f;

        public override bool IsSceneEffectActive(Player player)
        {
            var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamitymod);
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernummod);

            if (calamityMod && infernumMod)
            {
                if (voidBoss >= 0 && voidBoss < Main.npc.Length)
                {
                    NPC ceaselessVoid = Main.npc[voidBoss];

                    if (ceaselessVoid != null && ceaselessVoid.active)
                    {
                        return ceaselessVoid.ai[0] == 0f;
                    }
                }
            }

            return false;
        }
    }

    // Makes the VCMM Desert theme play in the Lost Colosseum after Argus is defeated, instead of vanilla music.
    public class LostColosseum_Aftermath : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("Desert");

        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override float GetWeight(Player player) => 0.97f;

        public override bool IsSceneEffectActive(Player player)
        {
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernummod);

            if (infernumMod)
            {
                NPC fakeNPC = new();
                int npcType = infernummod.Find<ModNPC>("BereftVassal").Type;
                fakeNPC.SetDefaults(npcType);

                if (!NPC.AnyNPCs(npcType) && Main.BestiaryTracker.Kills.GetKillCount(fakeNPC) > 0)
                {
                    return MusicFlags.LostColosseum;
                }
            }

            return false;
        }
    }
}