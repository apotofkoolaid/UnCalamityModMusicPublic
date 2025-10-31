using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class LanternFestivalMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.LanternFestivalMusicBox>();

        public override string MusicFilePath => "LanternFestival";
	}
}
