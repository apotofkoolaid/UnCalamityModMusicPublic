using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.ModCompatibility;

namespace UnCalamityModMusic.Common.Music
{
    public class MoonLord : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("MoonLord", "MoonLord");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossHigh);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.MoonLordCore);
    }

	public class LunaticCultist : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("LunaticCultist", "LunaticCultist");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.CultistBoss);
    }

	public class EmpressofLight : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("EmpressofLight", "EmpressOfLight");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.HallowBoss);
    }

	public class DukeFishron : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("DukeFishron", "DukeFishron");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.DukeFishron);
    }

	public class Golem : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Golem", "Golem");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.Golem);
    }

	public class Plantera : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Plantera", "Plantera");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossMedium);

		public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.Plantera);
    }

	public class Mechs : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Mechs", "MechBosses");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossMedium);

		public override bool MusicCondition(Player player) => MusicFlags.SimultaneousMechs;
    }

	public class SkeletronPrime : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("SkeletronPrime", "MechBosses");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.SkeletronPrime);
    }

	public class Twins : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Twins", "MechBosses");

        public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.Spazmatism, NPCID.Retinazer);
    }

	public class Destroyer : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Destroyer", "MechBosses");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail);
    }

	public class QueenSlime : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("QueenSlime", "QueenSlime");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.QueenSlimeBoss);
    }

	public class Dreadnautilus : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("BloodMoonDeath", "Dreadnautilus");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.BloodNautilus);
    }

	public class WallofFlesh : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("WallofFlesh", "WallOfFlesh");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.WallofFlesh, NPCID.WallofFleshEye);
	}

	public class Skeletron : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("Skeletron", "Skeletron");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.SkeletronHead);
    }

    public class Deerclops : MusicSceneBase
    {
        /*public override string MusicFilePath => "Deerclops";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

		public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.Deerclops);*/
    }

    public class QueenBee : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("QueenBee", "QueenBee");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.QueenBee);
    }

	public class BrainofCthulhu : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("BrainofCthulhu", "BrainOfCthulhu");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

        public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.BrainofCthulhu);
    }

	public class EaterofWorlds : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("EaterofWorlds", "EaterOfWorlds");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail);
	}

	public class EyeofCthulhu : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("EyeofCthulhu", "EyeOfCthulhu");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.EyeofCthulhu);
	}

	public class KingSlime : MusicSceneBase
	{
		public override int Music => InfernumCompatibility.DecideOnMusicPath("KingSlime", "KingSlime");

		public override SceneEffectPriority Priority => InfernumCompatibility.DecideOnScenePriority(SceneEffectPriority.BossLow);

		public override bool MusicCondition(Player player) => MusicUtilities.NPCNearby(NPCID.KingSlime);
	}
}
