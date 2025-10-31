using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic.Content.Items
{
	[LegacyName("GreySkyMusicBox")]
	public class RainLegacyMusicBox : MusicBoxItem
	{
		public override int MusicBoxTile => ModContent.TileType<Tiles.RainLegacyMusicBox>();

        public override string MusicFilePath => "RainLegacy";

        public override void AddRecipes()
		{
            // Does not play in-game
            Recipe.Create(Type, 1)
                .AddIngredient(ModContent.ItemType<RainDayMusicBox>())
                .AddIngredient(ModContent.ItemType<MoonLordMusicBox>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            Recipe.Create(Type, 1)
                .AddIngredient(ModContent.ItemType<RainNightMusicBox>())
                .AddIngredient(ModContent.ItemType<MoonLordMusicBox>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
