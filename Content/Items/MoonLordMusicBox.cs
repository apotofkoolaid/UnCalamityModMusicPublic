using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class MoonLordMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.MoonLordMusicBox>();

        public override string MusicFilePath => "MoonLord";
	}
}
