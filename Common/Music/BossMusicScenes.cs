using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.ModCompatibility;

namespace UnCalamityModMusic.Common.Music
{
    public class FalseEpilogue : ModSystem
    {
        public int FalseEpilogueMusicSlot = 0;

        public override void OnWorldLoad()
        {
            FalseEpilogueMusicSlot = MusicPathing.GetMusicSlot("FalseEpilogue");
        }

        public override void UpdateUI(GameTime gameTime)
        {
            Player player = Main.player[Main.myPlayer];

            if (CreditsRollEvent.IsEventOngoing && !player.hasCreditsSceneMusicBox && PlayerFlags.CalamityMusicEventInactive)
            {
                Main.musicBox2 = FalseEpilogueMusicSlot;
                return;
            }
        }
    }
    public class MoonLord : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("MoonLord", "MoonLord");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossHigh);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.MoonLordCore) && Main.npc[NPC.FindFirstNPC(NPCID.MoonLordCore)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class ImpendingDoom : ModSceneEffect
	{
        /*public override int Music => MusicPathing.GetMusicSlot("ImpendingDoom");

		public override SceneEffectPriority Priority => SceneEffectPriority.Event + 1;

		public override bool IsSceneEffectActive(Player player)
		{
			return BossCountdowns.ImpendingDoomCountdown > 0 || NPC.MoonLordCountdown > 0;
		}

		public override void SpecialVisuals(Player player, bool isActive)
		{
			if (NPC.MoonLordCountdown > 3540)
			{
				Main.musicFade[Main.curMusic] = 1f;
			}
		}*/
    }
    public class LunaticCultist : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("LunaticCultist", "LunaticCultist");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.CultistBoss) && Main.npc[NPC.FindFirstNPC(NPCID.CultistBoss)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class CultistRitual : ModSceneEffect
	{
		/*public bool AreTheyMad
		{
			get
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
		}

        public override int Music => MusicPathing.GetMusicSlot("CultistRitual");

		public override SceneEffectPriority Priority => AreTheyMad ? SceneEffectPriority.BossLow : SceneEffectPriority.Environment + 1;

		public override bool IsSceneEffectActive(Player player)
		{
			double angerFactor = AreTheyMad ? 2.5 : 5;

            bool condition1 = NPC.AnyNPCs(NPCID.CultistTablet) && Main.npc[NPC.FindFirstNPC(NPCID.CultistTablet)].Distance(player.Center) <= PlayerFlags.MusicTileRange / angerFactor;
            bool condition2 = NPC.AnyNPCs(NPCID.CultistDevote) && Main.npc[NPC.FindFirstNPC(NPCID.CultistDevote)].Distance(player.Center) <= PlayerFlags.MusicTileRange / angerFactor;
            bool condition3 = NPC.AnyNPCs(NPCID.CultistArcherBlue) && Main.npc[NPC.FindFirstNPC(NPCID.CultistArcherBlue)].Distance(player.Center) <= PlayerFlags.MusicTileRange / angerFactor;

            return (condition1 || condition2 || condition3) && !BossDetection.AreThereAnyBosses;
        }*/
	}
	public class EmpressofLight : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("EmpressofLight", "EmpressOfLight");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.HallowBoss) && Main.npc[NPC.FindFirstNPC(NPCID.HallowBoss)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class DukeFishron : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("DukeFishron", "DukeFishron");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.DukeFishron) && Main.npc[NPC.FindFirstNPC(NPCID.DukeFishron)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class Golem : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Golem", "Golem");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.Golem) && Main.npc[NPC.FindFirstNPC(NPCID.Golem)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class Plantera : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Plantera", "Plantera");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossMedium);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.Plantera) && Main.npc[NPC.FindFirstNPC(NPCID.Plantera)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class Mechs : ModSceneEffect
	{
		public static bool AllMechsActive = false;

		public override int Music => InfernumCompatibility.DecideOnMusicPath("Mechs", "MechBosses");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossMedium);

		public override bool IsSceneEffectActive(Player player)
		{
			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);

			bool spazmatismActive = NPC.AnyNPCs(NPCID.Spazmatism) && Main.npc[NPC.FindFirstNPC(NPCID.Spazmatism)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool retinazerActive = NPC.AnyNPCs(NPCID.Retinazer) && Main.npc[NPC.FindFirstNPC(NPCID.Retinazer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
            bool destroyerHeadActive = NPC.AnyNPCs(NPCID.TheDestroyer) && Main.npc[NPC.FindFirstNPC(NPCID.TheDestroyer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool destroyerBodyActive = NPC.AnyNPCs(NPCID.TheDestroyerBody) && Main.npc[NPC.FindFirstNPC(NPCID.TheDestroyerBody)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool destroyerTailActive = NPC.AnyNPCs(NPCID.TheDestroyerTail) && Main.npc[NPC.FindFirstNPC(NPCID.TheDestroyerTail)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool skeletronPrimeActive = NPC.AnyNPCs(NPCID.SkeletronPrime) && Main.npc[NPC.FindFirstNPC(NPCID.SkeletronPrime)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			bool twinsActive = spazmatismActive || retinazerActive;
			bool destroyerActive = destroyerHeadActive || destroyerBodyActive || destroyerTailActive;

			if (destroyerActive && twinsActive && skeletronPrimeActive)
            {
				AllMechsActive = true;
			}
			else if (!destroyerActive && !twinsActive && !skeletronPrimeActive)
			{
				AllMechsActive = false;
			}

			bool condition1 = AllMechsActive && skeletronPrimeActive;
			bool condition2 = AllMechsActive && twinsActive;
			bool condition3 = AllMechsActive && destroyerActive;

			return condition1 || condition2 || condition3;
		}
	}
	public class SkeletronPrime : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("SkeletronPrime", "MechBosses");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.SkeletronPrime) && Main.npc[NPC.FindFirstNPC(NPCID.SkeletronPrime)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class Twins : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Twins", "MechBosses");

        public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = NPC.AnyNPCs(NPCID.Spazmatism) && Main.npc[NPC.FindFirstNPC(NPCID.Spazmatism)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition2 = NPC.AnyNPCs(NPCID.Retinazer) && Main.npc[NPC.FindFirstNPC(NPCID.Retinazer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

            return condition1 || condition2;
		}
	}
	public class Destroyer : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Destroyer", "MechBosses");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = NPC.AnyNPCs(NPCID.TheDestroyer) && Main.npc[NPC.FindFirstNPC(NPCID.TheDestroyer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition2 = NPC.AnyNPCs(NPCID.TheDestroyerBody) && Main.npc[NPC.FindFirstNPC(NPCID.TheDestroyerBody)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = NPC.AnyNPCs(NPCID.TheDestroyerTail) && Main.npc[NPC.FindFirstNPC(NPCID.TheDestroyerTail)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3;
		}
	}
	public class MechEngaging : ModSceneEffect
	{
        /*public override int Music => MusicPathing.GetMusicSlot("MechEngaging");

		public override SceneEffectPriority Priority => SceneEffectPriority.Event + 1;

		public override bool IsSceneEffectActive(Player player)
		{
			return BossCountdowns.MechCountdown > 0;
		}*/
    }
    public class QueenSlime : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("QueenSlime", "QueenSlime");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.QueenSlimeBoss) && Main.npc[NPC.FindFirstNPC(NPCID.QueenSlimeBoss)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class Dreadnautilus : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("BloodMoonDeath", "Dreadnautilus");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.BloodNautilus) && Main.npc[NPC.FindFirstNPC(NPCID.BloodNautilus)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class WallofFlesh : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("WallofFlesh", "WallOfFlesh");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = NPC.AnyNPCs(NPCID.WallofFlesh) && Main.npc[NPC.FindFirstNPC(NPCID.WallofFlesh)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition2 = NPC.AnyNPCs(NPCID.WallofFleshEye) && Main.npc[NPC.FindFirstNPC(NPCID.WallofFleshEye)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2;
		}
	}
	public class Skeletron : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Skeletron", "Skeletron");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.SkeletronHead) && Main.npc[NPC.FindFirstNPC(NPCID.SkeletronHead)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
    public class Deerclops : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("Deerclops");

		public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.Deerclops) && Main.npc[NPC.FindFirstNPC(NPCID.Deerclops)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}*/
    }
    public class QueenBee : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("QueenBee", "QueenBee");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.QueenBee) && Main.npc[NPC.FindFirstNPC(NPCID.QueenBee)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class BrainofCthulhu : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("BrainofCthulhu", "BrainOfCthulhu");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.BrainofCthulhu) && Main.npc[NPC.FindFirstNPC(NPCID.BrainofCthulhu)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class EaterofWorlds : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("EaterofWorlds", "EaterOfWorlds");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);
		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = NPC.AnyNPCs(NPCID.EaterofWorldsHead) && Main.npc[NPC.FindFirstNPC(NPCID.EaterofWorldsHead)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition2 = NPC.AnyNPCs(NPCID.EaterofWorldsBody) && Main.npc[NPC.FindFirstNPC(NPCID.EaterofWorldsBody)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = NPC.AnyNPCs(NPCID.EaterofWorldsTail) && Main.npc[NPC.FindFirstNPC(NPCID.EaterofWorldsTail)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3;
		}
	}
	public class EyeofCthulhu : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("EyeofCthulhu", "EyeOfCthulhu");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.EyeofCthulhu) && Main.npc[NPC.FindFirstNPC(NPCID.EyeofCthulhu)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
	public class KingSlime : ModSceneEffect
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("KingSlime", "KingSlime");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool IsSceneEffectActive(Player player)
		{
			return NPC.AnyNPCs(NPCID.KingSlime) && Main.npc[NPC.FindFirstNPC(NPCID.KingSlime)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
		}
	}
}
