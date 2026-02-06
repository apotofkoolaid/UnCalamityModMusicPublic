using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.ModCompatibility
{
    //Ambience
    public class BeeHive_Ambience_Remnants : AmbienceSceneBase
    {
        public override string AmbienceFilePath => "BeeHive";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override bool AmbienceCondition(Player player) => MusicFlags.RemnantsHive && !ModContent.GetInstance<OtherConfig>().DisableBeeHiveAmbience;
    }

    public class Geodes_Ambience_Remnants : AmbienceSceneBase
    {
        public override string AmbienceFilePath => "Caverns";

        public override SceneEffectPriority Priority => ModContent.GetInstance<Geodes_Remnants>().Priority;

        public override bool AmbienceCondition(Player player) => ModContent.GetInstance<Geodes_Remnants>().IsSceneEffectActive(player);
    }

    public class JungleUnderground_Ambience_Remnants : AmbienceSceneBase
    {
        public override string AmbienceFilePath => "JungleUnderground";

        public override SceneEffectPriority Priority => ModContent.GetInstance<JungleUnderground_Remnants>().Priority;

        public override bool AmbienceCondition(Player player) => ModContent.GetInstance<JungleUnderground_Remnants>().IsSceneEffectActive(player);
    }

    //Biomes
    public class Geodes_Remnants : MusicSceneBase
    {
        public override string MusicFilePath => "Geodes";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override float GetWeight(Player player) => base.GetWeight(player) + 0.01f; // Relative weight boost.

        public override bool MusicCondition(Player player) => MusicFlags.RemnantsGraniteCave || MusicFlags.RemnantsMarbleCave;
    }

    public class JungleUnderground_Remnants : MusicSceneBase
    {
        //public override string MusicFilePath => "JungleUnderground";
        public override int VanillaMusicPath => // Temporary for vanilla music.
            MusicFlags.OtherworldlyMusic ? MusicID.OtherworldlyJungle :
            MusicID.JungleUnderground;

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment; // Temporary for vanilla music; change to BiomeHigh when vanilla music is replaced.

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Temporary for vanilla music.

        public override bool MusicCondition(Player player) => MusicFlags.RemnantsHive;
    }
}
