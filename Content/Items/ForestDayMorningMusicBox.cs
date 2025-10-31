using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Day2MusicBox")]
	public class ForestDayMorningMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.ForestDayMorningMusicBox>();

        public override string MusicFilePath => "ForestDayMorning";
	}
}
