using Terraria;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Tiles.External
{
	public class MusicBox : MusicBoxTile
	{
        public override string HighlightTexture => "UnCalamityModMusic/Content/Menus/BlankPixel";

        public override void MouseOver(int i, int j)
        {
            Main.LocalPlayer.cursorItemIconEnabled = false;
        }
    }
}
