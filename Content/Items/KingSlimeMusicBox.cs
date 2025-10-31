using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class KingSlimeMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.KingSlimeMusicBox>();

        public override string MusicFilePath => "KingSlime";
	}
}
