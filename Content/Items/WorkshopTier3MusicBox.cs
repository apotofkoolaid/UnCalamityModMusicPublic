using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("Workshop3MusicBox")]
	public class WorkshopTier3MusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.WorkshopTier3MusicBox>();

        public override string MusicFilePath => "WorkshopTier3";

        public override void MusicBoxRecipe()
        {
            // Contingent recipe for when Plantera is down
            Recipe.Create(Type, 1)
                .AddIngredient(ModContent.ItemType<WorkshopTier4MusicBox>())
                .AddIngredient(ItemID.MusicBoxPlantera)
                //.AddIngredient(ModContent.ItemType<PlanteraMusicBox>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
