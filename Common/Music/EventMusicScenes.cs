using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.Music
{
    public class TorchGod : MusicSceneBase
    {
        public override string MusicFilePath => 
            MusicFlags.RevengeanceMode ? "TorchGodRevengeance" : 
            "TorchGod";

        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override bool MusicCondition(Player player) => MusicFlags.TorchGod;
    }

    public class CelestialPillarSolar : MusicSceneBase
    {
        /*public override string MusicFilePath => "CelestialPillarSolar";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool MusicCondition(Player player) => MusicFlags.SolarPillar;*/
    }

    public class CelestialPillarStardust : MusicSceneBase
    {
        /*public override string MusicFilePath => "CelestialPillarStardust";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool MusicCondition(Player player) => MusicFlags.StardustPillar;*/
    }

    public class CelestialPillarNebula : MusicSceneBase
    {
        /*public override string MusicFilePath => "CelestialPillarNebula";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool MusicCondition(Player player) => MusicFlags.NebulaPillar;*/
    }

    public class CelestialPillarVortex : MusicSceneBase
    {
        /*public override string MusicFilePath => "CelestialPillarVortex";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override bool MusicCondition(Player player) => MusicFlags.VortexPillar;*/
    }

    public class MartianMadness : MusicSceneBase
    {
        /*public override string MusicFilePath => "MartianMadness";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

		public override bool MusicCondition(Player player) => MusicFlags.MartianMadness;*/
    }

    public class FrostMoon : MusicSceneBase
    {
        /*public override string MusicFilePath => "FrostMoon";

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

        public override bool MusicCondition(Player player) => MusicFlags.FrostMoon;*/
    }

    public class PumpkinMoon : MusicSceneBase
    {
        /*public override string MusicFilePath => "PumpkinMoon";

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

        public override bool MusicCondition(Player player) => MusicFlags.PumpkinMoon;*/
    }

    public class PirateInvasion : MusicSceneBase
    {
        /*public override string MusicFilePath => "PirateInvasion";

		public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool MusicCondition(Player player) => MusicFlags.PirateInvasion;*/
    }

    public class FrostLegion : MusicSceneBase
    {
        /*public override string MusicFilePath => "Blizzard";

        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override bool MusicCondition(Player player) => MusicFlags.FrostLegion;*/

    }

    public class OldOnesArmy : MusicSceneBase
    {
        /*public override string MusicFilePath =>
            MusicFlags.DefeatedGolem ? "OldOnesArmyTier3" :
            MusicFlags.DefeatedAnyMech ? "OldOnesArmyTier2" :
            "OldOnesArmyTier1";

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

        public override bool MusicCondition(Player player) => MusicFlags.OldOnesArmy;*/
    }

    public class GoblinArmy : MusicSceneBase
    {
        /*public override string MusicFilePath => "GoblinArmy";

		public override SceneEffectPriority Priority => SceneEffectPriority.Event;

		public override bool MusicCondition(Player player) => MusicFlags.GoblinArmy;*/
    }

    public class SolarEclipse : MusicSceneBase
    {
        //public override string MusicFilePath => "SolarEclipse";
        public override int VanillaMusicPath => // Temporary for vanilla music.
            MusicFlags.OtherworldlyMusic ? MusicID.OtherworldlyEerie :
            MusicID.Eclipse;

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Temporary for vanilla music.

        public override bool MusicCondition(Player player) => MusicFlags.SolarEclipse;
    }

    public class SlimeRain : MusicSceneBase
    {
        public override string MusicFilePath => "SlimeRain";

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool MusicCondition(Player player) => MusicFlags.SlimeRain;
    }

    public class BloodMoon : MusicSceneBase
    {
        public override string MusicFilePath =>
            MusicFlags.DeathMode ? "BloodMoonDeath" :
            "BloodMoon";

        public override SceneEffectPriority Priority =>
            MusicFlags.DeathMode || MusicFlags.RemixSeed ? SceneEffectPriority.Environment :
            SceneEffectPriority.BiomeMedium;

        public override float GetWeight(Player player) => // Relative weight change.
            MusicFlags.DeathMode ? base.GetWeight(player) :
            MusicFlags.RemixSeed ? base.GetWeight(player) - 0.01f :
            base.GetWeight(player) + 0.01f;

        public override bool MusicCondition(Player player) => MusicFlags.BloodMoon;
    }

    public class Rain : MusicSceneBase
    {
        public override string MusicFilePath =>
            /*MusicFlags.Blizzard ? "Blizzard" :*/ MusicFlags.Blizzard ? "Tundra" :
            MusicFlags.Ocean ? "OceanRain" :
            //MusicFlags.Thunderstorm ? "Thunderstorm" :
            MusicFlags.Night ? "RainNight" :
            MusicFlags.Town ? "TownRain" :
            "RainDay";

        public override SceneEffectPriority Priority =>
            MusicFlags.Blizzard || MusicFlags.Town ? SceneEffectPriority.Environment :
            SceneEffectPriority.BiomeMedium;

        public override float GetWeight(Player player) => // Relative weight change.
            MusicFlags.Blizzard || MusicFlags.Town ? base.GetWeight(player) :
            base.GetWeight(player) + 0.01f;

        public override bool MusicCondition(Player player) => MusicFlags.Rain;
    }

    public class LanternFestival : MusicSceneBase
    {
        public override string MusicFilePath => "LanternFestival";

        public override SceneEffectPriority Priority => 
            MusicFlags.Town ? SceneEffectPriority.Environment :
            MusicFlags.GlowingMushrooms || MusicFlags.SulphurousSea ? SceneEffectPriority.BiomeHigh :
            SceneEffectPriority.BiomeMedium;

        public override float GetWeight(Player player) => base.GetWeight(player) + 0.3f; // Relative weight change.

        public override bool MusicCondition(Player player) => MusicFlags.LanternFestival;
    }
}