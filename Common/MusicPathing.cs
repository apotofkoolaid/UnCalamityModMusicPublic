using System.Collections.Generic;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common
{
    public static class MusicPathing
	{
        internal static Dictionary<string, int> musicPaths;
        internal static Dictionary<string, int> ambiencePaths;

        public static void InitalizeMusicPaths(Mod mod)
        {
            musicPaths = new Dictionary<string, int>
            {
                // Biomes
                {"Aether", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Aether")},
                {"Caverns", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Caverns")},
                {"Corruption", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Corruption")},
                {"CorruptionUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/CorruptionUnderground")},
                {"Crimson", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Crimson")},
                {"CrimsonUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/CrimsonUnderground")},
                {"Desert", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Desert")},
                {"DesertUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/DesertUnderground")},
                {"Dungeon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Dungeon")},
                {"ForestDayAfternoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayAfternoon")},
                {"ForestDayDawn", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayDawn")},
                {"ForestDayEvening", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayEvening")},
                {"ForestDayMorning", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayMorning")},
                {"ForestNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestNight")},
                {"Geodes", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Geodes")},
                {"GlowingMushrooms", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/GlowingMushrooms")},
                {"Graveyard", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Graveyard")},
                {"Hallow", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Hallow")},
                {"HallowUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/HallowUnderground")},
                {"JungleDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleDay")},
                {"JungleNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleNight")},
                {"JungleTemple", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleTemple")},
                {"JungleUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleUnderground")},
                {"Meteorite", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Meteorite")},
                {"OceanDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/OceanDay")},
                {"OceanNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/OceanNight")},
                {"Space", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Space")},
                {"TownDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TownDay")},
                {"TownNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TownNight")},
                {"TownNight_Noiseless", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TownNight_Noiseless")},
                {"Tundra", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Tundra")},
                {"TundraUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TundraUnderground")},
                {"Underworld", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Underworld")},
                {"Underground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Underground")},
                {"UndergroundEndgame", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/UndergroundEndgame")},
                {"UndergroundHardmode", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/UndergroundHardmode")},
                {"WorkshopTier1", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier1")},
                {"WorkshopTier2", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier2")},
                {"WorkshopTier3", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier3")},
                {"WorkshopTier4", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier4")},
                {"WorkshopTier5", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier5")},
                {"WorkshopTier6", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier6")},

                // Bosses
                {"BrainofCthulhu", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/BrainofCthulhu")},
                {"Deerclops", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Deerclops")},
                {"Destroyer", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Destroyer")},
                {"Dreadnautilus", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Dreadnautilus")},
                {"DukeFishron", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/DukeFishron")},
                {"EaterofWorlds", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/EaterofWorlds")},
                {"EmpressofLight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/EmpressofLight")},
                {"EyeofCthulhu", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/EyeofCthulhu")},
                {"Golem", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Golem")},
                {"KingSlime", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/KingSlime")},
                {"LunaticCultist", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/LunaticCultist")},
                {"Mechs", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Mechs")},
                {"MoonLord", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/MoonLord")},
                {"Plantera", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Plantera")},
                {"QueenBee", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/QueenBee")},
                {"QueenSlime", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/QueenSlime")},
                {"Skeletron", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Skeletron")},
                {"SkeletronPrime", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/SkeletronPrime")},
                {"Twins", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Twins")},
                {"WallofFlesh", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/WallofFlesh")},

                // Events
                {"Blizzard", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/Blizzard")},
                {"BloodMoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/BloodMoon")},
                {"BloodMoonDeath", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/BloodMoonDeath")},
                {"CelestialPillarNebula", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarNebula")},
                {"CelestialPillarSolar", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarSolar")},
                {"CelestialPillarStardust", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarStardust")},
                {"CelestialPillarVortex", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarVortex")},
                {"FrostMoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/FrostMoon")},
                {"GoblinArmy", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/GoblinArmy")},
                {"LanternFestival", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/LanternFestival")},
                {"MartianMadness", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/MartianMadness")},
                {"OceanRain", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OceanRain")},
                {"OldOnesArmyTier1", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OldOnesArmyTier1")},
                {"OldOnesArmyTier2", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OldOnesArmyTier2")},
                {"OldOnesArmyTier3", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OldOnesArmyTier3")},
                {"PirateInvasion", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/PirateInvasion")},
                {"PumpkinMoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/PumpkinMoon")},
                {"RainDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/RainDay")},
                {"RainNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/RainNight")},
                {"Sandstorm", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/Sandstorm")},
                {"SlimeRain", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/SlimeRain")},
                {"SolarEclipse", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/SolarEclipse")},
                {"Thunderstorm", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/Thunderstorm")},
                {"TorchGod", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TorchGod")},
                {"TorchGodRevengeance", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TorchGodRevengeance")},
                {"TownParty", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TownParty")},
                {"TownRain", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TownRain")},
                {"WindyDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/WindyDay")},

                // Misc
                {"CultistRitual", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/CultistRitual")},
                {"DragonsLull", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/DragonsLull")},
                {"FalseEpilogue", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/FalseEpilogue")},
                {"HardmodeInterlude", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/HardmodeInterlude")},
                {"ImpendingDoom", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/ImpendingDoom")},
                {"MechEngaging", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/MechEngaging")},
                {"RainLegacy", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/RainLegacy")}
            };

            ambiencePaths = new Dictionary<string, int>
            {
                // Ambience
                {"AbyssLayer2", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AbyssLayer2")},
                {"AbyssLayer3", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AbyssLayer3")},
                {"AbyssLayer4", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AbyssLayer4")},
                {"AstralInfection", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AstralInfection")},
                {"AstralInfectionUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AstralInfectionUnderground")},
                {"BeeHive", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/BeeHive")},
                {"BioLab", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/BioLab")},
                {"BrimstoneCrags", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/BrimstoneCrags")},
                {"Caverns", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Caverns")},
                {"Corruption", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Corruption")},
                {"CorruptionUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/CorruptionUnderground")},
                {"Crimson", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Crimson")},
                {"CrimsonUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/CrimsonUnderground")},
                {"Desert", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Desert")},
                {"DesertUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/DesertUnderground")},
                {"Dungeon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Dungeon")},
                {"ForestDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/ForestDay")},
                {"ForestNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/ForestNight")},
                {"GlowingMushrooms", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/GlowingMushrooms")},
                {"Hallow", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Hallow")},
                {"HallowUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/HallowUnderground")},
                {"Jungle", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Jungle")},
                {"JungleTemple", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/JungleTemple")},
                {"JungleUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/JungleUnderground")},
                {"Meteorite", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Meteorite")},
                {"Ocean", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Ocean")},
                {"RainHeavy", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/RainHeavy")},
                {"RainLight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/RainLight")},
                {"RainNormal", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/RainNormal")},
                {"Sandstorm", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Sandstorm")},
                {"Space", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Space")},
                {"SpiderCave", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/SpiderCave")},
                {"SulphurousSea", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/SulphurousSea")},
                {"SunkenSea", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/SunkenSea")},
                {"Tundra", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Tundra")},
                {"TundraUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/TundraUnderground")},
                {"Underground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Underground")},
                {"Underworld", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Underworld")}
            };
        }

        public static int GetMusicSlot(string key)
        {
            if (musicPaths.TryGetValue(key, out int slot))
            {
                return slot;
            }
            return -1;
        }

        public static int GetAmbienceSlot(string key)
        {
            if (ambiencePaths.TryGetValue(key, out int slot))
            {
                return slot;
            }
            return -1;
        }
    }
}