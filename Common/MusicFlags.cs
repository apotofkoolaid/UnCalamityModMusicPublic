using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common
{
    // VCMM must keep track of many vanilla variables for its music scenes. Most are stored in this class for ease of use.
    public class MusicFlags : ModPlayer
    {
        #region Basic Flags
        internal static bool OtherworldlyMusic;
        internal static bool RemixSeed;
        internal static bool Hardmode;
        internal static bool Endgame;

        internal static bool Morning;
        internal static bool Afternoon;
        internal static bool Evening;
        internal static bool Night;

        internal static bool NaturalRain;
        internal static bool VisibleRain;

        internal static bool SkyLayer;
        internal static bool OverworldLayer;
        internal static bool DirtLayer;
        internal static bool RockLayer;
        internal static bool LavaLayer;
        internal static bool Surface;
        internal static bool Underground;

        internal static bool OffsetSurface;
        internal static bool FestiveMoonLayer;

        internal static bool RemixedOffsetSurface;
        internal static bool RemixedSpawnIsland;
        #endregion

        #region Biome Flags
        internal static bool Purity;
        internal static bool Forest;
        internal static bool Desert;
        internal static bool UndergroundDesert;
        internal static bool Ocean;
        internal static bool Hallow;

        internal static bool Tundra;
        internal static bool Jungle;
        internal static bool Geodes;
        internal static bool GraniteCave;
        internal static bool MarbleCave;
        internal static bool SpiderCave;
        internal static bool BeeHive;
        internal static bool Meteorite;
        internal static bool Graveyard;

        internal static bool Crimson;
        internal static bool Corruption;
        internal static bool GlowingMushrooms;

        internal static bool Underworld;
        internal static bool Space;
        internal static bool Dungeon;
        internal static bool JungleTemple;
        internal static bool Aether;
        #endregion

        #region Town Flags
        internal static bool NearThreeVillagers;
        internal static bool NotInTownAverseBiome;
        internal static bool NotInTownAverseEvent;

        internal static bool Town;
        internal static bool Party;
        #endregion

        #region Workshop Flags
        internal static bool WorkshopBase;
        internal static bool WorkshopAnyTier;
        internal static double WorkshopRange;

        internal static List<int> WorkBench;
        internal static int Furnace;
        internal static int Anvil;
        internal static int Hellforge;
        internal static int HardmodeAnvil;
        internal static int HardmodeForge;
        internal static int AncientManipulator;

        internal static bool WorkshopTier1;
        internal static bool WorkshopTier2;
        internal static bool WorkshopTier3;
        internal static bool WorkshopTier4;
        internal static bool WorkshopTier5;
        internal static bool WorkshopTier6;
        #endregion

        #region Event Flags
        internal static bool WindyDay;
        internal static bool LanternFestival;
        internal static bool Rain;
        internal static bool Thunderstorm;
        internal static bool Blizzard;
        internal static bool SlimeRain;
        internal static bool Sandstorm;
        internal static bool BloodMoon;
        internal static bool SolarEclipse;
        internal static bool PumpkinMoon;
        internal static bool FrostMoon;

        internal static bool GoblinArmy;
        internal static bool OldOnesArmy;
        internal static bool FrostLegion;
        internal static bool PirateInvasion;
        internal static bool MartianMadness;

        internal static bool TorchGod;
        internal static bool VortexPillar;
        internal static bool NebulaPillar;
        internal static bool StardustPillar;
        internal static bool SolarPillar;
        #endregion

        #region Misc Flags
        internal static bool MechEngaging;
        internal static bool CultistRitual;
        internal static bool ImpendingDoom;
        #endregion

        #region Boss Flags
        internal static bool DefeatedQueenBee;
        internal static bool DefeatedDeerclops;
        internal static bool DefeatedSkeletron;
        internal static bool DefeatedQueenSlime;
        internal static bool DefeatedAnyMech;
        internal static bool DefeatedPlantera;
        internal static bool DefeatedGolem;
        internal static bool DefeatedDukeFishron;
        internal static bool DefeatedEmpressofLight;
        internal static bool DefeatedLunaticCultist;

        internal static float BossMusicTileRange;

        internal static bool SimultaneousMechs;
        internal static bool MechaMayhem;
        #endregion

        #region Calamity Flags
        internal static bool RevengeanceMode;
        internal static bool DeathMode;
        internal static bool BossRush;

        internal static bool SunkenSea;
        internal static bool SulphurousSea;
        internal static bool AstralInfection;
        internal static bool Abyss;
        internal static bool SulphuricDepths;
        internal static bool MurkyWaters;
        internal static bool ThermalVents;
        internal static bool TheVoid;
        internal static bool BrimstoneCrags;

        internal static int CosmicAnvil = TileID.Count;
        internal static int DraedonsForge = TileID.Count;

        internal static bool DefeatedHiveMind;
        internal static bool DefeatedPerforators;
        internal static bool DefeatedSlimeGod;
        internal static bool DefeatedCryogen;
        internal static bool DefeatedAquaticScourge;
        internal static bool DefeatedBrimstoneElemental;
        internal static bool DefeatedCalamitasClone;
        internal static bool DefeatedLeviathan;
        internal static bool DefeatedAstrumAureus;
        internal static bool DefeatedPlaguebringerGoliath;
        internal static bool DefeatedRavager;
        internal static bool DefeatedAstrumDeus;
        internal static bool DefeatedDragonfolly;
        internal static bool DefeatedProfanedGuardians;
        internal static bool DefeatedProvidence;
        internal static bool DefeatedStormWeaver;
        internal static bool DefeatedCeaselessVoid;
        internal static bool DefeatedSignus;
        internal static bool DefeatedPolterghast;
        internal static bool DefeatedOldDuke;
        internal static bool DefeatedDevourerofGods;
        internal static bool DefeatedYharon;
        internal static bool DefeatedExoMechs;
        internal static bool DefeatedCalamitas;

        internal static bool NotInCalamityMusicEvent = true;
        #endregion

        #region Other Modded Flags
        internal static bool InfernumMode;

        internal static bool LostColosseum;
        internal static bool ProfanedTemple;

        internal static bool RemnantsPyramid;
        internal static bool RemnantsGraniteCave;
        internal static bool RemnantsMarbleCave;
        internal static bool RemnantsHive;

        internal static int StorageHeart = TileID.Count;
        internal static int CraftingUnit = TileID.Count;

        internal static bool MagicStorageWorkshop;
        internal static bool MagicStorageTier2Progression;
        internal static bool MagicStorageTier3Progression;
        internal static bool MagicStorageTier4Progression;
        internal static bool MagicStorageTier5Progression;
        internal static bool MagicStorageTier6Progression;
        #endregion

        public override void PreUpdate()
        {
            #region Instancing
            var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamitymod);
            var magicStorage = ModLoader.TryGetMod("MagicStorage", out Mod magicstorage);
            var noTownMusic = ModLoader.TryGetMod("NoTownMusic", out Mod notownmusic);
            var infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernummod);
            var remnantsMod = ModLoader.TryGetMod("Remnants", out Mod remnantsmod);

            Player player = Main.player[Main.myPlayer];
            #endregion

            #region Basic Flags
            OtherworldlyMusic = Main.zenithWorld ? Main.swapMusic : Main.swapMusic != Main.drunkWorld;
            RemixSeed = Main.remixWorld;
            Hardmode = Main.hardMode;
            Endgame = NPC.downedMoonlord;

            Morning = Main.time >= 10800;
            Afternoon = Main.time >= 27000;
            Evening = Main.time >= 43200;
            Night = !Main.dayTime && !RemixSeed;

            NaturalRain = Main.raining;
            VisibleRain = Main.cloudAlpha > 0f;

            SkyLayer = (float)((double)((Main.screenPosition.Y + (Main.screenHeight / 2)) / (remnantsMod ? 17f : 16f) - (65f + 10f * (Main.maxTilesX / 4200f * (Main.maxTilesX / 4200f)))) / (Main.worldSurface / 5.0)) < 1f;
            OverworldLayer = player.ZoneOverworldHeight;
            DirtLayer = player.ZoneDirtLayerHeight;
            RockLayer = player.ZoneRockLayerHeight;
            LavaLayer = RemixSeed ? DirtLayer : MusicUtilities.WorldHeightMeasurement(player, out int playerY) && playerY > Main.rockLayer + Main.maxTilesY * 0.268;
            Surface = RemixSeed ? RockLayer : OverworldLayer;
            Underground = RemixSeed && !Purity ? DirtLayer : DirtLayer || RockLayer;

            OffsetSurface = RemixSeed ? RemixedOffsetSurface : player.position.Y < Main.worldSurface * 16.0 + (double)Main.screenHeight / 2;
            FestiveMoonLayer = RemixSeed || (double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0;

            RemixedSpawnIsland = player.position.Y > (Main.UnderworldLayer * 16) && (double)(player.Center.X / 16f) > Main.maxTilesX * 0.37 + 50.0 && (double)(player.Center.X / 16f) < Main.maxTilesX * 0.63;
            RemixedOffsetSurface = player.position.Y > Main.rockLayer * 16.0 && player.position.Y <= (Main.UnderworldLayer * 16) || RemixedSpawnIsland;
            #endregion

            #region Biome Flags
            Purity = player.ZonePurity;
            Forest = Surface || Underground;
            Desert = player.ZoneDesert && ((Hallow && Night) || Sandstorm ? !Ocean : !(Ocean || Hallow)) && (UndergroundDesert ? Underground : Surface);
            UndergroundDesert = player.ZoneUndergroundDesert && !Surface;
            Ocean = player.ZoneBeach && !Hallow;
            Hallow = player.ZoneHallow;

            Tundra = player.ZoneSnow && !(Meteorite || Graveyard);
            Jungle = player.ZoneJungle && !(Meteorite || Graveyard);
            Geodes = (GraniteCave || MarbleCave) && Underground && !Graveyard;
            GraniteCave = (player.ZoneGranite && TileCounts.GraniteTileCount >= 50) || (MusicUtilities.InFrontOfWall(WallID.GraniteBlock) && TileCounts.GraniteTileCount >= 500);
            MarbleCave = (player.ZoneMarble && TileCounts.MarbleTileCount >= 50) || (MusicUtilities.InFrontOfWall(WallID.MarbleBlock) && TileCounts.MarbleTileCount >= 500);
            SpiderCave = MusicUtilities.InFrontOfWall(WallID.SpiderUnsafe) && Underground;
            BeeHive = MusicUtilities.InFrontOfWall(WallID.HiveUnsafe);
            Meteorite = player.ZoneMeteor && !Graveyard;
            Graveyard = player.ZoneGraveyard;

            Crimson = player.ZoneCrimson && !(GlowingMushrooms || SunkenSea || SulphurousSea || AstralInfection);
            Corruption = player.ZoneCorrupt && !(GlowingMushrooms || SunkenSea || SulphurousSea || AstralInfection);
            GlowingMushrooms = player.ZoneGlowshroom && !(SunkenSea || SulphurousSea || AstralInfection);

            Underworld = player.ZoneUnderworldHeight && (RemixSeed ? !(BloodMoon || SolarEclipse || BrimstoneCrags || ProfanedTemple || Town || WorkshopAnyTier) : !(BrimstoneCrags || ProfanedTemple || Town || WorkshopAnyTier));
            Space = (RemixSeed ? SkyLayer || OverworldLayer : SkyLayer) && !(BrimstoneCrags || ProfanedTemple || Town || WorkshopAnyTier);
            Dungeon = player.ZoneDungeon;
            JungleTemple = player.ZoneLihzhardTemple;
            Aether = player.ZoneShimmer;
            #endregion

            #region Town Flags
            NearThreeVillagers = player.townNPCs > 2f;

            NotInTownAverseBiome = !(Graveyard || Dungeon || JungleTemple || Aether || Abyss);
            NotInTownAverseEvent = !(/*(!Party && WindyDay) || */SlimeRain || Sandstorm || BloodMoon || SolarEclipse); // Windy Day is temporarily omitted from this list until it gets music.

            if (noTownMusic || player.ZoneShadowCandle || player.inventory[player.selectedItem].type == ItemID.ShadowCandle)
            {
                Town = false;
                Party = false;
            }
            else
            {
                Town = NearThreeVillagers && (Surface ? NotInTownAverseBiome && NotInTownAverseEvent : NotInTownAverseBiome) && (Rain ? !SulphurousSea : !WorkshopAnyTier);
                Party = NearThreeVillagers && BirthdayParty.PartyIsUp;
            }
            #endregion

            #region Workshop Flags
            WorkshopBase = (Surface ? !(/*WindyDay || */LanternFestival || Rain) && NotInTownAverseBiome && NotInTownAverseEvent : NotInTownAverseBiome) && !Party && ModContent.GetInstance<MusicConfig>().WorkshopThemes; // Windy Day is temporarily omitted from this list until it gets music.
            WorkshopAnyTier = WorkshopBase && (WorkshopTier1 || WorkshopTier2 || WorkshopTier3 || WorkshopTier4 || WorkshopTier5 || WorkshopTier6);
            WorkshopRange = Math.Pow(ModContent.GetInstance<MusicConfig>().WorkshopRange * 16f, 2f);

            WorkBench = [TileID.WorkBenches, ..TileCounts.ModdedWorkBenches];
            Furnace = TileID.Furnaces;
            Anvil = TileID.Anvils;
            Hellforge = TileID.Hellforge;
            HardmodeAnvil = TileID.MythrilAnvil;
            HardmodeForge = TileID.AdamantiteForge;
            AncientManipulator = TileID.LunarCraftingStation;

            WorkshopTier1 =
                (WorkshopDetection.TileDistance(WorkBench, Furnace, Anvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.FurnaceTileCount > 0 && TileCounts.AnvilTileCount > 0) ||
                MagicStorageWorkshop;
            WorkshopTier2 =
                (WorkshopDetection.TileDistance(WorkBench, Hellforge, Anvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.HellforgeTileCount > 0 && TileCounts.AnvilTileCount > 0) ||
                (WorkshopDetection.TileDistance(WorkBench, Hellforge, HardmodeAnvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.HellforgeTileCount > 0 && TileCounts.HardmodeAnvilTileCount > 0) ||
                (WorkshopDetection.TileDistance(WorkBench, HardmodeForge, Anvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.HardmodeForgeTileCount > 0 && TileCounts.AnvilTileCount > 0) ||
                (WorkshopDetection.TileDistance(WorkBench, Furnace, HardmodeAnvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.FurnaceTileCount > 0 && TileCounts.HardmodeAnvilTileCount > 0) ||
                (MagicStorageWorkshop && MagicStorageTier2Progression);
            WorkshopTier3 =
                (WorkshopDetection.TileDistance(WorkBench, HardmodeForge, HardmodeAnvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.HardmodeForgeTileCount > 0 && TileCounts.HardmodeAnvilTileCount > 0) ||
                (MagicStorageWorkshop && MagicStorageTier3Progression);
            WorkshopTier4 =
                (DefeatedPlantera && WorkshopTier3) ||
                (MagicStorageWorkshop && MagicStorageTier4Progression);
            WorkshopTier5 =
                (WorkshopDetection.TileDistance(WorkBench, HardmodeForge, HardmodeAnvil, AncientManipulator) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.HardmodeForgeTileCount > 0 && TileCounts.HardmodeAnvilTileCount > 0 && TileCounts.AncientManipulatorTileCount > 0) ||
                (WorkshopDetection.TileDistance(WorkBench, HardmodeForge, CosmicAnvil) <= WorkshopRange &&
                TileCounts.WorkBenchTileCount > 0 && TileCounts.HardmodeForgeTileCount > 0 && TileCounts.CosmicAnvilTileCount > 0) ||
                (MagicStorageWorkshop && MagicStorageTier5Progression);
            WorkshopTier6 =
                (WorkshopDetection.TileDistance(DraedonsForge) <= WorkshopRange &&
                TileCounts.DraedonsForgeTileCount > 0) ||
                (MagicStorageWorkshop && MagicStorageTier6Progression);
            #endregion

            #region Event Flags
            WindyDay = Main._shouldUseWindyDayMusic && Surface && Purity;
            LanternFestival = LanternNight.LanternsUp && (Ocean || SulphurousSea ? !(Rain || Meteorite || Graveyard) : Surface && !(Rain || Meteorite || Graveyard));
            Rain = VisibleRain && Surface && /*(Blizzard ? !(Meteorite || Graveyard || SolarEclipse) : */!(Meteorite || Graveyard || BloodMoon || SolarEclipse)/*)*/; //This check is not needed until Blizzard music is added.
            Thunderstorm = Main._shouldUseStormMusic;
            Blizzard = NaturalRain && Tundra;
            SlimeRain = Main.slimeRain && OffsetSurface && !(Space || BloodMoon || SolarEclipse);
            Sandstorm = Terraria.GameContent.Events.Sandstorm.Happening && player.ZoneDesert && Surface;
            BloodMoon = Main.bloodMoon && (RemixSeed ? OffsetSurface && !(Crimson || Corruption) : OffsetSurface) && !Space;
            SolarEclipse = Main.eclipse && OffsetSurface && !Space;
            PumpkinMoon = Main.pumpkinMoon && FestiveMoonLayer;
            FrostMoon = Main.snowMoon && FestiveMoonLayer;

            GoblinArmy = (Main.invasionType == InvasionID.GoblinArmy && Main.invasionProgressNearInvasion) ||
                MusicUtilities.NPCNearby(NPCID.GoblinPeon, NPCID.GoblinThief, NPCID.GoblinWarrior, NPCID.GoblinSorcerer, NPCID.GoblinArcher, NPCID.GoblinSummoner);
            OldOnesArmy = (DD2Event.Ongoing && Main.invasionProgressNearInvasion) ||
                MusicUtilities.NPCNearby(NPCID.DD2EterniaCrystal, NPCID.DD2LanePortal, NPCID.DD2Betsy, NPCID.DD2GoblinT1, NPCID.DD2GoblinT2, NPCID.DD2GoblinT3,
                NPCID.DD2GoblinBomberT1, NPCID.DD2GoblinBomberT2, NPCID.DD2GoblinBomberT3, NPCID.DD2WyvernT1, NPCID.DD2WyvernT2, NPCID.DD2WyvernT3,
                NPCID.DD2JavelinstT1, NPCID.DD2JavelinstT2, NPCID.DD2JavelinstT3, NPCID.DD2DarkMageT1, NPCID.DD2DarkMageT3, NPCID.DD2SkeletonT1,
                NPCID.DD2SkeletonT3, NPCID.DD2WitherBeastT2, NPCID.DD2WitherBeastT3, NPCID.DD2DrakinT2, NPCID.DD2DrakinT3, NPCID.DD2KoboldWalkerT2,
                NPCID.DD2KoboldWalkerT3, NPCID.DD2KoboldFlyerT2, NPCID.DD2KoboldFlyerT3, NPCID.DD2OgreT2, NPCID.DD2OgreT3, NPCID.DD2LightningBugT3);
            FrostLegion = (Main.invasionType == InvasionID.SnowLegion && Main.invasionProgressNearInvasion) ||
                MusicUtilities.NPCNearby(NPCID.SnowmanGangsta, NPCID.MisterStabby, NPCID.SnowBalla);
            PirateInvasion = (Main.invasionType == InvasionID.PirateInvasion && Main.invasionProgressNearInvasion) ||
                MusicUtilities.NPCNearby(NPCID.Parrot, NPCID.PirateCaptain, NPCID.PirateCorsair, NPCID.PirateCrossbower, NPCID.PirateDeadeye, NPCID.PirateDeckhand,
                NPCID.PirateShip);
            MartianMadness = (Main.invasionType == InvasionID.MartianMadness && Main.invasionProgressNearInvasion) ||
                MusicUtilities.NPCNearby(NPCID.MartianSaucerCore, NPCID.ScutlixRider, NPCID.Scutlix, NPCID.MartianWalker, NPCID.MartianDrone, NPCID.MartianTurret,
                NPCID.GigaZapper, NPCID.MartianEngineer, NPCID.MartianOfficer, NPCID.RayGunner, NPCID.GrayGrunt, NPCID.BrainScrambler);

            TorchGod = player.happyFunTorchTime || MusicUtilities.NPCNearby(NPCID.TorchGod);
            VortexPillar = player.ZoneTowerVortex || MusicUtilities.NPCNearby(NPCID.LunarTowerVortex);
            NebulaPillar = player.ZoneTowerNebula || MusicUtilities.NPCNearby(NPCID.LunarTowerNebula);
            StardustPillar = player.ZoneTowerStardust || MusicUtilities.NPCNearby(NPCID.LunarTowerStardust);
            SolarPillar = player.ZoneTowerSolar || MusicUtilities.NPCNearby(NPCID.LunarTowerSolar);
            #endregion

            #region Misc Flags
            MechEngaging = BossCountdowns.MechCountdown > 0;
            CultistRitual = MusicUtilities.NPCNearby(NPCID.CultistArcherBlue, NPCID.CultistTablet, NPCID.CultistTablet) && !MusicUtilities.NPCNearby(NPCID.CultistBoss);
            ImpendingDoom = BossCountdowns.ImpendingDoomCountdown > 0 || NPC.MoonLordCountdown > 0;
            #endregion

            #region Boss Flags
            DefeatedQueenBee = NPC.downedQueenBee;
            DefeatedDeerclops = NPC.downedDeerclops;
            DefeatedSkeletron = NPC.downedBoss3;
            DefeatedQueenSlime = NPC.downedQueenSlime;
            DefeatedAnyMech = NPC.downedMechBossAny;
            DefeatedPlantera = NPC.downedPlantBoss;
            DefeatedGolem = NPC.downedGolemBoss;
            DefeatedDukeFishron = NPC.downedFishron;
            DefeatedEmpressofLight = NPC.downedEmpressOfLight;
            DefeatedLunaticCultist = NPC.downedAncientCultist;

            BossMusicTileRange = 525f * 16f; // 525 tile radius.

            SimultaneousMechs = (MechaMayhem && MusicUtilities.NPCNearby(NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail)) ||
                (MechaMayhem && MusicUtilities.NPCNearby(NPCID.Spazmatism, NPCID.Retinazer)) ||
                (MechaMayhem && MusicUtilities.NPCNearby(NPCID.SkeletronPrime));
            if (MusicUtilities.NPCNearby(NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail) && MusicUtilities.NPCNearby(NPCID.Spazmatism, NPCID.Retinazer) && MusicUtilities.NPCNearby(NPCID.SkeletronPrime))
                MechaMayhem = true;
            else if (!MusicUtilities.NPCNearby(NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail) && !MusicUtilities.NPCNearby(NPCID.Spazmatism, NPCID.Retinazer) && !MusicUtilities.NPCNearby(NPCID.SkeletronPrime))
                MechaMayhem = false;
            #endregion

            #region Calamity Flags
            if (calamityMod)
            {
                RevengeanceMode = (bool)calamitymod.Call("GetDifficultyActive", "revengeance");
                DeathMode = (bool)calamitymod.Call("GetDifficultyActive", "death");
                BossRush = (bool)calamitymod.Call("GetDifficultyActive", "bossrush");

                SunkenSea = (bool)calamitymod.Call("GetInZone", player, "sunkensea");
                SulphurousSea = (bool)calamitymod.Call("GetInZone", player, "sulphursea") && !Abyss;
                AstralInfection = (bool)calamitymod.Call("GetInZone", player, "astral");
                Abyss = (bool)calamitymod.Call("GetInZone", player, "abyss");
                SulphuricDepths = (bool)calamitymod.Call("GetInZone", player, "layer1");
                MurkyWaters = (bool)calamitymod.Call("GetInZone", player, "layer2");
                ThermalVents = (bool)calamitymod.Call("GetInZone", player, "layer3");
                TheVoid = (bool)calamitymod.Call("GetInZone", player, "layer4");
                BrimstoneCrags = (bool)calamitymod.Call("GetInZone", player, "crags");

                CosmicAnvil = calamitymod.Find<ModTile>("CosmicAnvil").Type;
                DraedonsForge = calamitymod.Find<ModTile>("DraedonsForge").Type;

                DefeatedHiveMind = (bool)calamitymod.Call("GetBossDowned", "hivemind");
                DefeatedPerforators = (bool)calamitymod.Call("GetBossDowned", "perforator");
                DefeatedSlimeGod = (bool)calamitymod.Call("GetBossDowned", "slimegod");
                DefeatedCryogen = (bool)calamitymod.Call("GetBossDowned", "cryogen");
                DefeatedAquaticScourge = (bool)calamitymod.Call("GetBossDowned", "aquaticscourge");
                DefeatedBrimstoneElemental = (bool)calamitymod.Call("GetBossDowned", "brimstoneelemental");
                DefeatedCalamitasClone = (bool)calamitymod.Call("GetBossDowned", "calamitasclone");
                DefeatedLeviathan = (bool)calamitymod.Call("GetBossDowned", "anahitaleviathan");
                DefeatedAstrumAureus = (bool)calamitymod.Call("GetBossDowned", "astrumaureus");
                DefeatedPlaguebringerGoliath = (bool)calamitymod.Call("GetBossDowned", "plaguebringergoliath");
                DefeatedRavager = (bool)calamitymod.Call("GetBossDowned", "ravager");
                DefeatedAstrumDeus = (bool)calamitymod.Call("GetBossDowned", "astrumdeus");
                DefeatedDragonfolly = (bool)calamitymod.Call("GetBossDowned", "dragonfolly");
                DefeatedProfanedGuardians = (bool)calamitymod.Call("GetBossDowned", "guardians");
                DefeatedProvidence = (bool)calamitymod.Call("GetBossDowned", "providence");
                DefeatedCeaselessVoid = (bool)calamitymod.Call("GetBossDowned", "ceaselessvoid");
                DefeatedStormWeaver = (bool)calamitymod.Call("GetBossDowned", "stormweaver");
                DefeatedSignus = (bool)calamitymod.Call("GetBossDowned", "signus");
                DefeatedPolterghast = (bool)calamitymod.Call("GetBossDowned", "polterghast");
                DefeatedOldDuke = (bool)calamitymod.Call("GetBossDowned", "oldduke");
                DefeatedDevourerofGods = (bool)calamitymod.Call("GetBossDowned", "devourerofgods");
                DefeatedYharon = (bool)calamitymod.Call("GetBossDowned", "yharon");
                DefeatedExoMechs = (bool)calamitymod.Call("GetBossDowned", "exomechs");
                DefeatedCalamitas = (bool)calamitymod.Call("GetBossDowned", "calamitas");

                NotInCalamityMusicEvent = MusicUtilities.CalamityMusicEvent() == null;
            }
            #endregion

            #region Other Modded Flags
            if (infernumMod)
            {
                InfernumMode = (bool)infernummod.Call("GetInfernumActive");

                ProfanedTemple = player.InModBiome(infernummod.Find<ModBiome>("ProfanedTempleBiome"));
                LostColosseum = player.InModBiome(infernummod.Find<ModBiome>("LostColosseumBiome"));
            }

            if (remnantsMod)
            {
                RemnantsPyramid = player.InModBiome(remnantsmod.Find<ModBiome>("Pyramid"));
                RemnantsGraniteCave = player.InModBiome(remnantsmod.Find<ModBiome>("GraniteCave"));
                RemnantsMarbleCave = player.InModBiome(remnantsmod.Find<ModBiome>("MarbleCave"));
                RemnantsHive = player.InModBiome(remnantsmod.Find<ModBiome>("Beehive"));
            }

            if (magicStorage)
            {
                StorageHeart = magicstorage.Find<ModTile>("StorageHeart").Type;
                CraftingUnit = magicstorage.Find<ModTile>("CraftingAccess").Type;

                MagicStorageWorkshop = WorkshopDetection.TileDistance(StorageHeart, CraftingUnit) <= WorkshopRange &&
                    TileCounts.StorageHeartTileCount > 0 && TileCounts.CraftingUnitTileCount > 0;
                MagicStorageTier2Progression = DefeatedHiveMind || DefeatedPerforators || DefeatedQueenBee || DefeatedDeerclops || DefeatedSkeletron || DefeatedSlimeGod;
                MagicStorageTier3Progression = Hardmode || DefeatedQueenSlime || DefeatedCryogen || DefeatedAnyMech || DefeatedAquaticScourge || DefeatedBrimstoneElemental ||
                    DefeatedCalamitasClone;
                MagicStorageTier4Progression = DefeatedPlantera || DefeatedLeviathan || DefeatedAstrumAureus || DefeatedGolem || DefeatedPlaguebringerGoliath || DefeatedDukeFishron ||
                    DefeatedRavager || DefeatedEmpressofLight || DefeatedLunaticCultist || DefeatedAstrumDeus;
                MagicStorageTier5Progression = Endgame || DefeatedProfanedGuardians || DefeatedDragonfolly || DefeatedProvidence || DefeatedCeaselessVoid || DefeatedStormWeaver ||
                    DefeatedSignus || DefeatedPolterghast || DefeatedOldDuke || DefeatedDevourerofGods || DefeatedYharon;
                MagicStorageTier6Progression = DefeatedExoMechs || DefeatedCalamitas;
            }
            #endregion
        }
    }
}