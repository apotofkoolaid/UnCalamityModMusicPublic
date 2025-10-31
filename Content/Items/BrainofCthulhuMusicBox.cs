using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class BrainofCthulhuMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.BrainofCthulhuMusicBox>();

        public override string MusicFilePath => "BrainofCthulhu";
	}
}
