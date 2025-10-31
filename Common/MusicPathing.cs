using System.Collections.Generic;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common
{
	public static class MusicPathing
	{
        public static Dictionary<string, int> musicPaths;
        public static Dictionary<string, int> ambiencePaths;

        public static void InitalizeMusicPaths(Mod mod)
        {
            musicPaths = new Dictionary<string, int>
            {
                //Biomes
                {"Space", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Space")},
                {"Underworld", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Underworld")},
                {"Aether", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Aether")},
                {"Graveyard", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Graveyard")},
                {"Meteorite", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Meteorite")},
                {"WorkshopTier6", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier6")},
                {"WorkshopTier5", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier5")},
                {"WorkshopTier4", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier4")},
                {"WorkshopTier3", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier3")},
                {"WorkshopTier2", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier2")},
                {"WorkshopTier1", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/WorkshopTier1")},
                {"TownNight_Noiseless", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TownNight_Noiseless")},
                {"TownNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TownNight")},
                {"TownDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TownDay")},
                {"JungleTemple", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleTemple")},
                {"Dungeon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Dungeon")},
                {"GlowingMushroomFields", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/GlowingMushroomFields")},
                {"Corruption", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Corruption")},
                {"CorruptionUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/CorruptionUnderground")},
                {"Crimson", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Crimson")},
                {"CrimsonUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/CrimsonUnderground")},
                {"Geodes", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Geodes")},
                {"JungleNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleNight")},
                {"JungleDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleDay")},
                {"JungleUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/JungleUnderground")},
                {"Tundra", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Tundra")},
                {"TundraUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/TundraUnderground")},
                {"Hallow", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Hallow")},
                {"HallowUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/HallowUnderground")},
                {"DesertUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/DesertUnderground")},
                {"UndergroundHardmode", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/UndergroundHardmode")},
                {"Caverns", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Caverns")},
                {"Underground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Underground")},
                {"OceanNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/OceanNight")},
                {"OceanDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/OceanDay")},
                {"Desert", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/Desert")},
                {"ForestNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestNight")},
                {"ForestDayEvening", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayEvening")},
                {"ForestDayAfternoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayAfternoon")},
                {"ForestDayMorning", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayMorning")},
                {"ForestDayDawn", MusicLoader.GetMusicSlot(mod, "Assets/Music/Biomes/ForestDayDawn")},

                //Bosses
                {"MoonLord", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/MoonLord")},
                {"LunaticCultist", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/LunaticCultist")},
                {"EmpressofLight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/EmpressofLight")},
                {"DukeFishron", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/DukeFishron")},
                {"Golem", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Golem")},
                {"Plantera", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Plantera")},
                {"Mechs", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Mechs")},
                {"SkeletronPrime", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/SkeletronPrime")},
                {"Twins", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Twins")},
                {"Destroyer", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Destroyer")},
                {"QueenSlime", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/QueenSlime")},
                {"Dreadnautilus", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Dreadnautilus")},
                {"WallofFlesh", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/WallofFlesh")},
                {"Skeletron", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Skeletron")},
                {"Deerclops", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/Deerclops")},
                {"QueenBee", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/QueenBee")},
                {"BrainofCthulhu", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/BrainofCthulhu")},
                {"EaterofWorlds", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/EaterofWorlds")},
                {"EyeofCthulhu", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/EyeofCthulhu")},
                {"KingSlime", MusicLoader.GetMusicSlot(mod, "Assets/Music/Bosses/KingSlime")},

                //Events
                {"TorchGod", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TorchGod")},
                {"TorchGodRevengeance", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TorchGodRevengeance")},
                {"CelestialPillarSolar", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarSolar")},
                {"CelestialPillarStardust", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarStardust")},
                {"CelestialPillarNebula", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarNebula")},
                {"CelestialPillarVortex", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/CelestialPillarVortex")},
                {"MartianMadness", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/MartianMadness")},
                {"FrostMoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/FrostMoon")},
                {"PumpkinMoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/PumpkinMoon")},
                {"OldOnesArmyTier3", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OldOnesArmyTier3")},
                {"OldOnesArmyTier2", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OldOnesArmyTier2")},
                {"OldOnesArmyTier1", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OldOnesArmyTier1")},
                {"PirateInvasion", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/PirateInvasion")},
                {"GoblinArmy", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/GoblinArmy")},
                {"SolarEclipse", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/SolarEclipse")},
                {"BloodMoon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/BloodMoon")},
                {"BloodMoonDeath", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/BloodMoonDeath")},
                {"SlimeRain", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/SlimeRain")},
                {"Blizzard", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/Blizzard")},
                {"Sandstorm", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/Sandstorm")},
                {"OceanRain", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/OceanRain")},
                {"Thunderstorm", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/Thunderstorm")},
                {"TownRain", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TownRain")},
                {"RainNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/RainNight")},
                {"RainDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/RainDay")},
                {"TownParty", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/TownParty")},
                {"WindyDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/WindyDay")},
                {"LanternFestival", MusicLoader.GetMusicSlot(mod, "Assets/Music/Events/LanternFestival")},

                //Misc
                {"DragonsLull", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/DragonsLull")},
                {"RainLegacy", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/RainLegacy")},
                {"FalseEpilogue", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/FalseEpilogue")},
                {"ImpendingDoom", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/ImpendingDoom")},
                {"CultistRitual", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/CultistRitual")},
                {"MechEngaging", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/MechEngaging")},
                {"HardmodeInterlude", MusicLoader.GetMusicSlot(mod, "Assets/Music/Misc/HardmodeInterlude")},
            };

            ambiencePaths = new Dictionary<string, int>
            {
                //Ambience
                {"BioLab", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/BioLab")},
                {"Sandstorm", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Sandstorm")},
                {"RainHeavy", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/RainHeavy")},
                {"RainNormal", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/RainNormal")},
                {"RainLight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/RainLight")},
                {"Space", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Space")},
                {"BrimstoneCrags", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/BrimstoneCrags")},
                {"Underworld", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Underworld")},
                {"Meteorite", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Meteorite")},
                {"JungleTemple", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/JungleTemple")},
                {"Dungeon", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Dungeon")},
                {"AstralInfection", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AstralInfection")},
                {"AstralInfectionUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AstralInfectionUnderground")},
                {"SulphurousSea", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/SulphurousSea")},
                {"AbyssLayer4", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AbyssLayer4")},
                {"AbyssLayer3", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AbyssLayer3")},
                {"AbyssLayer2", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/AbyssLayer2")},
                {"SunkenSea", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/SunkenSea")},
                {"GlowingMushroomGrove", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/GlowingMushroomGrove")},
                {"GlowingMushroomFields", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/GlowingMushroomFields")},
                {"Corruption", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Corruption")},
                {"CorruptionUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/CorruptionUnderground")},
                {"Crimson", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Crimson")},
                {"CrimsonUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/CrimsonUnderground")},
                {"BeeHive", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/BeeHive")},
                {"SpiderCave", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/SpiderCave")},
                {"Tundra", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Tundra")},
                {"TundraUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/TundraUnderground")},
                {"Jungle", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Jungle")},
                {"JungleUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/JungleUnderground")},
                {"Hallow", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Hallow")},
                {"HallowUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/HallowUnderground")},
                {"DesertUnderground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/DesertUnderground")},
                {"Caverns", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Caverns")},
                {"Underground", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Underground")},
                {"Ocean", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Ocean")},
                {"Desert", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/Desert")},
                {"ForestNight", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/ForestNight")},
                {"ForestDay", MusicLoader.GetMusicSlot(mod, "Assets/Music/Ambience/ForestDay")}
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