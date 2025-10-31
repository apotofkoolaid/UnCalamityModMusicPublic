using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("CorruptionUgMusicBox")]
	public class CorruptionUndergroundMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.CorruptionUndergroundMusicBox>();

        public override string MusicFilePath => "CorruptionUnderground";
	}
}
