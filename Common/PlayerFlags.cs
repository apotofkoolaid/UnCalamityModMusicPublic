using System;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common
{
	public class PlayerFlags : ModPlayer
	{
		public static bool onSurface;
		public static bool onRemixedSurface;
		public static bool inSpace;
		public static bool ugDesertOriginalHeight;
		public static bool isRaining;
		public static bool notRaining;
		public static bool largeWorld;
		public static bool mediumWorld;
		public static bool smallWorld;
		public static bool inTown;
		public static bool inTownWithRain;
		public static bool inUgTown;
		public static bool notInExcludedTownBiome;
		public static bool notInExcludedTownEvent;
		public static bool distanceToMagicStorageTiles;
		public static bool ZoneSandstorm;
		public static bool ZoneOverworldHeightExtra;
		public static bool TownSceneActive;
		public static bool WorkshopSceneActive;
		public static bool WorkshopTier6Bosses;
		public static bool WorkshopTier5Bosses;
		public static bool WorkshopTier4Bosses;
		public static bool WorkshopTier3Bosses;
		public static bool WorkshopTier2Bosses;

        public static bool infernumMode;
		public static bool deathMode;
		public static bool revengeanceMode;
		public static bool bossRushActive;

        public static bool FoveanatorActive;
        public static bool SkeletronPrime2Active;

        public static bool ZoneBrimstoneCrags;
		public static bool ZoneProfanedTemple;
		public static bool ZoneAstralInfection;
		public static bool ZoneSulfurSea;
		public static bool ZoneAbyss;
		public static bool ZoneShallowAbyss;
		public static bool ZoneDeepAbyss;
		public static bool ZoneVoidAbyss;
		public static bool ZoneSunkenSea;
		public static bool ZoneLostColosseum;

		public static bool downedSupremeCalamitas;
		public static bool downedExoMechs;
		public static bool downedYharon;
		public static bool downedDevourerofGods;
		public static bool downedOldDuke;
		public static bool downedPolterghast;
		public static bool downedSignus;
		public static bool downedStormWeaver;
		public static bool downedCeaselessVoid;
		public static bool downedProvidence;
		public static bool downedProfanedGuardians;
		public static bool downedDragonfolly;
		public static bool downedAstrumDeus;
		public static bool downedRavager;
		public static bool downedPlaguebringerGoliath;
		public static bool downedAstrumAureus;
		public static bool downedLeviathan;
		public static bool downedCalamitasClone;
		public static bool downedBrimstoneElemental;
		public static bool downedAquaticScourge;
		public static bool downedCryogen;
		public static bool downedSlimeGod;
		public static bool downedPerforators;
		public static bool downedHiveMind;

		public static bool ZonePyramid;
		public static bool ZoneGraniteCave;
		public static bool ZoneMarbleCave;
		public static bool ZoneHive;

        public static bool CalamityMusicEventInactive = true;

        public static float MusicTileRange = 525f * 16f;

		public override void PreUpdate()
		{
			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
			var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernum);
			var remnantsMod = ModLoader.TryGetMod("Remnants", out Mod remnants);
			var magicStorage = ModLoader.TryGetMod("MagicStorage", out Mod storage);
			var noTownMusic = ModLoader.TryGetMod("NoTownMusic", out Mod notownmusic);

			float spacef = remnantsMod ? 17f : 16f;
			float spaceh = (float)Main.maxTilesX / 4200f;
			spaceh *= spaceh;

			Player player = Main.player[Main.myPlayer];

			onSurface = player.position.Y < Main.worldSurface * 16.0 + (double)Main.screenHeight / 2;
			onRemixedSurface = 
				Main.remixWorld && 
				(double)player.position.Y / 16f > Main.rockLayer && 
				player.position.Y / 16f < (float)Main.maxTilesY - 350;
			inSpace = (float)((double)((Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / spacef - (65f + 10f * spaceh)) / (Main.worldSurface / 5.0)) < 1f;
			ugDesertOriginalHeight = (double)player.position.Y >= Main.worldSurface * 16.0 + (double)(Main.screenHeight / 2);
			isRaining = Main.cloudAlpha > 0f;
			notRaining = Main.cloudAlpha <= 0.01f;
			largeWorld = Main.maxTilesY == 2400;
			mediumWorld = Main.maxTilesY == 1800;
            smallWorld = Main.maxTilesY == 1200;
			notInExcludedTownBiome = 
				!(player.ZoneGraveyard || 
				player.ZoneShimmer || 
				player.ZoneDungeon || 
				player.ZoneLihzhardTemple || 
				ZoneBrimstoneCrags || 
				ZoneAbyss);
			notInExcludedTownEvent =
				/*!(Main._shouldUseWindyDayMusic ||*/
				!(Main.slimeRain || 
				ZoneSandstorm || 
				Main.bloodMoon || 
				Main.eclipse);
			ZoneSandstorm = 
				Sandstorm.Happening && 
				player.ZoneDesert && 
				!player.ZoneBeach;
			ZoneOverworldHeightExtra = 
				(!player.ZoneDesert && player.ZoneOverworldHeight) || 
				(player.ZoneDesert && !ugDesertOriginalHeight);
			TownSceneActive = 
				ModContent.GetInstance<Music.TownDay>().IsSceneEffectActive(player) || 
				ModContent.GetInstance<Music.TownNight>().IsSceneEffectActive(player) ||
                ModContent.GetInstance<Music.TownRain>().IsSceneEffectActive(player) ||
                ModContent.GetInstance<Music.TownParty>().IsSceneEffectActive(player);
            WorkshopSceneActive = 
				ModContent.GetInstance<Music.WorkshopTier1>().IsSceneEffectActive(player) || 
				ModContent.GetInstance<Music.WorkshopTier2>().IsSceneEffectActive(player) || 
				ModContent.GetInstance<Music.WorkshopTier3>().IsSceneEffectActive(player) || 
				ModContent.GetInstance<Music.WorkshopTier4>().IsSceneEffectActive(player) || 
				ModContent.GetInstance<Music.WorkshopTier5>().IsSceneEffectActive(player) || 
				ModContent.GetInstance<Music.WorkshopTier6>().IsSceneEffectActive(player);
			WorkshopTier6Bosses = 
				downedExoMechs || 
				downedSupremeCalamitas;
			WorkshopTier5Bosses = 
				NPC.downedMoonlord || 
				downedProfanedGuardians || 
				downedDragonfolly || 
				downedProvidence || 
				downedCeaselessVoid || 
				downedStormWeaver || 
				downedSignus || 
				downedPolterghast || 
				downedOldDuke || 
				downedDevourerofGods || 
				downedYharon;
			WorkshopTier4Bosses = 
				NPC.downedPlantBoss || 
				downedLeviathan || 
				downedAstrumAureus || 
				NPC.downedGolemBoss || 
				downedPlaguebringerGoliath || 
				NPC.downedFishron || 
				downedRavager || 
				NPC.downedEmpressOfLight || 
				NPC.downedAncientCultist || 
				downedAstrumDeus;
			WorkshopTier3Bosses = 
				Main.hardMode || 
				NPC.downedQueenSlime || 
				downedCryogen || 
				NPC.downedMechBossAny || 
				downedAquaticScourge || 
				downedBrimstoneElemental || 
				downedCalamitasClone;
			WorkshopTier2Bosses = 
				downedHiveMind || 
				downedPerforators || 
				NPC.downedQueenBee || 
				NPC.downedBoss3 || 
				NPC.downedDeerclops || 
				downedSlimeGod;

			if (noTownMusic)
			{
				inTown = false;
				inTownWithRain = false;
				inUgTown = false;
			}
			else
			{
				if (player.ZoneShadowCandle || player.inventory[player.selectedItem].type == ItemID.ShadowCandle)
				{
					inTown = false;
					inTownWithRain = false;
					inUgTown = false;
				}
				else
				{
					inTown = 
						player.townNPCs > 2f && 
						((notRaining && 
						notInExcludedTownEvent && 
						player.ZoneOverworldHeight) || 
						inSpace);
                    inTownWithRain = 
						player.townNPCs > 2f && 
						isRaining && 
						notInExcludedTownEvent && 
						ZoneOverworldHeightExtra;
                    inUgTown = 
						player.townNPCs > 2f && 
						(player.ZoneDirtLayerHeight || 
						player.ZoneRockLayerHeight || 
						player.ZoneUnderworldHeight);
				}
			}

			if (magicStorage)
			{
				distanceToMagicStorageTiles =
					WorkshopDetection.TileDistance(storage.Find<ModTile>("StorageHeart").Type) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) ||
					WorkshopDetection.TileDistance(storage.Find<ModTile>("CraftingAccess").Type) <= (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f) * (ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f);
			}

			if (calamityMod)
			{
                deathMode = (bool)calamity.Call("DifficultyActive", "death");
                revengeanceMode = (bool)calamity.Call("DifficultyActive", "revengeance");
                bossRushActive = (bool)calamity.Call("DifficultyActive", "bossrush");

                FoveanatorActive = calamity.Version >= new Version(2, 1, 0, 1) && NPC.AnyNPCs(calamity.Find<ModNPC>("Foveanator").Type) && Main.npc[NPC.FindFirstNPC(calamity.Find<ModNPC>("Foveanator").Type)].Distance(player.Center) <= MusicTileRange;
                SkeletronPrime2Active = NPC.AnyNPCs(calamity.Find<ModNPC>("SkeletronPrime2").Type) && Main.npc[NPC.FindFirstNPC(calamity.Find<ModNPC>("SkeletronPrime2").Type)].Distance(player.Center) <= MusicTileRange;
                
				ZoneBrimstoneCrags = (bool)calamity.Call("GetInZone", player, "crags");
				ZoneAstralInfection = (bool)calamity.Call("GetInZone", player, "astral");
				ZoneSulfurSea = 
					(bool)calamity.Call("GetInZone", player, "sulfur") && 
					!ZoneAbyss;
				ZoneAbyss = (bool)calamity.Call("GetInZone", player, "abyss");
				ZoneShallowAbyss = 
					(bool)calamity.Call("GetInZone", player, "layer1") || 
					(bool)calamity.Call("GetInZone", player, "layer2");
				ZoneDeepAbyss = (bool)calamity.Call("GetInZone", player, "layer3");
				ZoneVoidAbyss = (bool)calamity.Call("GetInZone", player, "layer4");
				ZoneSunkenSea = (bool)calamity.Call("GetInZone", player, "sunkensea");

				downedSupremeCalamitas = (bool)calamity.Call("GetBossDowned", "supremecalamitas");
				downedExoMechs = (bool)calamity.Call("GetBossDowned", "draedon");
				downedYharon = (bool)calamity.Call("GetBossDowned", "yharon");
				downedDevourerofGods = (bool)calamity.Call("GetBossDowned", "devourerofgods");
				downedOldDuke = (bool)calamity.Call("GetBossDowned", "oldduke");
				downedPolterghast = (bool)calamity.Call("GetBossDowned", "polterghast");
				downedSignus = (bool)calamity.Call("GetBossDowned", "signus");
				downedStormWeaver = (bool)calamity.Call("GetBossDowned", "stormweaver");
				downedCeaselessVoid = (bool)calamity.Call("GetBossDowned", "ceaselessvoid");
				downedProvidence = (bool)calamity.Call("GetBossDowned", "providence");
				downedProfanedGuardians = (bool)calamity.Call("GetBossDowned", "guardians");
				downedDragonfolly = (bool)calamity.Call("GetBossDowned", "dragonfolly");
				downedAstrumDeus = (bool)calamity.Call("GetBossDowned", "astrumdeus");
				downedRavager = (bool)calamity.Call("GetBossDowned", "ravager");
				downedPlaguebringerGoliath = (bool)calamity.Call("GetBossDowned", "plaguebringergoliath");
				downedAstrumAureus = (bool)calamity.Call("GetBossDowned", "astrumaureus");
				downedLeviathan = (bool)calamity.Call("GetBossDowned", "anahitaleviathan");
				downedCalamitasClone = (bool)calamity.Call("GetBossDowned", "calamitasclone");
				downedBrimstoneElemental = (bool)calamity.Call("GetBossDowned", "brimstoneelemental");
				downedAquaticScourge = (bool)calamity.Call("GetBossDowned", "aquaticscourge");
				downedCryogen = (bool)calamity.Call("GetBossDowned", "cryogen");
				downedSlimeGod = (bool)calamity.Call("GetBossDowned", "slimegod");
				downedPerforators = (bool)calamity.Call("GetBossDowned", "perforator");
				downedHiveMind = (bool)calamity.Call("GetBossDowned", "hivemind");

                CalamityMusicEventInactive = CalamityMusicEvent() == null;
            }

			if (infernumMod)
			{
				infernumMode = (bool)infernum.Call("GetInfernumActive");
				ZoneProfanedTemple = player.InModBiome(infernum.Find<ModBiome>("ProfanedTempleBiome"));
				ZoneLostColosseum = player.InModBiome(infernum.Find<ModBiome>("LostColosseumBiome"));
			}

			if (remnantsMod)
			{
				ZonePyramid = player.InModBiome(remnants.Find<ModBiome>("Pyramid"));
				ZoneGraniteCave = player.InModBiome(remnants.Find<ModBiome>("GraniteCave"));
				ZoneMarbleCave = player.InModBiome(remnants.Find<ModBiome>("MarbleCave"));
				ZoneHive = player.InModBiome(remnants.Find<ModBiome>("Hive"));
			}
		}

		public static bool SwapMusic()
		{
			FieldInfo swapMusic = typeof(Main).GetField("swapMusic", BindingFlags.Static | BindingFlags.NonPublic);

			if (swapMusic != null)
			{
				return (bool)swapMusic.GetValue(null);
			}

			return false;
		}

		public static DateTime? CalamityMusicEvent()
		{
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity))
            {
                Type musicEventType = calamity.GetType().Assembly.GetType("CalamityMod.Systems.MusicEventSystem");

                if (musicEventType != null)
                {
                    PropertyInfo trackStartProperty = musicEventType.GetProperty("TrackStart", BindingFlags.Static | BindingFlags.Public);
                    DateTime? trackStartValue = trackStartProperty.GetValue(null) as DateTime?;

                    return trackStartValue;
                }
            }

            return null;
        }
	}
}