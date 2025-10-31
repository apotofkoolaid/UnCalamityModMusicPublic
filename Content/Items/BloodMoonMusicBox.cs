using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("BloodMoon1MusicBox")]
	public class BloodMoonMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.BloodMoonMusicBox>();

        public override string MusicFilePath => "BloodMoon";
	}
}
