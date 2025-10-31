using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Day3MusicBox")]
	public class ForestDayAfternoonMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.ForestDayAfternoonMusicBox>();

        public override string MusicFilePath => "ForestDayAfternoon";
	}
}
