using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class JungleDayMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.JungleDayMusicBox>();

        public override string MusicFilePath => "JungleDay";

        public override void MusicBoxRecipe()
		{
			Recipe.Create(Type, 1)
				.AddIngredient(ItemID.RichMahogany, 10)
				.AddIngredient(ItemID.MudBlock, 10)
				.AddIngredient(ItemID.Moonglow, 3)
				.AddIngredient(ItemID.MusicBox, 1)
				.AddTile(Recipes.musicBoxCraftingStation)
				.Register();
		}
	}
}
