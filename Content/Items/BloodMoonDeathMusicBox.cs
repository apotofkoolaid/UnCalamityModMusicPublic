using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("BloodMoon2MusicBox")]
	public class BloodMoonDeathMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.BloodMoonDeathMusicBox>();

        public override string MusicFilePath => "BloodMoonDeath";
	}
}
