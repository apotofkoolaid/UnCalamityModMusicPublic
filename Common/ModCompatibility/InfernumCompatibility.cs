using Terraria;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.ModCompatibility
{
	public class InfernumCompatibility
    {
        //Infernum has picky code when deciding its music, being altered for if the mode is on for example
        public static int DecideOnMusicPath(string normalPath, string infernumPath)
        {
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernum);
            var infernumModMusic = ModLoader.TryGetMod("InfernumModeMusic", out Mod imusic);

            bool normalPathExists = MusicLoader.MusicExists(UnCalamityModMusic.Instance, "Assets/Music/Bosses/" + normalPath) || MusicLoader.MusicExists(UnCalamityModMusic.Instance, "Assets/Music/Events/" + normalPath);
            bool infernumPathExists;

            if (infernumModMusic)
            {
                infernumPathExists = MusicLoader.MusicExists(imusic, "Sounds/Music/" + infernumPath);
            }
            else
            {
                infernumPathExists = false;
            }

            if (infernumMod)
            {
                if (infernumModMusic && ModContent.GetInstance<MusicConfig>().PrioritizeInfernumMusic && infernumPathExists)
                {
                    if (PlayerFlags.infernumMode && infernumPath.Contains("MoonLord"))
                    {
                        return -1;
                    }
                    else
                    {
                        return MusicLoader.GetMusicSlot(imusic, "Sounds/Music/" + infernumPath);
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
                if (infernumModMusic && ModContent.GetInstance<MusicConfig>().PrioritizeInfernumMusic && infernumPathExists)
                {
                    return MusicLoader.GetMusicSlot(imusic, "Sounds/Music/" + infernumPath);
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
            var infernumModMusic = ModLoader.TryGetMod("InfernumModeMusic", out Mod imusic);

            if (infernumModMusic && !PlayerFlags.bossRushActive)
            {
                return (SceneEffectPriority)12;
            }
            else
            {
                return normalPriority;
            }
        }
    }
    //Fixes a problem where Infernum forces vanilla Dungeon music to play when Ceaseless Void is passive in the Archives
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
                var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
                var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernum);

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
                    if (PlayerFlags.bossRushActive)
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
            var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernum);

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
    //Makes the VCMM Desert theme play in the Lost Colosseum after Argus is defeated, instead of vanilla music
    public class LostColosseum_Aftermath : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("Desert");

        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override float GetWeight(Player player) => 0.97f;

        public override bool IsSceneEffectActive(Player player)
        {
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernum);

            if (infernumMod)
            {
                NPC fakeNPC = new();
                int npcType = infernum.Find<ModNPC>("BereftVassal").Type;
                fakeNPC.SetDefaults(npcType);

                if (!NPC.AnyNPCs(npcType) && Main.BestiaryTracker.Kills.GetKillCount(fakeNPC) > 0)
                {
                    return PlayerFlags.ZoneLostColosseum;
                }
            }

            return false;
        }
    }
}