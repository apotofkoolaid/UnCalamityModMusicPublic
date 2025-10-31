using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class EaterofWorldsMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.EaterofWorldsMusicBox>();

        public override string MusicFilePath => "EaterofWorlds";
	}
}
