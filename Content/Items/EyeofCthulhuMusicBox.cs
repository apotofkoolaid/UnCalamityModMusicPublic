using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class EyeofCthulhuMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.EyeofCthulhuMusicBox>();

        public override string MusicFilePath => "EyeofCthulhu";
	}
}
