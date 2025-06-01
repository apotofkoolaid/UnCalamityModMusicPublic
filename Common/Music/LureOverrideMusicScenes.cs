using Terraria;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.Music
{
    public abstract class LureOverrideBaseScene : ModSceneEffect
    {
        public virtual string Path { get; }

        public override int Music => ModContent.GetInstance<OtherConfig>().AmbienceFrequency > 0 ? MusicPathing.GetAmbienceSlot(Path) : MusicPathing.GetMusicSlot(Path);

        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override float GetWeight(Player player) => 0.51f;

        public override bool IsSceneEffectActive(Player player)
        {
            return IsAnahitaLureActive() && ModContent.GetInstance<MusicConfig>().OverrideAnahitasLure;
        }

        public static bool IsAnahitaLureActive()
        {
            return ModLoader.TryGetMod("CalamityMod", out Mod calamity) && NPC.AnyNPCs(calamity.Find<ModNPC>("LeviathanStart").Type);
        }
    }
    public class RainHeavy_Ambience_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "RainHeavy";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<RainHeavy_Ambience>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class RainNormal_Ambience_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "RainNormal";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<RainNormal_Ambience>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class RainLight_Ambience_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "RainLight";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<RainLight_Ambience>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class Ocean_Ambience_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "Ocean";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<Ocean_Ambience>().IsSceneEffectActive(player) && !ModContent.GetInstance<OceanRain_LureOverride>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class OceanRain_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "OceanRain";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<OceanRain>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class OceanNight_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "OceanNight";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<OceanNight>().IsSceneEffectActive(player) && !ModContent.GetInstance<OceanRain_LureOverride>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class OceanDay_LureOverride : LureOverrideBaseScene
    {
        public override string Path => "OceanDay";

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<OceanDay>().IsSceneEffectActive(player) && !ModContent.GetInstance<OceanRain_LureOverride>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
}