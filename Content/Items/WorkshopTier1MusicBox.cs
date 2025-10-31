using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop1MusicBox")]
	public class WorkshopTier1MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier1MusicBox>();

        public override string MusicFilePath => "WorkshopTier1";
	}
}
