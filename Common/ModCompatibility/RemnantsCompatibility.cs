using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common.Music
{
	//Ambience Scenes
    public class BeeHive_Ambience_Remnants : AmbienceBaseScene
    {
        public override string Path => "BeeHive";

        public override SceneEffectPriority ScenePriority => SceneEffectPriority.BiomeHigh;

        public override bool IsSceneEffectActive(Player player)
        {
            return PlayerFlags.ZoneHive && !ModContent.GetInstance<OtherConfig>().DisableBeeHiveAmbience && base.IsSceneEffectActive(player);
        }
    }
    public class Geodes_Ambience_Remnants : AmbienceBaseScene
    {
        public override string Path => "Caverns";

        public override SceneEffectPriority ScenePriority => ModContent.GetInstance<Geodes_Remnants>().Priority;

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<Geodes_Remnants>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    public class JungleUnderground_Ambience_Remnants : AmbienceBaseScene
    {
        public override string Path => "JungleUnderground";

        public override SceneEffectPriority ScenePriority => ModContent.GetInstance<JungleUnderground_Remnants>().Priority;

        public override bool IsSceneEffectActive(Player player)
        {
            return ModContent.GetInstance<JungleUnderground_Remnants>().IsSceneEffectActive(player) && base.IsSceneEffectActive(player);
        }
    }
    //Biome Scenes
    public class Geodes_Remnants : ModSceneEffect
	{
		public override int Music => MusicPathing.GetMusicSlot("Geodes");

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override float GetWeight(Player player) => 0.51f;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneGraniteCave || PlayerFlags.ZoneMarbleCave;
		}
	}
	public class JungleUnderground_Remnants : ModSceneEffect
	{
		//public override int Music => MusicPathing.GetMusicSlot("JungleUnderground");
		public override int Music
		{
			get
			{
				bool otherworldMusicActive = PlayerFlags.SwapMusic();
				return otherworldMusicActive ? MusicID.OtherworldlyJungle : MusicID.JungleUnderground;
			}
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override float GetWeight(Player player) => 0.51f;

		public override bool IsSceneEffectActive(Player player)
		{
			return PlayerFlags.ZoneHive;
		}
	}
}