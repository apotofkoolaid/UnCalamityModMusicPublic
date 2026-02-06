using Terraria;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;
using UnCalamityModMusic.Common.Music;

namespace UnCalamityModMusic.Common
{
    public abstract class MusicSceneBase : ModSceneEffect
    {
        public virtual string MusicFilePath { get; }

        public virtual int VanillaMusicPath { get; }

        public virtual bool MusicCondition(Player player) => false;

        public virtual bool BasicCondition() => ModContent.GetInstance<MusicConfig>().OverrideOtherworldlyMusic || !MusicFlags.OtherworldlyMusic;

        public override int Music => VanillaMusicPath > 0 ? VanillaMusicPath : MusicPathing.GetMusicSlot(MusicFilePath);

        public override float GetWeight(Player player) => ModContent.GetInstance<MusicConfig>().PrioritizeMusicFromOtherMods ? 0.4f : base.GetWeight(player);

        public override bool IsSceneEffectActive(Player player) => BasicCondition() && MusicCondition(player);
    }
    public abstract class AmbienceSceneBase : ModSceneEffect
    {
        public virtual string AmbienceFilePath { get; }

        public virtual bool AmbienceCondition(Player player) => false;

        public virtual bool BasicCondition() => ModContent.GetInstance<AmbienceRandomness>().ShouldPlayAmbience || ModContent.GetInstance<OtherConfig>().AmbienceFrequency == 100;

        public override int Music => MusicPathing.GetAmbienceSlot(AmbienceFilePath);


        public override SceneEffectPriority Priority => MusicFlags.Town || MusicFlags.AnyWorkshopTier || MusicFlags.LanternFestival ? SceneEffectPriority.Environment : Priority;

        public override float GetWeight(Player player) => 0.7f;

        public override bool IsSceneEffectActive(Player player) => BasicCondition() && AmbienceCondition(player);
    }
    public abstract class LureSceneBase : ModSceneEffect
    {
        public virtual string LureFilePath { get; }

        public virtual bool LureCondition(Player player) => false;

        public virtual bool BasicCondition() => ModContent.GetInstance<MusicConfig>().OverrideAnahitasLureMusic && ModLoader.TryGetMod("CalamityMod", out Mod calamitymod) && NPC.AnyNPCs(calamitymod.Find<ModNPC>("LeviathanStart").Type);

        public override int Music => ModContent.GetInstance<OtherConfig>().AmbienceFrequency > 0 ? MusicPathing.GetAmbienceSlot(LureFilePath) : MusicPathing.GetMusicSlot(LureFilePath);

        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override float GetWeight(Player player) => ModContent.GetInstance<MusicConfig>().PrioritizeMusicFromOtherMods ? 0.41f : base.GetWeight(player) + 0.01f;

        public override bool IsSceneEffectActive(Player player) => BasicCondition() && LureCondition(player);
    }
}
