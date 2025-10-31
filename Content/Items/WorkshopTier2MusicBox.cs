using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop2MusicBox")]
	public class WorkshopTier2MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier2MusicBox>();

        public override string MusicFilePath => "WorkshopTier2";
	}
}
