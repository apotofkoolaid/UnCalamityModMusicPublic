using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class GlowingMushroomFieldsMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.GlowingMushroomFieldsMusicBox>();

        public override string MusicFilePath => "GlowingMushroomFields";
	}
}
