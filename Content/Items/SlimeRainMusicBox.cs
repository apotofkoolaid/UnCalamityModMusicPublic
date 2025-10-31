using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class SlimeRainMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.SlimeRainMusicBox>();

        public override string MusicFilePath => "SlimeRain";
	}
}
