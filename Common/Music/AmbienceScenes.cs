using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.Music
{
    public class AmbienceRandomness : ModSystem
    {
        private int previousMusic = -1;
        public bool ShouldPlayAmbience { get; private set; }

        public override void PostUpdateEverything()
        {
			if (Main.curMusic == previousMusic)
			{
				return;
			}

            float ambienceFrequency = ModContent.GetInstance<OtherConfig>().AmbienceFrequency;

            ShouldPlayAmbience = ambienceFrequency > 0 && Main.rand.NextFloat() <= ambienceFrequency / 100f;
            previousMusic = Main.curMusic;
        }
    }

    [JITWhenModsEnabled("CalamityMod")]
	public class BioLab_Ambience : AmbienceSceneBase
	{
		#pragma warning disable
        public static float SunkenSeaLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.SunkenSeaLabCenter, Main.LocalPlayer.Center);
		
        public static float PlanetoidLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.PlanetoidLabCenter, Main.LocalPlayer.Center);

		public static float JungleLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.JungleLabCenter, Main.LocalPlayer.Center);

		public static float UnderworldLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.HellLabCenter, Main.LocalPlayer.Center);

		public static float TundraLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.IceLabCenter, Main.LocalPlayer.Center);

		public static float CavernLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.CavernLabCenter, Main.LocalPlayer.Center);
		#pragma warning restore

        public override string AmbienceFilePath => "BioLab";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool AmbienceCondition(Player player)
		{
			Tile backWall = Framing.GetTileSafely((int)(player.Center.X / 16), (int)(player.Center.Y / 16));

			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamitymod);

			double labRadius = Math.Pow(80f * 16f, 2);

			bool behindLabWall;
			bool nearBioLabPoint;

			if (calamityMod)
			{
                // When Calamity 2.1+ is not enabled
                if (calamitymod.Version < new Version(2, 1))
				{
                    behindLabWall =
                        backWall.WallType == WallID.ObsidianBrick ||
                        backWall.WallType == WallID.Glass ||
                        backWall.WallType == WallID.SnowWallUnsafe ||
                        backWall.WallType == WallID.IceUnsafe ||
                        backWall.WallType == WallID.Waterfall ||
                        backWall.WallType == WallID.Lavafall ||
                        backWall.WallType == WallID.IronBrick ||
                        backWall.WallType == calamitymod.Find<ModWall>("AstralIceWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("AstralSnowWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("HavocplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("CinderplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("ElumplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("HazardChevronWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPanelWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPlateBeam").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPlatePillar").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPlatingWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("NavyplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("PlagueContainmentCellsWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("PlaguedPlateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("RustedPlatePillar").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("RustedPlatingWall").Type;
                }
                else
                {
					behindLabWall =
                        backWall.WallType == WallID.AmberGemspark ||
                        backWall.WallType == WallID.AncientSilverBrickWall ||
                        backWall.WallType == WallID.CopperPlating ||
                        backWall.WallType == WallID.EmeraldGemspark ||
                        backWall.WallType == WallID.Granite ||
                        backWall.WallType == WallID.GrayBrick ||
                        backWall.WallType == WallID.IridescentBrick ||
                        backWall.WallType == WallID.IronBrick ||
                        backWall.WallType == WallID.Lavafall ||
                        backWall.WallType == WallID.LavaMossBlockWall ||
                        backWall.WallType == WallID.LeadBrick ||
                        backWall.WallType == WallID.ObsidianBrick ||
                        backWall.WallType == WallID.RubyGemspark ||
                        backWall.WallType == WallID.SapphireGemspark ||
                        backWall.WallType == WallID.SilverBrick ||
                        backWall.WallType == WallID.StoneSlab ||
                        backWall.WallType == WallID.TinPlating ||
                        backWall.WallType == WallID.TopazGemspark ||
                        backWall.WallType == WallID.Waterfall ||
                        backWall.WallType == calamitymod.Find<ModWall>("CinderplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("ElumplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("EutrophicGlassWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("HavocplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("HazardChevronWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPanelWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPlateBeam").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPlatePillar").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("LaboratoryPlatingWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("NavyplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("OnyxplateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("PlagueContainmentCellsWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("PlaguedPlateWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("RustedPlatePillar").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("RustedPlatingWall").Type ||
                        backWall.WallType == calamitymod.Find<ModWall>("ShellstoneSlabWall").Type;
                }

                nearBioLabPoint =
					SunkenSeaLabDistance <= labRadius ||
					PlanetoidLabDistance <= labRadius ||
					JungleLabDistance <= labRadius ||
					UnderworldLabDistance <= labRadius ||
					TundraLabDistance <= labRadius ||
					CavernLabDistance <= labRadius;
			}
			else
			{
				behindLabWall = false;
				nearBioLabPoint = false;
			}

			return calamityMod && TileCounts.LabTileCount > 150 && behindLabWall && nearBioLabPoint;
		}
	}

	public class RainHeavy_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "RainHeavy";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Rain>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Rain>().IsSceneEffectActive(player) && Main.maxRaining >= 0.6;
	}

	public class RainNormal_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "RainNormal";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Rain>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Rain>().IsSceneEffectActive(player) && Main.maxRaining >= 0.4 && Main.maxRaining < 0.6;
	}

	public class RainLight_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "RainLight";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Rain>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Rain>().IsSceneEffectActive(player) && Main.maxRaining < 0.4;
	}

	public class JungleTemple_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "JungleTemple";

		public override SceneEffectPriority Priority => ModContent.GetInstance<JungleTemple>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<JungleTemple>().IsSceneEffectActive(player);
	}

	public class Dungeon_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Dungeon";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Dungeon>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Dungeon>().IsSceneEffectActive(player);
	}

    public class Aether_Ambience : AmbienceSceneBase
    {
        public override string AmbienceFilePath => "HallowUnderground";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Aether>().Priority;

        public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Aether>().IsSceneEffectActive(player);
    }

    public class Space_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Space";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Space>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Space>().IsSceneEffectActive(player);
	}

	public class BrimstoneCrags_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "BrimstoneCrags";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool AmbienceCondition(Player player) => MusicFlags.BrimstoneCrags;
	}

	public class Underworld_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Underworld";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Underworld>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Underworld>().IsSceneEffectActive(player);
	}

	public class AbyssLayer4_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "AbyssLayer4";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool AmbienceCondition(Player player) => MusicFlags.TheVoid;
	}

	public class AbyssLayer3_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "AbyssLayer3";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool AmbienceCondition(Player player) => MusicFlags.ThermalVents;
	}

	public class AbyssLayer2_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "AbyssLayer2";

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool AmbienceCondition(Player player) => MusicFlags.SulphuricDepths || MusicFlags.MurkyWaters;
	}

	public class AstralInfection_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath =>
			MusicFlags.Underground ? "AstralInfectionUnderground" : 
			"AstralInfection";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool AmbienceCondition(Player player) => MusicFlags.AstralInfection;
	}

	public class SulphurousSea_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "SulphurousSea";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool AmbienceCondition(Player player) => MusicFlags.SulphurousSea;
	}

	public class SunkenSea_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "SunkenSea";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool AmbienceCondition(Player player) => MusicFlags.SunkenSea;
	}

	public class GlowingMushrooms_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "GlowingMushrooms";

		public override SceneEffectPriority Priority => ModContent.GetInstance<GlowingMushrooms>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<GlowingMushrooms>().IsSceneEffectActive(player);
	}

	public class Corruption_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath =>
			MusicFlags.Underground ? "CorruptionUnderground" :
			"Corruption";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Corruption>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Corruption>().IsSceneEffectActive(player);
	}

	public class Crimson_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => 
			MusicFlags.Underground ? "CrimsonUnderground" :
			"Crimson";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Crimson>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Crimson>().IsSceneEffectActive(player);
	}

	public class Meteorite_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Meteorite";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Meteorite>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Meteorite>().IsSceneEffectActive(player);
	}

	public class Graveyard_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Crimson";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Graveyard>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Graveyard>().IsSceneEffectActive(player);
	}

    public class BeeHive_Ambience : AmbienceSceneBase
    {
        public override string AmbienceFilePath => "BeeHive";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override bool AmbienceCondition(Player player) => MusicFlags.BeeHive && !ModContent.GetInstance<OtherConfig>().DisableBeeHiveAmbience;
    }

    public class SpiderCave_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "SpiderCave";

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool AmbienceCondition(Player player) => MusicFlags.SpiderCave && !ModContent.GetInstance<OtherConfig>().DisableSpiderCaveAmbience;
	}

	public class Geodes_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Caverns";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Geodes>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Geodes>().IsSceneEffectActive(player);
	}

	public class Jungle_Ambience : AmbienceSceneBase
	{
        public override string AmbienceFilePath =>
			MusicFlags.Underground ? "JungleUnderground" :
			"Jungle";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Jungle>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Jungle>().IsSceneEffectActive(player);
	}

	public class Tundra_Ambience : AmbienceSceneBase
	{
        public override string AmbienceFilePath =>
			MusicFlags.Underground ? "TundraUnderground" : 
			"Tundra";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Tundra>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Tundra>().IsSceneEffectActive(player);
	}

	public class Hallow_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath =>
			MusicFlags.Underground ? "HallowUnderground" :
			MusicFlags.Night ? "ForestNight" :
			"Hallow";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Hallow>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Hallow>().IsSceneEffectActive(player);
	}

	public class Ocean_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath => "Ocean";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Ocean>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Ocean>().IsSceneEffectActive(player);
	}

	public class Desert_Ambience : AmbienceSceneBase
	{
		public override string AmbienceFilePath =>
            MusicFlags.Sandstorm ? "Sandstorm" :
            MusicFlags.UndergroundDesert ? "DesertUnderground" :
            "Desert";

		public override SceneEffectPriority Priority => ModContent.GetInstance<Desert>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Desert>().IsSceneEffectActive(player);
	}

	public class Forest_Ambience : AmbienceSceneBase
	{
        public override string AmbienceFilePath =>
			MusicFlags.Underground ? MusicFlags.LavaLayer ? "Caverns" : 
			"Underground" :
			MusicFlags.Night ? "ForestNight" : 
			"ForestDay";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Forest>().Priority;

		public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Forest>().IsSceneEffectActive(player);
	}
}