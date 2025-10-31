using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.Music
{
	public class JungleTemple : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("JungleTemple");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyDungeon : MusicID.Temple;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneLihzhardTemple;
		}
	}
	public class Dungeon : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Dungeon");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneDungeon;
		}
	}
	public class Aether : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Aether");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneShimmer;
		}
	}
	public class WorkshopTier6 : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("WorkshopTier6");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);

			bool distanceToTiles =
				WorkshopDetection.TileDistance(TileID.WorkBenches) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				(calamityMod && WorkshopDetection.TileDistance(calamity.Find<ModTile>("DraedonsForge").Type) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f));

			bool condition1 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.draedonsForgeTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition2 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.draedonsForgeTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			bool condition3 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier6Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition4 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier6Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			return (condition1 || condition2 || condition3 || condition4) && PlayerFlags.notInExcludedTownBiome && ModContent.GetInstance<MusicConfig>().WorkshopThemes && ModContent.GetInstance<OtherConfig>().AmbienceFrequency != 100;
		}
	}
	public class WorkshopTier5 : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("WorkshopTier5");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);

			bool noGreaterTierIsActive = !ModContent.GetInstance<WorkshopTier6>().IsSceneEffectActive(player);

			bool distanceToTiles =
				WorkshopDetection.TileDistance(TileID.WorkBenches) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.AdamantiteForge) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.MythrilAnvil) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				(calamityMod && WorkshopDetection.TileDistance(calamity.Find<ModTile>("CosmicAnvil").Type) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f));

			bool condition1 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.mythrilAnvilTileCount > 0 && NPC.downedMoonlord && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition2 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.mythrilAnvilTileCount > 0 && NPC.downedMoonlord && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);
			bool condition3 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.cosmicAnvilTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition4 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.cosmicAnvilTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			bool condition5 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier5Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition6 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier5Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			return (condition1 || condition2 || condition3 || condition4 || condition5 || condition6) && noGreaterTierIsActive && PlayerFlags.notInExcludedTownBiome && ModContent.GetInstance<MusicConfig>().WorkshopThemes && ModContent.GetInstance<OtherConfig>().AmbienceFrequency != 100;
		}
	}
	public class WorkshopTier4 : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("WorkshopTier4");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			bool noGreaterTierIsActive =
				!(ModContent.GetInstance<WorkshopTier5>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier6>().IsSceneEffectActive(player));

			bool distanceToTiles =
				WorkshopDetection.TileDistance(TileID.WorkBenches) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.AdamantiteForge) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.MythrilAnvil) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f);

			bool condition1 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.mythrilAnvilTileCount > 0 && NPC.downedPlantBoss && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition2 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.mythrilAnvilTileCount > 0 && NPC.downedPlantBoss && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			bool condition3 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier4Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition4 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier4Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			return (condition1 || condition2 || condition3 || condition4) && noGreaterTierIsActive && PlayerFlags.notInExcludedTownBiome && ModContent.GetInstance<MusicConfig>().WorkshopThemes && ModContent.GetInstance<OtherConfig>().AmbienceFrequency != 100;
		}
	}
	public class WorkshopTier3 : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("WorkshopTier3");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			bool noGreaterTierIsActive =
				!(ModContent.GetInstance<WorkshopTier4>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier5>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier6>().IsSceneEffectActive(player));

			bool distanceToTiles =
				WorkshopDetection.TileDistance(TileID.WorkBenches) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.AdamantiteForge) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.MythrilAnvil) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f);

			bool condition1 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.mythrilAnvilTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition2 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.adamantiteForgeTileCount > 0 && TileCounts.mythrilAnvilTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			bool condition3 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier3Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition4 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier3Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			return (condition1 || condition2 || condition3 || condition4) && noGreaterTierIsActive && PlayerFlags.notInExcludedTownBiome && ModContent.GetInstance<MusicConfig>().WorkshopThemes && ModContent.GetInstance<OtherConfig>().AmbienceFrequency != 100;
		}
	}
	public class WorkshopTier2 : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("WorkshopTier2");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			bool noGreaterTierIsActive =
				!(ModContent.GetInstance<WorkshopTier3>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier4>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier5>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier6>().IsSceneEffectActive(player));

			bool distanceToTiles =
				WorkshopDetection.TileDistance(TileID.WorkBenches) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.Hellforge) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.Anvils) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.AdamantiteForge) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.MythrilAnvil) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f);

			bool condition1 = distanceToTiles && TileCounts.workbenchTileCount > 0 && (TileCounts.hellForgeTileCount > 0 || TileCounts.adamantiteForgeTileCount > 0) && TileCounts.ironAnvilTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition2 = distanceToTiles && TileCounts.workbenchTileCount > 0 && (TileCounts.hellForgeTileCount > 0 || TileCounts.adamantiteForgeTileCount > 0) && TileCounts.ironAnvilTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);
			bool condition3 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.hellForgeTileCount > 0 && (TileCounts.ironAnvilTileCount > 0 || TileCounts.mythrilAnvilTileCount > 0) && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition4 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.hellForgeTileCount > 0 && (TileCounts.ironAnvilTileCount > 0 || TileCounts.mythrilAnvilTileCount > 0) && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			bool condition5 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier2Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition6 = PlayerFlags.distanceToMagicStorageTiles && PlayerFlags.WorkshopTier2Bosses && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			return (condition1 || condition2 || condition3 || condition4 || condition5 || condition6) && noGreaterTierIsActive && PlayerFlags.notInExcludedTownBiome && ModContent.GetInstance<MusicConfig>().WorkshopThemes && ModContent.GetInstance<OtherConfig>().AmbienceFrequency != 100;
		}
	}
	public class WorkshopTier1 : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("WorkshopTier1");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			bool noGreaterTierIsActive =
				!(ModContent.GetInstance<WorkshopTier2>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier3>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier4>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier5>().IsSceneEffectActive(player) ||
				ModContent.GetInstance<WorkshopTier6>().IsSceneEffectActive(player));

			bool distanceToTiles =
				WorkshopDetection.TileDistance(TileID.WorkBenches) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.Furnaces) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
				WorkshopDetection.TileDistance(TileID.Anvils) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f);

			bool condition1 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.furnaceTileCount > 0 && TileCounts.ironAnvilTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition2 = distanceToTiles && TileCounts.workbenchTileCount > 0 && TileCounts.furnaceTileCount > 0 && TileCounts.ironAnvilTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			bool condition3 = PlayerFlags.distanceToMagicStorageTiles && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (((PlayerFlags.notRaining && player.ZoneOverworldHeight) && (PlayerFlags.notInExcludedTownEvent && player.ZoneOverworldHeight) && (!LanternNight.LanternsUp && player.ZoneOverworldHeight)) || PlayerFlags.inSpace);
			bool condition4 = PlayerFlags.distanceToMagicStorageTiles && TileCounts.storageHeartTileCount > 0 && TileCounts.craftingUnitTileCount > 0 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight);

			return (condition1 || condition2 || condition3 || condition4) && noGreaterTierIsActive && PlayerFlags.notInExcludedTownBiome && ModContent.GetInstance<MusicConfig>().WorkshopThemes && ModContent.GetInstance<OtherConfig>().AmbienceFrequency != 100;
		}
	}
	public class TownNight : ModSceneEffect
	{
		public override int Music => (PlayerFlags.inUgTown || PlayerFlags.inSpace) ? MusicPathing.GetMusicSlot("TownNight_Noiseless") : MusicPathing.GetMusicSlot("TownNight");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return !Main.dayTime && (PlayerFlags.inTown || PlayerFlags.inUgTown) && PlayerFlags.notInExcludedTownBiome && !PlayerFlags.WorkshopSceneActive;
		}
	}
	public class TownDay : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("TownDay");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.dayTime && (PlayerFlags.inTown || PlayerFlags.inUgTown) && PlayerFlags.notInExcludedTownBiome && !PlayerFlags.WorkshopSceneActive;
		}
	}
	public class Space_Remix : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Space");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override float GetWeight(Player player) => 0.51f;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.remixWorld && PlayerFlags.onSurface;
		}
	}
	public class Space : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Space");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.inSpace && !(PlayerFlags.TownSceneActive || PlayerFlags.WorkshopSceneActive);
		}
	}
	public class Underworld : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Underworld");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneUnderworldHeight && !(PlayerFlags.TownSceneActive || PlayerFlags.WorkshopSceneActive) && !(PlayerFlags.ZoneBrimstoneCrags || PlayerFlags.ZoneProfanedTemple);
		}
	}
	public class GlowingMushroomFields : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("GlowingMushroomFields");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneGlowshroom && !(PlayerFlags.ZoneAstralInfection || PlayerFlags.ZoneSunkenSea || PlayerFlags.ZoneAbyss);
		}
	}
	public class Corruption : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Corruption");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneCorrupt && player.ZoneOverworldHeight && !(PlayerFlags.ZoneAstralInfection || PlayerFlags.ZoneSunkenSea || PlayerFlags.ZoneAbyss);
		}
	}
	public class CorruptionUnderground : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("CorruptionUnderground");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneCorrupt && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !(PlayerFlags.ZoneAstralInfection || PlayerFlags.ZoneSunkenSea || PlayerFlags.ZoneAbyss);
		}
	}
	public class Crimson : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Crimson");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneCrimson && player.ZoneOverworldHeight && !(PlayerFlags.ZoneAstralInfection || PlayerFlags.ZoneSunkenSea || PlayerFlags.ZoneAbyss);
		}
	}
	public class CrimsonUnderground : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("CrimsonUnderground");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneCrimson && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !(PlayerFlags.ZoneAstralInfection || PlayerFlags.ZoneSunkenSea || PlayerFlags.ZoneAbyss);
		}
	}
	public class Meteorite : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Meteorite");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneMeteor;
		}
	}
	public class Graveyard : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("Graveyard");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyEerie : MusicID.Graveyard;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneGraveyard;
		}
	}
	public class Geodes : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Geodes");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			Tile backWall = Framing.GetTileSafely((int)(player.Center.X / 16), (int)(player.Center.Y / 16));

			bool condition1 = backWall.WallType == WallID.GraniteUnsafe && TileCounts.graniteTileCount >= 50;
			bool condition2 = backWall.WallType == WallID.MarbleUnsafe && TileCounts.marbleTileCount >= 50;
			bool condition3 = backWall.WallType == WallID.GraniteBlock && TileCounts.graniteTileCount >= 500;
			bool condition4 = backWall.WallType == WallID.MarbleBlock && TileCounts.marbleTileCount >= 500;

			return (condition1 || condition2 || condition3 || condition4) && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !player.ZoneMeteor;
		}
	}
	public class JungleNight : ModSceneEffect
	{
		/*public override int Music => MusicPathing.GetMusicSlot("JungleNight");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return !Main.dayTime && player.ZoneJungle && (player.ZoneOverworldHeight || PlayerFlags.onRemixedSurface) && !player.ZoneMeteor && PlayerFlags.notRaining && !LanternNight.LanternsUp;
		}*/
	}
	public class JungleDay : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("JungleDay");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
            return /*Main.dayTime && */player.ZoneJungle && (player.ZoneOverworldHeight || PlayerFlags.onRemixedSurface) && !player.ZoneMeteor && PlayerFlags.notRaining && !LanternNight.LanternsUp;
		}
	}
	public class JungleUnderground : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("JungleUnderground");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyJungle : MusicID.JungleUnderground;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
        {
			return /*!Main.hardMode && */player.ZoneJungle && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !player.ZoneMeteor;
		}
    }
	public class Tundra : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Tundra");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneSnow && (player.ZoneOverworldHeight || PlayerFlags.onRemixedSurface);
		}
	}
	public class TundraUnderground : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("TundraUnderground");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneSnow && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight);
		}
	}
	public class Hallow : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("Hallow");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyHallow : MusicID.TheHallow;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.dayTime && player.ZoneHallow && player.ZoneOverworldHeight;
		}
	}
	public class HallowUnderground : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("HallowUnderground");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyUGHallow : MusicID.UndergroundHallow;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneHallow && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight);
		}
	}
	public class OceanNight : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("OceanNight");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return !Main.dayTime && player.ZoneBeach;
		}
	}
	public class OceanDay : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("OceanDay");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.dayTime && player.ZoneBeach;
		}
	}
	public class Desert_Remix : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Desert");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneDesert && PlayerFlags.onRemixedSurface;
		}
	}
	public class Desert : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Desert");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneDesert && !PlayerFlags.ugDesertOriginalHeight;
		}
	}
	public class DesertUnderground : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("DesertUnderground");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyDesert : MusicID.UndergroundDesert;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			bool ugDesertHeight = player.position.Y >= Main.worldSurface * 14 + (double)Main.screenHeight / 2;

			return player.ZoneUndergroundDesert && ugDesertHeight && !player.ZoneBeach;
		}
	}
	public class ForestNight : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("ForestNight");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return !Main.dayTime && player.ZoneOverworldHeight && !player.ZoneBeach;
		}
	}
	public class ForestDayEvening : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("ForestDayEvening");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.time >= 43200 && Main.dayTime && player.ZoneOverworldHeight && !(player.ZoneBeach || player.ZoneHallow);
		}
	}
	public class ForestDayAfternoon : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("ForestDayAfternoon");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.time >= 27000 && Main.time < 43200 && Main.dayTime && player.ZoneOverworldHeight && !(player.ZoneBeach || player.ZoneHallow);
		}

		public override void SpecialVisuals(Player player, bool isActive)
		{
			if (isActive && Main.time >= 27000 && Main.time < 27300 && Main.curMusic == Music && Main.musicFade[Main.curMusic] < 0.25f && Main.dayRate == 1)
			{
				Main.musicFade[Main.curMusic] = 0.25f;
			}
		}
	}
	public class ForestDayMorning : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("ForestDayMorning");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.time >= 10800 && Main.time < 27000 && Main.dayTime && player.ZoneOverworldHeight && !(player.ZoneBeach || player.ZoneHallow);
		}

		public override void SpecialVisuals(Player player, bool isActive)
		{
			if (isActive && Main.time >= 10800 && Main.time < 11100 && Main.curMusic == Music && Main.musicFade[Main.curMusic] < 0.25f && Main.dayRate == 1)
			{
				Main.musicFade[Main.curMusic] = 0.25f;
			}
		}
	}
	public class ForestDayDawn : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("ForestDayDawn");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.time <= 10800 && Main.dayTime && player.ZoneOverworldHeight && !(player.ZoneBeach || player.ZoneHallow);
		}
	}
	public class UndergroundHardmode : ModSceneEffect
	{
		/*public override int Music => MusicPathing.GetMusicSlot("UndergroundHardmode");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.hardMode && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !(player.ZoneBeach || player.ZoneHallow);
		}*/
	}
	public class Caverns : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Caverns");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = PlayerFlags.largeWorld && player.ZoneRockLayerHeight && player.position.Y > Main.rockLayer * 24.2 + Main.screenHeight / 2;
			bool condition2 = PlayerFlags.mediumWorld && player.ZoneRockLayerHeight && player.position.Y > Main.rockLayer * 25.8 + Main.screenHeight / 2;
			bool condition3 = PlayerFlags.smallWorld && player.ZoneRockLayerHeight && player.position.Y > Main.rockLayer * 25 + Main.screenHeight / 2;

			return /*!Main.hardMode && */(condition1 || condition2 || condition3) && !(player.ZoneBeach || player.ZoneHallow);
		}
	}
	public class Underground : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Underground");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

		public override bool IsSceneEffectActive(Player player)
		{
			return /*!Main.hardMode && */(player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !(player.ZoneBeach || player.ZoneHallow);
		}
	}
}