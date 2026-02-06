using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.Music
{
    public class Aether : MusicSceneBase
    {
        public override string MusicFilePath => "Aether";

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool MusicCondition(Player player) => MusicFlags.Aether;
    }
    
	public class JungleTemple : MusicSceneBase
	{
        //public override string MusicFilePath => "JungleTemple";
        public override int VanillaMusicPath => // Temporary for vanilla music.
            MusicFlags.OtherworldlyMusic ? MusicID.OtherworldlyDungeon :
            MusicID.Temple;

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Temporary for vanilla music.

        public override bool MusicCondition(Player player) => MusicFlags.JungleTemple;
	}

	public class Dungeon : MusicSceneBase
	{
		public override string MusicFilePath => "Dungeon";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool MusicCondition(Player player) => MusicFlags.Dungeon;
	}

    public class Workshop : MusicSceneBase
    {
        public override string MusicFilePath =>
			MusicFlags.WorkshopTier6 ? "WorkshopTier6" : 
            MusicFlags.WorkshopTier5 ? "WorkshopTier5" : 
            MusicFlags.WorkshopTier4 ? "WorkshopTier4" :
            MusicFlags.WorkshopTier3 ? "WorkshopTier3" : 
            MusicFlags.WorkshopTier2 ? "WorkshopTier2" :
            MusicFlags.WorkshopTier1 ? "WorkshopTier1" :
			string.Empty;

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool MusicCondition(Player player) => MusicFlags.Workshop;
    }

    public class Town : MusicSceneBase
    {
        public override string MusicFilePath =>
            MusicFlags.Night ? !MusicFlags.Surface ? "TownNight_Noiseless" :
            "TownNight" :
            MusicFlags.Party ? "TownParty" :
            "TownDay";

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool MusicCondition(Player player) => MusicFlags.Town;
    }

    public class Space : MusicSceneBase
	{
		public override string MusicFilePath => "Space";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool MusicCondition(Player player) => MusicFlags.Space;
	}

	public class Underworld : MusicSceneBase
	{
		public override string MusicFilePath => "Underworld";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool MusicCondition(Player player) => MusicFlags.Underworld;
	}

	public class GlowingMushroomFields : MusicSceneBase
	{
		public override string MusicFilePath => "GlowingMushroomFields";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override bool MusicCondition(Player player) => MusicFlags.GlowingMushrooms;
	}

    public class Crimson : MusicSceneBase
    {
        public override string MusicFilePath =>
            MusicFlags.Underground ? "CrimsonUnderground" :
            "Crimson";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override bool MusicCondition(Player player) => MusicFlags.Crimson;
    }


    public class Corruption : MusicSceneBase
	{
		public override string MusicFilePath =>
			MusicFlags.Underground ? "CorruptionUnderground" :
			"Corruption";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool MusicCondition(Player player) => MusicFlags.Corruption;
	}

    public class Graveyard : MusicSceneBase
    {
        //public override string MusicFilePath => "Graveyard";
        public override int VanillaMusicPath => // Temporary for vanilla music.
            MusicFlags.OtherworldlyMusic ? MusicID.OtherworldlyEerie :
            MusicID.Graveyard;

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Temporary for vanilla music.

        public override bool MusicCondition(Player player) => MusicFlags.Graveyard;
    }

    public class Meteorite : MusicSceneBase
	{
		public override string MusicFilePath => "Meteorite";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool MusicCondition(Player player) => MusicFlags.Meteorite;
	}

	public class Geodes : MusicSceneBase
	{
		public override string MusicFilePath => "Geodes";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool MusicCondition(Player player) => MusicFlags.Geodes;
	}

	public class Jungle : MusicSceneBase
	{
        /*public override string MusicFilePath =>
            MusicFlags.Underground ? "JungleUnderground" :
			MusicFlags.Night ? "JungleNight" :
			"JungleDay";*/
        public override string MusicFilePath => // Temporary for vanilla music.
            MusicFlags.Underground ? string.Empty : 
			"JungleDay";

        public override int VanillaMusicPath => // Temporary for vanilla music.
			MusicFlags.OtherworldlyMusic ? MusicFlags.Underground ? MusicID.OtherworldlyJungle :
			-1 :
			MusicFlags.Underground ? MusicID.JungleUnderground :
			-1;

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override float GetWeight(Player player) => // Temporary for vanilla music.
            MusicFlags.Underground ? base.GetWeight(player) - 0.01f : 
			base.GetWeight(player);

        public override bool MusicCondition(Player player) => MusicFlags.Jungle;
	}

	public class Tundra : MusicSceneBase
	{
		public override string MusicFilePath =>
			MusicFlags.Underground ? "TundraUnderground" :
			"Tundra";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override bool MusicCondition(Player player) => MusicFlags.Tundra;
	}

	public class Hallow : MusicSceneBase
    {
        /*public override string MusicFilePath =>
			MusicFlags.Underground ? "HallowUnderground" :
			"Hallow";*/
        public override string MusicFilePath => // Temporary for vanilla music.
            MusicFlags.Night ? "ForestNight" :
			string.Empty;

        public override int VanillaMusicPath => // Temporary for vanilla music.
            MusicFlags.OtherworldlyMusic ? MusicFlags.Underground ? MusicID.OtherworldlyUGHallow :
			MusicFlags.Night ? MusicID.OtherworldlyNight :
			MusicID.OtherworldlyHallow :
			MusicFlags.Underground ? MusicID.UndergroundHallow :
			MusicFlags.Night ? -1 :
			MusicID.TheHallow;

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Temporary for vanilla music.

        public override bool MusicCondition(Player player) => MusicFlags.Hallow;
    }

    public class Ocean : MusicSceneBase
	{
		public override string MusicFilePath => 
			MusicFlags.Night ? "OceanNight" : 
			"OceanDay";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool MusicCondition(Player player) => MusicFlags.Ocean;
	}

	public class Desert : MusicSceneBase
	{
		public override string MusicFilePath =>
            MusicFlags.Sandstorm ? "Sandstorm" :
            //MusicFlags.UndergroundDesert ? "DesertUnderground" :
			"Desert";

        public override int VanillaMusicPath => // Temporary for vanilla music.
           MusicFlags.OtherworldlyMusic ? MusicFlags.UndergroundDesert ? MusicID.OtherworldlyDesert :
           -1 :
           MusicFlags.UndergroundDesert ? MusicID.UndergroundDesert :
           -1;

        public override SceneEffectPriority Priority =>
            MusicFlags.Sandstorm ? SceneEffectPriority.Environment : 
			SceneEffectPriority.BiomeLow;

        public override float GetWeight(Player player) => // Temporary for vanilla music.
            MusicFlags.UndergroundDesert ? base.GetWeight(player) - 0.01f :
            base.GetWeight(player);

        public override bool MusicCondition(Player player) => MusicFlags.Desert;
	}

	public class Forest : MusicSceneBase
	{
        public override string MusicFilePath =>
            //MusicFlags.WindyDay ? "WindyDay" :
            MusicFlags.Underground ? //MusicFlags.Endgame ? "UndergroundEndgame" :
            //MusicFlags.Hardmode ? "UndergroundHardmode" :
            MusicFlags.LavaLayer ? "Caverns" :
            "Underground" :
			MusicFlags.Night ? "ForestNight" :
            MusicFlags.Evening ? "ForestDayEvening" :
            MusicFlags.Afternoon ? "ForestDayAfternoon" :
            MusicFlags.Morning ? "ForestDayMorning" :
			"ForestDayDawn";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.02f; // Relative weight change. Increase to - 0.01f when Hallow gets all of its music.

        public override bool MusicCondition(Player player) => MusicFlags.Forest;
    }
}