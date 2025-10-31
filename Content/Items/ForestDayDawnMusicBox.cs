using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Day1MusicBox")]
	public class ForestDayDawnMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.ForestDayDawnMusicBox>();

        public override string MusicFilePath => "ForestDayDawn";
	}
}
