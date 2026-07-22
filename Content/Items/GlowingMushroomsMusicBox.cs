using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
    [LegacyName("GlowingMushroomFieldsMusicBox")]
    public class GlowingMushroomsMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.GlowingMushroomsMusicBox>();

        public override string MusicFilePath => "GlowingMushrooms";
	}
}
