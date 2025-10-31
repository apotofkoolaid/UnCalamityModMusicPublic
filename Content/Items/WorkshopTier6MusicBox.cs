using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop6MusicBox")]
	public class WorkshopTier6MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier6MusicBox>();

        public override string MusicFilePath => "WorkshopTier6";
	}
}
