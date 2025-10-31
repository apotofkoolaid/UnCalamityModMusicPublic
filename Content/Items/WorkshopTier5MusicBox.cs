using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop5MusicBox")]
	public class WorkshopTier5MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier5MusicBox>();

        public override string MusicFilePath => "WorkshopTier5";
    }
}
