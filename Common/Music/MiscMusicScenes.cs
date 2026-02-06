using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.Music
{
    public class FalseEpilogue : ModSystem
    {
        public int FalseEpilogueMusicSlot = 0;

        public override void OnWorldLoad()
        {
            FalseEpilogueMusicSlot = MusicPathing.GetMusicSlot("FalseEpilogue");
        }

        public override void UpdateUI(GameTime gameTime)
        {
            Player player = Main.player[Main.myPlayer];

            if (CreditsRollEvent.IsEventOngoing && !player.hasCreditsSceneMusicBox && MusicFlags.NotInCalamityMusicEvent)
            {
                Main.musicBox2 = FalseEpilogueMusicSlot;
                return;
            }
        }
    }

	public class ImpendingDoom : MusicSceneBase
	{
		/*public override string MusicFilePath => "ImpendingDoom";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Relative weight change.

        public override bool MusicCondition(Player player) => MusicFlags.ImpendingDoom;

        public override void SpecialVisuals(Player player, bool isActive)
		{
            // Makes the music start instantly without fade, feeling more powerful.
            if (NPC.MoonLordCountdown > 3540)
			{
				Main.musicFade[Main.curMusic] = 1f;
            }
		}*/
	}

	public class CultistRitual : MusicSceneBase
	{
		/*public override string MusicFilePath => "CultistRitual";

		public override SceneEffectPriority Priority =>
            MusicUtilities.CultistsAngered() ? SceneEffectPriority.BossLow : 
            SceneEffectPriority.Environment;

        public override float GetWeight(Player player) => // Relative weight change.
            MusicUtilities.CultistsAngered() ? base.GetWeight(player) : 
            base.GetWeight(player) + 0.01f;

        public override bool MusicCondition(Player player) => MusicFlags.CultistRitual;*/
	}

	public class MechEngaging : MusicSceneBase
	{
		/*public override string MusicFilePath => "MechEngaging";

		public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override float GetWeight(Player player) => base.GetWeight(player) - 0.01f; // Relative weight change.

        public override bool MusicCondition(Player player) => MusicFlags.MechEngaging;*/
	}

    #region Lure Override
    public class RainHeavy_Ambience_LureOverride : LureSceneBase
    {
        public override string LureFilePath => "RainHeavy";

        public override bool LureCondition(Player player) => ModContent.GetInstance<RainHeavy_Ambience>().IsSceneEffectActive(player);
    }

    public class RainNormal_Ambience_LureOverride : LureSceneBase
    {
        public override string LureFilePath => "RainNormal";

        public override bool LureCondition(Player player) => ModContent.GetInstance<RainNormal_Ambience>().IsSceneEffectActive(player);
    }

    public class RainLight_Ambience_LureOverride : LureSceneBase
    {
        public override string LureFilePath => "RainLight";

        public override bool LureCondition(Player player) => ModContent.GetInstance<RainLight_Ambience>().IsSceneEffectActive(player);
    }

    public class Ocean_Ambience_LureOverride : LureSceneBase
    {
        public override string LureFilePath => "Ocean";

        public override bool LureCondition(Player player) => ModContent.GetInstance<Ocean_Ambience>().IsSceneEffectActive(player) && !ModContent.GetInstance<Rain_LureOverride>().IsSceneEffectActive(player);
    }

    public class Rain_LureOverride : LureSceneBase
    {
        public override string LureFilePath => "OceanRain";

        public override bool LureCondition(Player player) => ModContent.GetInstance<Rain>().IsSceneEffectActive(player);
    }

    public class Ocean_LureOverride : LureSceneBase
    {
        public override string LureFilePath =>
            MusicFlags.Night ? "OceanNight" : 
            "OceanDay";

        public override bool LureCondition(Player player) => ModContent.GetInstance<Ocean>().IsSceneEffectActive(player) && !ModContent.GetInstance<Rain_LureOverride>().IsSceneEffectActive(player);
    }
    #endregion
}
