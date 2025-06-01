using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.Music
{
    public class TorchGod : ModSceneEffect
    {
        public override int Music => PlayerFlags.revengeanceMode ? MusicPathing.GetMusicSlot("TorchGodRevengeance") : MusicPathing.GetMusicSlot("TorchGod");

        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override bool IsSceneEffectActive(Player player)
        {
            return player.happyFunTorchTime || (NPC.AnyNPCs(NPCID.TorchGod) && Main.npc[NPC.FindFirstNPC(NPCID.TorchGod)].Distance(player.Center) <= PlayerFlags.MusicTileRange);
        }
    }
    public class LunarTowersSolar : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("LunarTowersSolar");

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneTowerSolar || (NPC.AnyNPCs(NPCID.LunarTowerSolar) && Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerSolar)].Distance(player.Center) <= PlayerFlags.MusicTileRange);
		}*/
    }
    public class LunarTowersStardust : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("LunarTowersStardust");

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneTowerStardust || (NPC.AnyNPCs(NPCID.LunarTowerStardust) && Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerStardust)].Distance(player.Center) <= PlayerFlags.MusicTileRange);
		}*/
    }
    public class LunarTowersNebula : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("LunarTowersNebula");

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneTowerNebula || (NPC.AnyNPCs(NPCID.LunarTowerNebula) && Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerNebula)].Distance(player.Center) <= PlayerFlags.MusicTileRange);
		}*/
    }
    public class LunarTowersVortex : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("LunarTowersVortex");

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			return player.ZoneTowerVortex || (NPC.AnyNPCs(NPCID.LunarTowerVortex) && Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerVortex)].Distance(player.Center) <= PlayerFlags.MusicTileRange);
		}*/
    }
    public class MartianMadness : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("MartianMadness");

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = Main.invasionType == 4 && Main.invasionProgressNearInvasion;
			bool condition2 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MartianSaucerCore) && Main.npc[NPC.FindFirstNPC(NPCID.MartianSaucerCore)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.ScutlixRider) && Main.npc[NPC.FindFirstNPC(NPCID.ScutlixRider)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition4 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.Scutlix) && Main.npc[NPC.FindFirstNPC(NPCID.Scutlix)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition5 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MartianWalker) && Main.npc[NPC.FindFirstNPC(NPCID.MartianWalker)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition6 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MartianDrone) && Main.npc[NPC.FindFirstNPC(NPCID.MartianDrone)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition7 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MartianTurret) && Main.npc[NPC.FindFirstNPC(NPCID.MartianTurret)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition8 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GigaZapper) && Main.npc[NPC.FindFirstNPC(NPCID.GigaZapper)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition9 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MartianEngineer) && Main.npc[NPC.FindFirstNPC(NPCID.MartianEngineer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition10 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MartianOfficer) && Main.npc[NPC.FindFirstNPC(NPCID.MartianOfficer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition11 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.RayGunner) && Main.npc[NPC.FindFirstNPC(NPCID.RayGunner)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition12 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GrayGrunt) && Main.npc[NPC.FindFirstNPC(NPCID.GrayGrunt)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition13 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.BrainScrambler) && Main.npc[NPC.FindFirstNPC(NPCID.BrainScrambler)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3 || condition4 || condition5 || condition6 || condition7 || condition8 || condition9 || condition10 || condition11 || condition12 || condition13;
		}*/
    }
    public class FrostMoon : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("FrostMoon");

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.snowMoon && (PlayerFlags.onSurface || Main.remixWorld);
		}*/
    }
    public class PumpkinMoon : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("PumpkinMoon");

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool IsSceneEffectActive(Player player)
		{
			return Main.pumpkinMoon && (PlayerFlags.onSurface || Main.remixWorld);
		}*/
    }
    public class OldOnesArmy : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("OldOnesArmy");

		public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = DD2Event.Ongoing && Main.invasionProgressNearInvasion;
			bool condition2 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2EterniaCrystal) && Main.npc[NPC.FindFirstNPC(NPCID.DD2EterniaCrystal)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2LanePortal) && Main.npc[NPC.FindFirstNPC(NPCID.DD2LanePortal)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition4 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2Betsy) && Main.npc[NPC.FindFirstNPC(NPCID.DD2Betsy)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition5 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2GoblinT1) && Main.npc[NPC.FindFirstNPC(NPCID.DD2GoblinT1)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition6 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2GoblinT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2GoblinT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition7 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2GoblinT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2GoblinT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition8 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2GoblinBomberT1) && Main.npc[NPC.FindFirstNPC(NPCID.DD2GoblinBomberT1)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition9 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2GoblinBomberT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2GoblinBomberT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition10 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2GoblinBomberT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2GoblinBomberT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition11 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2WyvernT1) && Main.npc[NPC.FindFirstNPC(NPCID.DD2WyvernT1)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition12 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2WyvernT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2WyvernT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition13 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2WyvernT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2WyvernT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition14 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2JavelinstT1) && Main.npc[NPC.FindFirstNPC(NPCID.DD2JavelinstT1)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition15 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2JavelinstT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2JavelinstT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition16 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2JavelinstT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2JavelinstT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition17 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2DarkMageT1) && Main.npc[NPC.FindFirstNPC(NPCID.DD2DarkMageT1)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition18 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2DarkMageT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2DarkMageT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition19 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2SkeletonT1) && Main.npc[NPC.FindFirstNPC(NPCID.DD2SkeletonT1)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition20 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2SkeletonT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2SkeletonT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition21 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2WitherBeastT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2WitherBeastT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition22 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2WitherBeastT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2WitherBeastT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition23 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2DrakinT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2DrakinT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition24 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2DrakinT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2DrakinT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition25 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2KoboldWalkerT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2KoboldWalkerT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition26 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2KoboldWalkerT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2KoboldWalkerT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition27 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2KoboldFlyerT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2KoboldFlyerT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition28 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2KoboldFlyerT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2KoboldFlyerT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition29 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2OgreT2) && Main.npc[NPC.FindFirstNPC(NPCID.DD2OgreT2)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition30 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2OgreT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2OgreT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition31 = !DD2Event.Ongoing && NPC.AnyNPCs(NPCID.DD2LightningBugT3) && Main.npc[NPC.FindFirstNPC(NPCID.DD2LightningBugT3)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3 || condition4 || condition5 || condition6 || condition7 || condition8 || condition9 || condition10 || condition11 || condition12 || condition13 || condition14 || condition15 || condition16 || condition17 || condition18 || condition19 || condition20 || condition21 || condition22 || condition23 || condition24 || condition25 || condition26 || condition27 || condition28 || condition29 || condition30 || condition31;
		}*/
    }
    public class PirateInvasion : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("PirateInvasion");

		public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = Main.invasionType == 3 && Main.invasionProgressNearInvasion;
			bool condition2 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.Parrot) && Main.npc[NPC.FindFirstNPC(NPCID.Parrot)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.PirateCaptain) && Main.npc[NPC.FindFirstNPC(NPCID.PirateCaptain)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition4 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.PirateCorsair) && Main.npc[NPC.FindFirstNPC(NPCID.PirateCorsair)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition5 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.PirateCrossbower) && Main.npc[NPC.FindFirstNPC(NPCID.PirateCrossbower)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition6 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.PirateDeadeye) && Main.npc[NPC.FindFirstNPC(NPCID.PirateDeadeye)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition7 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.PirateDeckhand) && Main.npc[NPC.FindFirstNPC(NPCID.PirateDeckhand)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition8 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.PirateShip) && Main.npc[NPC.FindFirstNPC(NPCID.PirateShip)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3 || condition4 || condition5 || condition6 || condition7 || condition8;
		}*/
    }
    public class FrostLegion : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("FrostLegion");

		public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = Main.invasionType == 2 && Main.invasionProgressNearInvasion;
			bool condition2 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.SnowmanGangsta) && Main.npc[NPC.FindFirstNPC(NPCID.SnowmanGangsta)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.MisterStabby) && Main.npc[NPC.FindFirstNPC(NPCID.MisterStabby)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition4 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.SnowBalla) && Main.npc[NPC.FindFirstNPC(NPCID.SnowBalla)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3 || condition4;
		}*/
    }
    public class GoblinArmy : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("GoblinArmy");

		public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = Main.invasionType == 1 && Main.invasionProgressNearInvasion;
			bool condition2 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GoblinPeon) && Main.npc[NPC.FindFirstNPC(NPCID.GoblinPeon)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition3 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GoblinThief) && Main.npc[NPC.FindFirstNPC(NPCID.GoblinThief)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition4 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GoblinWarrior) && Main.npc[NPC.FindFirstNPC(NPCID.GoblinWarrior)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition5 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GoblinSorcerer) && Main.npc[NPC.FindFirstNPC(NPCID.GoblinSorcerer)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition6 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GoblinArcher) && Main.npc[NPC.FindFirstNPC(NPCID.GoblinArcher)].Distance(player.Center) <= PlayerFlags.MusicTileRange;
			bool condition7 = Main.invasionType == 0 && NPC.AnyNPCs(NPCID.GoblinSummoner) && Main.npc[NPC.FindFirstNPC(NPCID.GoblinSummoner)].Distance(player.Center) <= PlayerFlags.MusicTileRange;

			return condition1 || condition2 || condition3 || condition4 || condition5 || condition6 || condition7;
		}*/
    }
    public class SolarEclipse : ModSceneEffect
    {
        //public override int Music => MusicPathing.GetMusicSlot("SolarEclipse");
        public override int Music
        {
            get
            {
                bool otherworldMusicActive = PlayerFlags.SwapMusic();
                return otherworldMusicActive ? MusicID.OtherworldlyEerie : MusicID.Eclipse;
            }
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = !Main.remixWorld && Main.eclipse && PlayerFlags.onSurface;
            bool condition2 = Main.remixWorld && Main.eclipse && (double)Main.LocalPlayer.position.Y > Main.rockLayer * 16.0 && !(PlayerFlags.ZoneBrimstoneCrags || PlayerFlags.ZoneProfanedTemple);

            return condition1 || condition2;
        }
    }
    public class BloodMoon : ModSceneEffect
    {
        public override int Music => PlayerFlags.deathMode ? MusicPathing.GetMusicSlot("BloodMoonDeath") : MusicPathing.GetMusicSlot("BloodMoon");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = !Main.remixWorld && Main.bloodMoon && PlayerFlags.onSurface && !(PlayerFlags.inSpace || player.ZoneCorrupt || player.ZoneCrimson || PlayerFlags.ZoneAstralInfection);
            bool condition2 = Main.remixWorld && Main.bloodMoon && (double)Main.LocalPlayer.position.Y > Main.rockLayer * 16.0 && player.position.Y <= (float)(Main.UnderworldLayer * 16) && !(player.ZoneCorrupt || player.ZoneCrimson || PlayerFlags.ZoneAstralInfection);
            bool condition3 = Main.remixWorld && Main.bloodMoon && player.position.Y > (float)(Main.UnderworldLayer * 16) && (double)(player.Center.X / 16f) > (double)Main.maxTilesX * 0.37 + 50.0 && (double)(player.Center.X / 16f) < (double)Main.maxTilesX * 0.63;

            return condition1 || condition2 || condition3;
        }
    }
    public class Blizzard : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("Blizzard");

		public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = !Main.remixWorld && PlayerFlags.isRaining && player.ZoneSnow && PlayerFlags.onSurface && !(PlayerFlags.inSpace || PlayerFlags.ZoneAstralInfection) && !(Main.bloodMoon || Main.eclipse);
			bool condition2 = Main.remixWorld && PlayerFlags.isRaining && player.ZoneSnow && PlayerFlags.onRemixedSurface && !(PlayerFlags.inSpace || PlayerFlags.ZoneAstralInfection) && !(Main.bloodMoon || Main.eclipse);

			return condition1 || condition2;
		}*/
    }
    public class Sandstorm : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("Sandstorm");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = !Main.remixWorld && PlayerFlags.ZoneSandstorm && !PlayerFlags.ugDesertOriginalHeight && !(PlayerFlags.inSpace || PlayerFlags.ZoneAstralInfection) && !(Main.bloodMoon || Main.eclipse);
            bool condition2 = Main.remixWorld && PlayerFlags.ZoneSandstorm && PlayerFlags.onRemixedSurface && !(PlayerFlags.inSpace || PlayerFlags.ZoneAstralInfection) && !(Main.bloodMoon || Main.eclipse);

            return condition1 || condition2;
        }
    }
    public class SlimeRain : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("SlimeRain");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Player player)
        {
            return Main.slimeRain && PlayerFlags.onSurface && !(player.ZoneGraveyard || PlayerFlags.inSpace) && !(Main.bloodMoon || Main.eclipse);
        }
    }
    public class OceanRain : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("OceanRain");

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = !Main.remixWorld && PlayerFlags.isRaining && player.ZoneBeach && PlayerFlags.ZoneOverworldHeightExtra && !(player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor);
            bool condition2 = Main.remixWorld && PlayerFlags.isRaining && player.ZoneBeach && (double)(player.position.Y / 16f) > Main.rockLayer && player.position.Y / 16f < (float)(Main.maxTilesY - 350) && !(player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor);

            return condition1 || condition2;
        }
    }
    public class Thunderstorm : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("Thunderstorm");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = !Main.remixWorld && Main._shouldUseStormMusic && PlayerFlags.ZoneOverworldHeightExtra && !(player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor);
			bool condition2 = Main.remixWorld && Main._shouldUseStormMusic && (double)(player.position.Y / 16f) > Main.rockLayer && player.position.Y / 16f < (float)(Main.maxTilesY - 350) && !(player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor);

			return condition1 || condition2;
		}*/
    }
    public class TownRain : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("TownRain");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Player player)
        {
            return PlayerFlags.inTownWithRain && PlayerFlags.notInExcludedTownBiome && !(/*Main._shouldUseStormMusic || */player.ZoneBeach || player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor || PlayerFlags.ZoneSulfurSea);
        }
    }
    public class Rain : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("Rain");

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = !Main.remixWorld && PlayerFlags.isRaining && PlayerFlags.ZoneOverworldHeightExtra && !(/*Main._shouldUseStormMusic || */player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor);
            bool condition2 = Main.remixWorld && PlayerFlags.isRaining && (double)(player.position.Y / 16f) > Main.rockLayer && player.position.Y / 16f < (float)(Main.maxTilesY - 350) && !(/*Main._shouldUseStormMusic || */player.ZoneSnow || player.ZoneGraveyard || player.ZoneMeteor);

            return condition1 || condition2;
        }
    }
    public class TownParty : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("TownParty");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment + 1;

        public override bool IsSceneEffectActive(Player player)
        {
            bool condition1 = BirthdayParty.PartyIsUp && PlayerFlags.inTown && PlayerFlags.notInExcludedTownBiome && PlayerFlags.notRaining;
            bool condition2 = BirthdayParty.PartyIsUp && PlayerFlags.inUgTown && PlayerFlags.notInExcludedTownBiome;

            return condition1 || condition2;
        }
    }
    public class WindyDay : ModSceneEffect
    {
        /*public override int Music => MusicPathing.GetMusicSlot("WindyDay");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

		public override bool IsSceneEffectActive(Player player)
		{
			bool condition1 = !Main.remixWorld && Main._shouldUseWindyDayMusic && PlayerFlags.ZoneOverworldHeightExtra && !(player.ZoneDesert || player.ZoneBeach || player.ZoneHallow || player.ZoneSnow || player.ZoneJungle || player.ZoneGraveyard || player.ZoneMeteor);
			bool condition2 = Main.remixWorld && Main._shouldUseWindyDayMusic && (double)(player.position.Y / 16f) > Main.rockLayer && player.position.Y / 16f < (float)(Main.maxTilesY - 350) && !(player.ZoneDesert || player.ZoneBeach || player.ZoneSnow || player.ZoneJungle || player.ZoneGraveyard || player.ZoneMeteor);

			return condition1 || condition2;
		}*/
    }
    public class LanternFestival : ModSceneEffect
    {
        public override int Music => MusicPathing.GetMusicSlot("LanternFestival");

        public override SceneEffectPriority Priority => PlayerFlags.inTown ? SceneEffectPriority.Environment : SceneEffectPriority.BiomeMedium;

        public override bool IsSceneEffectActive(Player player)
        {
            return LanternNight.LanternsUp && PlayerFlags.ZoneOverworldHeightExtra && PlayerFlags.notRaining && !(player.ZoneGraveyard || player.ZoneMeteor);
        }
    }
}