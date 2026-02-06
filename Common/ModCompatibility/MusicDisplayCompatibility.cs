using Terraria.Localization;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.ModCompatibility
{
    public class MusicDisplayCompatibility : ModSystem
    {
        public override void PostSetupContent()
        {
            MusicDisplaySetup();
        }

        public void MusicDisplaySetup()
        {
            var musicDisplay = ModLoader.TryGetMod("MusicDisplay", out Mod musicdisplay);

            if (!musicDisplay)
            {
                return;
            }

            void AddMusic(string songKey, string authorKey, string songType)
            {
                short slot = (short)MusicLoader.GetMusicSlot(Mod, $"Assets/Music/{songType}/{songKey}");
                musicdisplay.Call("AddMusic", slot, Language.GetTextValue("Mods.UnCalamityModMusic.ModSupport.MusicDisplay.SongNames." + songKey), Language.GetTextValue("Mods.UnCalamityModMusic.ModSupport.MusicDisplay.Authors." + authorKey), Mod.DisplayName);
            }

            // Biomes
            AddMusic("Aether", "Forge", "Biomes");
            AddMusic("Caverns", "HeartPlusUp", "Biomes");
            AddMusic("Corruption", "HeartPlusUp", "Biomes");
            AddMusic("CorruptionUnderground", "HeartPlusUp", "Biomes");
            AddMusic("Crimson", "SkippyZii", "Biomes");
            AddMusic("CrimsonUnderground", "SkippyZii", "Biomes");
            AddMusic("Desert", "HeartPlusUp", "Biomes");
            //AddMusic("DesertUnderground", "", "Biomes");
            AddMusic("Dungeon", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayAfternoon", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayDawn", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayEvening", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayMorning", "HeartPlusUp", "Biomes");
            AddMusic("ForestNight", "HeartPlusUp", "Biomes");
            AddMusic("Geodes", "HeartPlusUp", "Biomes");
            AddMusic("GlowingMushroomFields", "HeartPlusUp", "Biomes");
            //AddMusic("Graveyard", "", "Biomes");
            //AddMusic("Hallow", "", "Biomes");
            //AddMusic("HallowUnderground", "", "Biomes");
            AddMusic("JungleDay", "HeartPlusUp", "Biomes");
            //AddMusic("JungleNight", "", "Biomes");
            //AddMusic("JungleUnderground", "", "Biomes");
            //AddMusic("JungleTemple", "", "Biomes");
            AddMusic("Meteorite", "HeartPlusUp", "Biomes");
            AddMusic("OceanDay", "HeartPlusUp", "Biomes");
            AddMusic("OceanNight", "HeartPlusUp", "Biomes");
            AddMusic("Space", "HeartPlusUp", "Biomes");
            AddMusic("TownDay", "HeartPlusUp", "Biomes");
            AddMusic("TownNight", "HeartPlusUp", "Biomes");
            AddMusic("TownNight_Noiseless", "HeartPlusUp", "Biomes");
            AddMusic("Tundra", "HeartPlusUp", "Biomes");
            AddMusic("TundraUnderground", "HeartPlusUp", "Biomes");
            AddMusic("Underworld", "HeartPlusUp", "Biomes");
            AddMusic("Underground", "HeartPlusUp", "Biomes");
            //AddMusic("UndergroundEndgame", "", "Biomes");
            //AddMusic("UndergroundHardmode", "", "Biomes");
            AddMusic("WorkshopTier1", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier2", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier3", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier4", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier5", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier6", "HeartPlusUp", "Biomes");

            // Bosses
            AddMusic("BrainofCthulhu", "SkippyZiiFeature", "Bosses");
            //AddMusic("Deerclops", "", "Bosses");
            //AddMusic("Destroyer", "", "Bosses");
            //AddMusic("Dreadnautilus", "", "Bosses");
            AddMusic("DukeFishron", "TYESKI", "Bosses");
            AddMusic("EaterofWorlds", "HeartPlusUp", "Bosses");
            //AddMusic("EmpressofLight", "", "Bosses");
            AddMusic("EyeofCthulhu", "HeartPlusUpFeature", "Bosses");
            //AddMusic("Golem", "", "Bosses");
            AddMusic("KingSlime", "HeartPlusUp", "Bosses");
            //AddMusic("LunaticCultist", "", "Bosses");
            //AddMusic("Mechs", "", "Bosses");
            AddMusic("MoonLord", "psykomatic", "Bosses");
            //AddMusic("Plantera", "", "Bosses");
            //AddMusic("QueenBee", "", "Bosses");
            //AddMusic("QueenSlime", "", "Bosses");
            AddMusic("Skeletron", "HeartPlusUp", "Bosses");
            //AddMusic("SkeletronPrime", "", "Bosses");
            //AddMusic("Twins", "", "Bosses");
            AddMusic("WallofFlesh", "HeartPlusUp", "Bosses");

            // Events
            //AddMusic("Blizzard", "", "Events");
            AddMusic("BloodMoon", "Thriplerex", "Events");
            AddMusic("BloodMoonDeath", "Thriplerex", "Events");
            //AddMusic("CelestialPillarNebula", "", "Events");
            //AddMusic("CelestialPillarSolar", "", "Events");
            //AddMusic("CelestialPillarStardust", "", "Events");
            //AddMusic("CelestialPillarVortex", "", "Events");
            //AddMusic("GoblinArmy", "", "Events");
            //AddMusic("MartianMadness", "", "Events");
            //AddMusic("FrostMoon", "", "Events");
            AddMusic("LanternFestival", "HeartPlusUp", "Events");
            AddMusic("OceanRain", "HeartPlusUp", "Events");
            //AddMusic("OldOnesArmyTier1", "", "Events");
            //AddMusic("OldOnesArmyTier2", "", "Events");
            //AddMusic("OldOnesArmyTier3", "", "Events");
            //AddMusic("PirateInvasion", "", "Events");
            //AddMusic("PumpkinMoon", "", "Events");
            AddMusic("RainDay", "HeartPlusUp", "Events");
            AddMusic("RainNight", "HeartPlusUp", "Events");
            //AddMusic("SolarEclipse", "", "Events");
            AddMusic("Sandstorm", "TYESKI", "Events");
            AddMusic("SlimeRain", "HeartPlusUp", "Events");
            //AddMusic("Thunderstorm", "", "Events");
            AddMusic("TorchGod", "HeartPlusUp", "Events");
            AddMusic("TorchGodRevengeance", "HeartPlusUp", "Events");
            AddMusic("TownParty", "HeartPlusUp", "Events");
            AddMusic("TownRain", "HeartPlusUp", "Events");
            //AddMusic("WindyDay", "", "Events");

            // Misc
            //AddMusic("CultistRitual", "", "Misc");
            //AddMusic("DragonsLull", "", "Misc");
            AddMusic("FalseEpilogue", "HeartPlusUp", "Misc");
            AddMusic("HardmodeInterlude", "Salvati", "Misc");
            //AddMusic("ImpendingDoom", "", "Misc");
            //AddMusic("MechEngaging", "", "Misc");
            AddMusic("RainLegacy", "HeartPlusUp", "Misc");
        }
    }
}
