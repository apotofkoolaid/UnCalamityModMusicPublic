using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("NightMusicBox")]
	public class ForestNightMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.ForestNightMusicBox>();

        public override string MusicFilePath => "ForestNight";
	}
}
