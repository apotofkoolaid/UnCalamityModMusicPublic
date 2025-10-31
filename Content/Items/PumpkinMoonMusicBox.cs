using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class PumpkinMoonMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.PumpkinMoonMusicBox>();

        public override string MusicFilePath => "PumpkinMoon";
	}
}
