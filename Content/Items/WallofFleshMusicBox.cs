using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class WallofFleshMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WallofFleshMusicBox>();

        public override string MusicFilePath => "WallofFlesh";
	}
}
