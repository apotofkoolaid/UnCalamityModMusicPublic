using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("CrimsonUgMusicBox")]
	public class CrimsonUndergroundMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.CrimsonUndergroundMusicBox>();

        public override string MusicFilePath => "CrimsonUnderground";
	}
}
