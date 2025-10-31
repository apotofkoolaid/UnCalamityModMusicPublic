using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class MeteoriteMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.MeteoriteMusicBox>();

        public override string MusicFilePath => "Meteorite";
	}
}
