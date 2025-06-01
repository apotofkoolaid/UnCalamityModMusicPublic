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
		public int prevMusic;

		public bool rollAmbience;

		public override void PostUpdateEverything()
		{
			if (Main.curMusic != prevMusic)
			{
				if (ModContent.GetInstance<OtherConfig>().AmbienceFrequency > 0)
				{
					rollAmbience = Main.rand.NextFloat(1) <= ModContent.GetInstance<OtherConfig>().AmbienceFrequency / 100;
				}
				else
				{
					rollAmbience = false;
				}
			}
			prevMusic = Main.curMusic;
		}
	}
	public abstract class AmbienceBaseScene : ModSceneEffect
	{
		public virtual string Path { get; }

		public virtual SceneEffectPriority ScenePriority { get; }

		public override int Music => MusicPathing.GetAmbienceSlot(Path);

		public override SceneEffectPriority Priority => (Main.LocalPlayer.townNPCs > 2f || ModContent.GetInstance<LanternFestival>().IsSceneEffectActive(Main.LocalPlayer)) ? SceneEffectPriority.Environment + 1 : ScenePriority;

		public override float GetWeight(Player player)
		{
			if (ScenePriority == SceneEffectPriority.Environment)
			{
				return 0.63f;
			}
			if (ScenePriority == SceneEffectPriority.BiomeHigh)
			{
				return 0.62f;
			}
			if (ScenePriority == SceneEffectPriority.BiomeMedium)
            {
				return 0.61f;
			}

			return 0.6f;
		}

		public override bool IsSceneEffectActive(Player player)
		{
			return AreAmbienceConditionsMet();
		}

		public static bool AreAmbienceConditionsMet()
		{
			return ModContent.GetInstance<AmbienceRandomness>().rollAmbience || ModContent.GetInstance<OtherConfig>().AmbienceFrequency == 100;
		}
	}
	[JITWhenModsEnabled("CalamityMod")]
	public class BioLab_Ambience : AmbienceBaseScene
	{
		public static float sunkenSeaLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.SunkenSeaLabCenter, Main.LocalPlayer.Center);

		public static float planetoidLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.PlanetoidLabCenter, Main.LocalPlayer.Center);

		public static float jungleLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.JungleLabCenter, Main.LocalPlayer.Center);

		public static float hellLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.HellLabCenter, Main.LocalPlayer.Center);

		public static float iceLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.IceLabCenter, Main.LocalPlayer.Center);

		public static float cavernLabDistance => Vector2.DistanceSquared(CalamityMod.World.CalamityWorld.CavernLabCenter, Main.LocalPlayer.Center);

		public override string Path => "BioLab";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			Tile backWall = Framing.GetTileSafely((int)(player.Center.X / 16), (int)(player.Center.Y / 16));

			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);

			double labRadius = Math.Pow(80f * 16f, 2);

			bool behindLabWall;
			bool nearBioLabPoint;

			if (calamityMod)
			{
                behindLabWall =
                    backWall.WallType == WallID.ObsidianBrick ||
                    backWall.WallType == WallID.Glass ||
                    backWall.WallType == WallID.SnowWallUnsafe ||
                    backWall.WallType == WallID.IceUnsafe ||
                    backWall.WallType == WallID.Waterfall ||
                    backWall.WallType == WallID.Lavafall ||
                    backWall.WallType == WallID.IronBrick ||
                    backWall.WallType == calamity.Find<ModWall>("AstralIceWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("AstralSnowWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("HavocplateWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("CinderplateWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("ElumplateWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("HazardChevronWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("LaboratoryPanelWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("LaboratoryPlateBeam").Type ||
                    backWall.WallType == calamity.Find<ModWall>("LaboratoryPlatePillar").Type ||
                    backWall.WallType == calamity.Find<ModWall>("LaboratoryPlatingWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("NavyplateWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("PlagueContainmentCellsWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("PlaguedPlateWall").Type ||
                    backWall.WallType == calamity.Find<ModWall>("RustedPlatePillar").Type ||
                    backWall.WallType == calamity.Find<ModWall>("RustedPlatingWall").Type;

                nearBioLabPoint =
					sunkenSeaLabDistance <= labRadius ||
					planetoidLabDistance <= labRadius ||
					jungleLabDistance <= labRadius ||
					hellLabDistance <= labRadius ||
					iceLabDistance <= labRadius ||
					cavernLabDistance <= labRadius;
			}
			else
			{
				behindLabWall = false;
				nearBioLabPoint = false;
			}

			return calamityMod && TileCounts.labTileCount > 150 && behindLabWall && nearBioLabPoint && base.IsSceneEffectActive(player);
		}
	}
	public class Blizzard_Ambience : AmbienceBaseScene
	{
		public override string Path => "Tundra";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Blizzard>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Blizzard>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Sandstorm_Ambience : AmbienceBaseScene
	{
		public override string Path => "Sandstorm";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Sandstorm>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Sandstorm>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class RainHeavy_Ambience : AmbienceBaseScene
	{
		public override string Path => "RainHeavy";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Rain>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = ModContent.GetInstance<Rain>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<Thunderstorm>().IsSceneEffectActive(player);

			return (condition1 || condition2) && Main.maxRaining >= 0.6 && base.IsSceneEffectActive(player);
		}
	}
	public class RainNormal_Ambience : AmbienceBaseScene
	{
		public override string Path => "RainNormal";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Rain>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = ModContent.GetInstance<Rain>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<Thunderstorm>().IsSceneEffectActive(player);

			return (condition1 || condition2) && Main.maxRaining >= 0.4 && Main.maxRaining < 0.6 && base.IsSceneEffectActive(player);
		}
	}
	public class RainLight_Ambience : AmbienceBaseScene
	{
		public override string Path => "RainLight";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Rain>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = ModContent.GetInstance<Rain>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<Thunderstorm>().IsSceneEffectActive(player);

			return (condition1 || condition2) && Main.maxRaining < 0.4 && base.IsSceneEffectActive(player);
		}
	}
	public class JungleTemple_Ambience : AmbienceBaseScene
	{
		public override string Path => "JungleTemple";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<JungleTemple>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<JungleTemple>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Dungeon_Ambience : AmbienceBaseScene
	{
		public override string Path => "Dungeon";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Dungeon>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Dungeon>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Space_Remix_Ambience : AmbienceBaseScene
	{
		public override string Path => "Space";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Space_Remix>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Space_Remix>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Space_Ambience : AmbienceBaseScene
	{
		public override string Path => "Space";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Space>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Space>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class BrimstoneCrags_Ambience : AmbienceBaseScene
	{
		public override string Path => "BrimstoneCrags";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneBrimstoneCrags && base.IsSceneEffectActive(player);
		}
	}
	public class Underworld_Ambience : AmbienceBaseScene
	{
		public override string Path => "Underworld";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Underworld>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Underworld>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class AbyssLayer4_Ambience : AmbienceBaseScene
	{
		public override string Path => "AbyssLayer4";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneVoidAbyss && base.IsSceneEffectActive(player);
		}
	}
	public class AbyssLayer3_Ambience : AmbienceBaseScene
	{
		public override string Path => "AbyssLayer3";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneDeepAbyss && base.IsSceneEffectActive(player);
		}
	}
	public class AbyssLayer2_Ambience : AmbienceBaseScene
	{
		public override string Path => "AbyssLayer2";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneShallowAbyss && base.IsSceneEffectActive(player);
		}
	}
	public class Aether_Ambience : AmbienceBaseScene
	{
		public override string Path => "HallowUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Aether>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Aether>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class AstralInfection_Ambience : AmbienceBaseScene
	{
		public override string Path => "AstralInfection";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneAstralInfection && player.ZoneOverworldHeight && base.IsSceneEffectActive(player);
		}
	}
	public class AstralInfectionUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "AstralInfectionUnderground";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneAstralInfection && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && base.IsSceneEffectActive(player);
		}
	}
	public class SulphurousSea_Ambience : AmbienceBaseScene
	{
		public override string Path => "SulphurousSea";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneSulfurSea && base.IsSceneEffectActive(player);
		}
	}
	public class SunkenSea_Ambience : AmbienceBaseScene
	{
		public override string Path => "SunkenSea";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneSunkenSea && base.IsSceneEffectActive(player);
		}
	}
	public class GlowingMushroomFields_Ambience : AmbienceBaseScene
	{
		public override string Path => Main.LocalPlayer.ZoneOverworldHeight ? "GlowingMushroomGrove" : "GlowingMushroomFields";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<GlowingMushroomFields>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<GlowingMushroomFields>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Corruption_Ambience : AmbienceBaseScene
	{
		public override string Path => "Corruption";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Corruption>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Corruption>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class CorruptionUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "CorruptionUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<CorruptionUnderground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<CorruptionUnderground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Crimson_Ambience : AmbienceBaseScene
	{
		public override string Path => "Crimson";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Crimson>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Crimson>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class CrimsonUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "CrimsonUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<CrimsonUnderground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<CrimsonUnderground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Meteorite_Ambience : AmbienceBaseScene
	{
		public override string Path => "Meteorite";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Meteorite>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Meteorite>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Graveyard_Ambience : AmbienceBaseScene
	{
		public override string Path => "Crimson";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Graveyard>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Graveyard>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class BeeHive_Remnants_Ambience : AmbienceBaseScene
	{
		public override string Path => "BeeHive";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneHive && !ModContent.GetInstance<OtherConfig>().DisableBeeHiveAmbience && base.IsSceneEffectActive(player);
		}
	}
	public class BeeHive_Ambience : AmbienceBaseScene
	{
		public override string Path => "BeeHive";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			Tile backWall = Framing.GetTileSafely((int)(player.Center.X / 16), (int)(player.Center.Y / 16));

			return backWall.WallType == WallID.HiveUnsafe && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !player.ZoneMeteor && !ModContent.GetInstance<OtherConfig>().DisableBeeHiveAmbience && base.IsSceneEffectActive(player);
		}
	}
	public class SpiderCave_Ambience : AmbienceBaseScene
	{
		public override string Path => "SpiderCave";

		public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			Tile backWall = Framing.GetTileSafely((int)(player.Center.X / 16), (int)(player.Center.Y / 16));

			return backWall.WallType == WallID.SpiderUnsafe && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !player.ZoneMeteor && !ModContent.GetInstance<OtherConfig>().DisableSpiderCaveAmbience && base.IsSceneEffectActive(player);
		}
	}
	public class Geodes_Remnants_Ambience : AmbienceBaseScene
	{
		public override string Path => "Caverns";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Geodes_Remnants>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Geodes_Remnants>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Geodes_Ambience : AmbienceBaseScene
	{
		public override string Path => "Caverns";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Geodes>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Geodes>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Jungle_Ambience : AmbienceBaseScene
	{
		public override string Path => "Jungle";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<JungleDay>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = ModContent.GetInstance<JungleDay>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<JungleNight>().IsSceneEffectActive(player);

			return (condition1 || condition2) && base.IsSceneEffectActive(player);
		}
	}
	public class JungleUnderground_Remnants_Ambience : AmbienceBaseScene
	{
		public override string Path => "JungleUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<JungleUnderground_Remnants>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<JungleUnderground_Remnants>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class JungleUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "JungleUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<JungleUnderground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<JungleUnderground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Tundra_Ambience : AmbienceBaseScene
	{
		public override string Path => "Tundra";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Tundra>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Tundra>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class TundraUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "TundraUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<TundraUnderground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<TundraUnderground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Hallow_Ambience : AmbienceBaseScene
	{
		public override string Path => "Hallow";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Hallow>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Hallow>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class HallowUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "HallowUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<HallowUnderground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<HallowUnderground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Ocean_Ambience : AmbienceBaseScene
	{
		public override string Path => "Ocean";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<OceanDay>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = ModContent.GetInstance<OceanDay>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<OceanNight>().IsSceneEffectActive(player);

			return (condition1 || condition2) && base.IsSceneEffectActive(player);
		}
	}
	public class Desert_Remix_Ambience : AmbienceBaseScene
	{
		public override string Path => "Desert";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Desert_Remix>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Desert_Remix>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class Desert_Ambience : AmbienceBaseScene
	{
		public override string Path => "Desert";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Desert>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Desert>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class DesertUnderground_Remnants_Ambience : AmbienceBaseScene
	{
		public override string Path => "DesertUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<DesertUnderground_Remnants>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<DesertUnderground_Remnants>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class DesertUnderground_Ambience : AmbienceBaseScene
	{
		public override string Path => "DesertUnderground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<DesertUnderground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<DesertUnderground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class ForestNight_Ambience : AmbienceBaseScene
	{
		public override string Path => "ForestNight";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<ForestNight>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<ForestNight>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
	public class ForestDay_Ambience : AmbienceBaseScene
	{
		public override string Path => "ForestDay";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<ForestDayDawn>().Priority;

		public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = ModContent.GetInstance<ForestDayDawn>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<ForestDayMorning>().IsSceneEffectActive(player);
			bool condition3 = ModContent.GetInstance<ForestDayAfternoon>().IsSceneEffectActive(player);
			bool condition4 = ModContent.GetInstance<ForestDayEvening>().IsSceneEffectActive(player);

			return (condition1 || condition2 || condition3 || condition4) && base.IsSceneEffectActive(player);
		}
	}
	public class Caverns_Ambience : AmbienceBaseScene
	{
		public override string Path => "Caverns";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Caverns>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = ModContent.GetInstance<Caverns>().IsSceneEffectActive(player);
			bool condition2 = ModContent.GetInstance<UndergroundHardmode>().IsSceneEffectActive(player);

			return (condition1 || condition2) && base.IsSceneEffectActive(player);
		}
	}
	public class Underground_Ambience : AmbienceBaseScene
	{
		public override string Path => "Underground";

		public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Underground>().Priority;

		public override bool IsSceneEffectActive(Player player)
		{
			return ModContent.GetInstance<Underground>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
		}
	}
}