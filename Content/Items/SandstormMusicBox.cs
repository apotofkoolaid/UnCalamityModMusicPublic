using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class SandstormMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.SandstormMusicBox>();

        public override string MusicFilePath => "Sandstorm";

        public override void MusicBoxRecipe()
		{
			Recipe.Create(Type, 1)
				.AddIngredient(ItemID.AncientCloth, 10)
				.AddIngredient(ItemID.SandBlock, 10)
				.AddIngredient(ItemID.AncientBattleArmorMaterial, 1)
				.AddIngredient(ItemID.MusicBox, 1)
				.AddTile(Recipes.musicBoxCraftingStation)
				.Register();
		}
	}
}
