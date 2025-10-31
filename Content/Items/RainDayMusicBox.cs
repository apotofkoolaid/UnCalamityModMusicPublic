using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
    [LegacyName("RainMusicBox")]
    public class RainDayMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.RainDayMusicBox>();

        public override string MusicFilePath => "RainDay";
	}
}
