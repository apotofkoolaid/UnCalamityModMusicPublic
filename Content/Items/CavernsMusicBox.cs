using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Underground2MusicBox")]
	public class CavernsMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.CavernsMusicBox>();

        public override string MusicFilePath => "Caverns";

        public override void MusicBoxRecipe()
        {
            // Contingent recipe for when in Hardmode
            /*Recipe.Create(Type, 1)
                .AddIngredient(ModContent.ItemType<UndergroundHardmodeMusicBox>())
                .AddIngredient(ModContent.ItemType<WallofFleshMusicBox>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();*/
        }
    }
}
