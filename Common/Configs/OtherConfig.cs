using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace UnCalamityModMusic.Common.Configs
{
	[BackgroundColor(49, 32, 36, 216)]
	public class OtherConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("$Mods.UnCalamityModMusic.Configs.OtherConfig.AmbienceModeHeader")]

		[Range(0f, 100f)]
		[Increment(1f)]
		[BackgroundColor(192, 54, 64, 192)]
		[SliderColor(224, 165, 56, 128)]
		[DefaultValue(0f)]
		public float AmbienceFrequency { get; set; }

		[BackgroundColor(192, 54, 64, 192)]
		[DefaultValue(false)]
		public bool DisableBeeHiveAmbience { get; set; }

		[BackgroundColor(192, 54, 64, 192)]
		[DefaultValue(false)]
		public bool DisableSpiderCaveAmbience { get; set; }

		[Header("$Mods.UnCalamityModMusic.Configs.OtherConfig.OtherChangesHeader")]

        [ReloadRequired]
		[BackgroundColor(192, 54, 64, 192)]
		[DefaultValue(false)]
		public bool MusicBoxResprite { get; set; }
    }
}