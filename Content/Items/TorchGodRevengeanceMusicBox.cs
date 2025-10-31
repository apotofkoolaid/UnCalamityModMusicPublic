using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class TorchGodRevengeanceMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.TorchGodRevengeanceMusicBox>();

        public override string MusicFilePath => "TorchGodRevengeance";
	}
}
