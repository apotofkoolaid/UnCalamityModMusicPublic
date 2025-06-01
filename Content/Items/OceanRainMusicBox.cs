using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	public class OceanRainMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.OceanRainMusicBox>();

        public override string MusicFilePath => "OceanRain";

        public override void MusicBoxRecipe()
		{
			Recipe.Create(Type, 1)
				.AddIngredient(ItemID.PalmWood, 10)
				.AddIngredient(ItemID.RainCloud, 10)
                .AddIngredient(ItemID.Coral, 3)
                .AddIngredient(ItemID.MusicBox, 1)
				.AddTile(Recipes.musicBoxCraftingStation)
				.Register();
		}
	}
}
