using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop4MusicBox")]
	public class WorkshopTier4MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier4MusicBox>();

        public override string MusicFilePath => "WorkshopTier4";
	}
}
