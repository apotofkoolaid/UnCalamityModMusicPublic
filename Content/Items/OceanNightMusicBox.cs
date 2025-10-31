using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class OceanNightMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.OceanNightMusicBox>();

        public override string MusicFilePath => "OceanNight";
	}
}
