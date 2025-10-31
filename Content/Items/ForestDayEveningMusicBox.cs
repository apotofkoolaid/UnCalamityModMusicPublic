using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Day4MusicBox")]
	public class ForestDayEveningMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.ForestDayEveningMusicBox>();

        public override string MusicFilePath => "ForestDayEvening";
	}
}
