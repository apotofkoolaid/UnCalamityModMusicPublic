using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop4MusicBox")]
	public class WorkshopTier4MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier4MusicBox>();

        public override string MusicFilePath => "WorkshopTier4";

        public override void MusicBoxRecipe()
        {
            // Contingent recipe for when Moon Lord is down
            Recipe.Create(Type, 1)
                .AddIngredient(ModContent.ItemType<WorkshopTier5MusicBox>())
                .AddIngredient(ModContent.ItemType<MoonLordMusicBox>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
	}
}
