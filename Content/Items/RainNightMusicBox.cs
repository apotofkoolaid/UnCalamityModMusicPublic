using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
    public class RainNightMusicBox : MusicBoxItem
    {
        public override int MusicBoxTile => ModContent.TileType<Tiles.RainNightMusicBox>();

        public override string MusicFilePath => "RainNight";
	}
}