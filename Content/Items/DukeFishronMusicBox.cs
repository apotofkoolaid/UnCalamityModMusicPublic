using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class DukeFishronMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.DukeFishronMusicBox>();

        public override string MusicFilePath => "DukeFishron";
	}
}
