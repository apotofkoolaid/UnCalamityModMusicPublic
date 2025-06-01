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
            var musicDisplay = ModLoader.TryGetMod("MusicDisplay", out Mod display);

            if (!musicDisplay)
            {
                return;
            }

            void AddMusic(string songKey, string authorKey, string songType)
            {
                short slot = (short)MusicLoader.GetMusicSlot(Mod, $"Assets/Music/{songType}/{songKey}");
                display.Call("AddMusic", slot, Language.GetTextValue("Mods.UnCalamityModMusic.ModSupport.MusicDisplay.SongNames." + songKey), Language.GetTextValue("Mods.UnCalamityModMusic.ModSupport.MusicDisplay.Authors." + authorKey), Mod.DisplayName);
            }

            AddMusic("AbyssLayer3Alt", "HeartPlusUp", "Alternates");
            AddMusic("Space", "HeartPlusUp", "Biomes");
            AddMusic("Underworld", "HeartPlusUp", "Biomes");
            //AddMusic("Aether", "", "Biomes");
            //AddMusic("Graveyard", "", "Biomes");
            AddMusic("Meteorite", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier6", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier5", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier4", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier3", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier2", "HeartPlusUp", "Biomes");
            AddMusic("WorkshopTier1", "HeartPlusUp", "Biomes");
            AddMusic("TownNight", "HeartPlusUp", "Biomes");
            AddMusic("TownNight_Noiseless", "HeartPlusUp", "Biomes");
            AddMusic("TownDay", "HeartPlusUp", "Biomes");
            //AddMusic("JungleTemple", "", "Biomes");
            AddMusic("Dungeon", "HeartPlusUp", "Biomes");
            AddMusic("GlowingMushroomFields", "HeartPlusUp", "Biomes");
            AddMusic("Corruption", "HeartPlusUp", "Biomes");
            AddMusic("CorruptionUnderground", "HeartPlusUp", "Biomes");
            AddMusic("Crimson", "SkippyZii", "Biomes");
            AddMusic("CrimsonUnderground", "SkippyZii", "Biomes");
            AddMusic("Geodes", "HeartPlusUp", "Biomes");
            //AddMusic("JungleNight", "", "Biomes");
            AddMusic("JungleDay", "", "Biomes");
            //AddMusic("JungleUnderground", "", "Biomes");
            AddMusic("Tundra", "HeartPlusUp", "Biomes");
            AddMusic("TundraUnderground", "HeartPlusUp", "Biomes");
            //AddMusic("Hallow", "", "Biomes");
            //AddMusic("HallowUnderground", "", "Biomes");
            //AddMusic("DesertUnderground", "", "Biomes");
            //AddMusic("UndergroundHardmode", "", "Biomes");
            AddMusic("Caverns", "HeartPlusUp", "Biomes");
            AddMusic("Underground", "HeartPlusUp", "Biomes");
            AddMusic("OceanNight", "HeartPlusUp", "Biomes");
            AddMusic("OceanDay", "HeartPlusUp", "Biomes");
            AddMusic("Desert", "HeartPlusUp", "Biomes");
            AddMusic("ForestNight", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayEvening", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayAfternoon", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayMorning", "HeartPlusUp", "Biomes");
            AddMusic("ForestDayDawn", "HeartPlusUp", "Biomes");
            AddMusic("MoonLord", "psykomatic", "Bosses");
            //AddMusic("LunaticCultist", "", "Bosses");
            //AddMusic("EmpressofLight", "", "Bosses");
            //AddMusic("DukeFishron", "", "Bosses");
            //AddMusic("Golem", "", "Bosses");
            //AddMusic("Plantera", "", "Bosses");
            //AddMusic("Mechs", "", "Bosses");
            //AddMusic("SkeletronPrime", "", "Bosses");
            //AddMusic("Twins", "", "Bosses");
            //AddMusic("Destroyer", "", "Bosses");
            //AddMusic("QueenSlime", "", "Bosses");
            AddMusic("WallofFlesh", "HeartPlusUp", "Bosses");
            AddMusic("Skeletron", "HeartPlusUp", "Bosses");
            //AddMusic("QueenBee", "", "Bosses");
            AddMusic("BrainofCthulhu", "HeartPlusUpFeature2", "Bosses");
            AddMusic("EaterofWorlds", "HeartPlusUp", "Bosses");
            AddMusic("EyeofCthulhu", "HeartPlusUpFeature1", "Bosses");
            AddMusic("KingSlime", "HeartPlusUp", "Bosses");
            AddMusic("TorchGod", "HeartPlusUp", "Events");
            AddMusic("TorchGodRevengeance", "HeartPlusUp", "Events");
            //AddMusic("CelestialPillarSolar", "", "Events");
            //AddMusic("CelestialPillarStardust", "", "Events");
            //AddMusic("CelestialPillarNebula", "", "Events");
            //AddMusic("CelestialPillarVortex", "", "Events");
            //AddMusic("MartianMadness", "", "Events");
            //AddMusic("FrostMoon", "", "Events");
            //AddMusic("PumpkinMoon", "", "Events");
            //AddMusic("PirateInvasion", "", "Events");
            //AddMusic("FrostLegion", "", "Events");
            //AddMusic("GoblinArmy", "", "Events");
            //AddMusic("SolarEclipse", "", "Events");
            AddMusic("BloodMoon", "Thriplerex", "Events");
            AddMusic("BloodMoonDeath", "Thriplerex", "Events");
            AddMusic("SlimeRain", "HeartPlusUp", "Events");
            //AddMusic("Blizzard", "", "Events");
            AddMusic("Sandstorm", "TYESKI", "Events");
            AddMusic("OceanRain", "HeartPlusUp", "Events");
            //AddMusic("Thunderstorm", "", "Events");
            AddMusic("TownRain", "HeartPlusUp", "Events");
            AddMusic("Rain", "HeartPlusUp", "Events");
            AddMusic("TownParty", "HeartPlusUp", "Events");
            //AddMusic("WindyDay", "", "Events");
            AddMusic("LanternFestival", "HeartPlusUp", "Events");
            AddMusic("HardmodeInterlude", "Salvati", "Misc");
            AddMusic("FalseEpilogue", "HeartPlusUp", "Misc");
            //AddMusic("DragonsLull", "", "Misc");
            AddMusic("RainLegacy", "HeartPlusUp", "Misc");
            //AddMusic("ImpendingDoom", "", "Misc");
            //AddMusic("CultistRitual", "", "Misc");
            //AddMusic("MechEngaging", "", "Misc");
        }
    }
}
